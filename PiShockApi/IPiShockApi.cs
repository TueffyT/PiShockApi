using System.Threading.Tasks;
using PiShockApi.Models;
using Refit;

namespace PiShockApi {
    [Headers( "Content-Type: application/json" )]
    internal interface IPiShockApi {
        [Post( "/apioperate" )]
        Task<ApiResponse<string>> SendPiShockCommandAsync( [Body] PiShockRequest request );

        [Post( "/GetShockerInfo" )]
        Task<ApiResponse<PiShockInfoResult>> GetShockerInfoAsync( [Body] PiShockRequest request );
    }
}