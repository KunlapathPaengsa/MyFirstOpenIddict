using System.Collections.Generic;

namespace MyFirstOpenIddict.Common.Web.OpenIddict.Configurations
{
    public class ValidationConfiguration
    {
        public string Issuer { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public List<string> Audiences { get; set; }

        public ValidationConfiguration()
        {
            Audiences = new List<string>();
        }
    }

}
