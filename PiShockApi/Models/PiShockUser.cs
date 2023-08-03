namespace PiShockApi.Models {
    public class PiShockUser {

        public string Username {
            get;
            set;
        }

        public string ApiKey {
            get;
            set;
        }

        public string Code {
            get;
            set;
        }

        public override string ToString() {
            return Username;
        }
    }
}