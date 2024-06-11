namespace PiShockApi.Models {
    public class PiShockResult {
        public PiShockResult(bool isSuccessful, string message) {
            this.IsSuccessful = isSuccessful;
            this.Message = message;
        }

        public bool IsSuccessful {
            get;
            set;
        }

        public string Message {
            get;
            set;
        }
    }
}