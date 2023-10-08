using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;

namespace BoilerPlate.API
{

    public class ApiSettingOptions  
    {
        public const string SectionName = "ApiSettings";
        public string SecuirtyKey { get; set; }
    }
    public class ApisettingConfigureOptions : IConfigureOptions<ApiSettingOptions>
    {
        
        private readonly IConfiguration _configuration;
        public ApisettingConfigureOptions(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public void Configure(ApiSettingOptions options)
        {
            _configuration.GetSection(ApiSettingOptions.SectionName).Bind(options);

        }
    }
}
