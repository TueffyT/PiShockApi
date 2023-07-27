using PiShockApi.Models;
using Refit;

namespace PiShockApi {
    [Headers( "Content-Type: application/json" )]
    internal interface IPiShockApi {
        [Post( "/apioperate" )]
        public Task<ApiResponse<string>> SendPiShockCommandAsync( [Body] PiShockRequest request );

        [Post( "/GetShockerInfo" )]
        public Task<ApiResponse<PiShockInfoResult>> GetShockerInfoAsync( [Body] PiShockRequest request );
    }
}