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

        public void Deconstruct( out bool IsSuccessful, out string Message) {
            IsSuccessful = this.IsSuccessful;
            Message = this.Message;
        }
    }
}