using PiShockApi.Models;
using Refit;

namespace PiShockApi {
    [Headers( "Content-Type: application/json" )]
    public interface IPiShockApi {
        [Post( "/" )]
        public Task<ApiResponse<string>> SendPiShockCommandAsync( [Body] PiShockRequest request );
    }
}