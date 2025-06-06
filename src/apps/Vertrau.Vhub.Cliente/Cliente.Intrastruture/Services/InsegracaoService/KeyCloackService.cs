using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using  Cliente.Contracts;
using  Cliente.Intrastruture.Services.EntidadeService;
using  Cliente.Intrastruture.Services.InsegracaoService;
using  Cliente.Intrastruture.Services.InsegracaoService.EntidadesKeyCloack;

namespace  Cliente.Intrastruture
{
    public class KeyCloakService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenKeyCloack _tokenKeyCloack;
        private readonly IConfiguration _configuration;

        public KeyCloakService(HttpClient httpClient, TokenKeyCloack tokenKeyCloack, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _tokenKeyCloack = tokenKeyCloack;
            _configuration = configuration;
        }

        private string BaseUrl => _configuration["Keycloak:baseUrl"];
        private string PathAdmin => _configuration["Keycloak:pathAdmin"];
        private string RealmName => _configuration["Keycloak:realm:name"];

        // Método para gerar uma senha temporária
        public string GerarSenhaTemporaria()
        {
            return Guid.NewGuid().ToString("n").Substring(0, 8);
        }

        // Método para criar um novo realm
        public async Task CriarRealmAsync(string accessToken, string nomeRealm)
        {
            var requestBody = new
            {
                realm = nomeRealm,
                enabled = true
            };

            var requestContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.PostAsync($"{BaseUrl}/{PathAdmin}/{nomeRealm}", requestContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao criar realm: {response.StatusCode}, Detalhes: {errorContent}");
            }
        }

        // Método para criar um usuário no Keycloak
        public async Task<Response<KeycloakUserResponse>> CreateUserAsync(string accessToken, KeycloakUserRequest request)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var requestContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseUrl}/{PathAdmin}/{RealmName}/users", requestContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new Response<KeycloakUserResponse>
                {
                    Success = false,
                    Message = $"Erro ao criar usuário no Keycloak: {response.StatusCode}. Detalhes: {errorContent}"
                };
            }

            var userIdResponse = await ObterIdUsuarioPorEmailAsync(accessToken, request.email);
            return userIdResponse;
        }

        // Método para obter o ID do usuário baseado no e-mail
        public async Task<Response<KeycloakUserResponse>> ObterIdUsuarioPorEmailAsync(string accessToken, string email)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"{BaseUrl}/{PathAdmin}/{RealmName}/users/?exact=true&email={email}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new Response<KeycloakUserResponse>
                {
                    Success = false,
                    Message = $"Erro ao obter usuário por e-mail no Keycloak: {response.StatusCode}. Detalhes: {errorContent}"
                };
            }

            var content = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<KeycloakUserResponse>>(content);

            if (users != null && users.Any())
            {
                return new Response<KeycloakUserResponse> { Success = true, Data = users.First() };
            }

            return new Response<KeycloakUserResponse> { Success = false, Message = "Usuário não encontrado." };
        }

        // Método para atribuir uma role ao usuário no Keycloak
        public async Task<Response<string>> AtribuirRoleAoUsuario(string accessToken, string userId, string roleId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var roleAssignment = new[]
            {
                new
                {
                    id = roleId,
                    name = "default-role",
                    composite = false,
                    clientRole = false,
                    containerId = RealmName
                }
            };

            var requestContent = new StringContent(JsonConvert.SerializeObject(roleAssignment), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}/{PathAdmin}/{RealmName}/users/{userId}/role-mappings/realm", requestContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new Response<string>
                {
                    Success = false,
                    Message = $"Erro ao atribuir role ao usuário no Keycloak: {response.StatusCode}. Detalhes: {errorContent}"
                };
            }

            return new Response<string> { Success = true, Message = "Role atribuída com sucesso." };
        }

        // Método para obter o ID de uma role por nome
        public async Task<RoleResponse> ObterIdRoleAsync(string accessToken, string nomeRole)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"{BaseUrl}/{PathAdmin}/{RealmName}/roles/{nomeRole}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao obter role: {response.StatusCode}, Detalhes: {errorContent}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var role = JsonConvert.DeserializeObject<RoleResponse>(content);

            if (role != null && !string.IsNullOrEmpty(role.Id))
            {
                return role;
            }

            throw new Exception("Role não encontrada.");
        }

        // Método para adicionar um usuário ao grupo no Keycloak
        public async Task<Response<string>> AdicionarUsuarioAoGrupo(string accessToken, string userId, string groupId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{BaseUrl}/{PathAdmin}/{RealmName}/users/{userId}/groups/{groupId}", requestContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new Response<string>
                {
                    Success = false,
                    Message = $"Erro ao adicionar o usuário ao grupo no Keycloak: {response.StatusCode}. Detalhes: {errorContent}"
                };
            }

            return new Response<string> { Success = true, Message = "Usuário adicionado ao grupo com sucesso." };
        }

        // Método para atualizar o nome de um grupo no Keycloak
        public async Task<Response<string>> AtualizarNomeGrupoNoKeycloak(string accessToken, string groupId, string novoNome)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent(JsonConvert.SerializeObject(new { name = novoNome }), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{BaseUrl}/{PathAdmin}/{RealmName}/groups/{groupId}", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new Response<string>
                {
                    Success = false,
                    Message = $"Erro ao atualizar o nome do grupo no Keycloak: {response.StatusCode}, Detalhes: {errorContent}"
                };
            }

            return new Response<string> { Success = true, Message = "Nome do grupo atualizado com sucesso." };
        }

        // Método para excluir um usuário
        public async Task<bool> DeleteUserAsync(string accessToken, string userId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{PathAdmin}/{RealmName}/users/{userId}");
            return response.IsSuccessStatusCode;
        }
    }
}








