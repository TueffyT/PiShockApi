using Microsoft.Extensions.Configuration;

namespace PiShockApi.Tests {
    public class PiShockFixture {
        public IConfigurationRoot Configuration {
            get;
            private set;
        }

        public PiShockApiClient ApiClient {
            get;
            private set;
        }

        public PiShockUser PiShockUser {
            get;
            private set;
        }
        
        public PiShockFixture() {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile( "appsettings.json" )
                .AddUserSecrets<PiShockFixture>()
                .AddEnvironmentVariables()
                .Build();
            ApiClient = new PiShockApiClient();
            PiShockUser = new PiShockUser() {
                ApiKey = Configuration["Pishock:ApiKey"], Username = Configuration["PiShock:Username"], Code = Configuration["PiShock:Code"]
            };
        }
    }
}