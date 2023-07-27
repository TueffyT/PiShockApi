using System.Text.Json.Serialization;

namespace PiShockApi.Models {
    public class PiShockRequest {
        public string? Username {
            get;
            set;
        }

        public string? ApiKey {
            get;
            set;
        }

        public string? Code {
            get;
            set;
        }

        public string? Name {
            get;
            set;
        }

        [JsonPropertyName( "Op" )]
        public int Operation {
            get;
            set;
        }

        public int Duration {
            get;
            set;
        }

        public int Intensity {
            get;
            set;
        }
    }
}