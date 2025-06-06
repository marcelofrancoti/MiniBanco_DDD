namespace  Cliente.Intrastruture.Services.EntidadeService
{
    public class KeycloakTokenRequest
    {
        public string grantType { get; set; }
        public string clientId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

}
