namespace PiShockApi.Models {
    public class PiShockInfoResult {
        public PiShockInfoResult(int id, int clientId, string name, bool paused, int maxIntensity, int maxDuration, bool online) {
            this.Id = id;
            this.ClientId = clientId;
            this.Name = name;
            this.Paused = paused;
            this.MaxIntensity = maxIntensity;
            this.MaxDuration = maxDuration;
            this.Online = online;
        }

        public int Id {
            get;
            set;
        }

        public int ClientId {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public bool Paused {
            get;
            set;
        }

        public int MaxIntensity {
            get;
            set;
        }

        public int MaxDuration {
            get;
            set;
        }

        public bool Online {
            get;
            set;
        }
    }
}