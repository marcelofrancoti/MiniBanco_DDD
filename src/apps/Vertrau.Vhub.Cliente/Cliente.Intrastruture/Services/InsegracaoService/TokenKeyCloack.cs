using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using  Cliente.Intrastruture.Services.EntidadeService;

namespace  Cliente.Intrastruture.Services.InsegracaoService
{
    public class TokenKeyCloack
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public TokenKeyCloack(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<KeycloakTokenResponse> GetTokenAsync()
        {
            // Obter as configurações diretamente do appsettings.json
            var clientId = _configuration["Keycloak:client_id"];
            var username = _configuration["Keycloak:Username"];
            var password = _configuration["Keycloak:Password"];
            var tokenUrl = _configuration["Keycloak:TokenUrl"];
            var clientSecret = _configuration["Keycloak:client_secret"];
            var formContent = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                });

            var response = await _httpClient.PostAsync(tokenUrl, formContent);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error while fetching token: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<KeycloakTokenResponse>(responseContent);
        }

    }


}
