using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using PiShockApi.Enums;
using PiShockApi.Models;
using Refit;

namespace PiShockApi {
    public class PiShockApiClient {
        private readonly IPiShockApi _piShockApi;

        private ILogger Logger => PiShockLogger.GetStaticLogger<PiShockApiClient>();

        public PiShockApiClient() {
            _piShockApi = RestService.For<IPiShockApi>( "https://do.pishock.com/api/apioperate" );
        }

        public string DisplayName {
            get;
            set;
        } = "PiShockControl";

        public async Task<PiShockResult> SendShockAsync( PiShockUser piShockUser, int intensity, int duration ) {
            PiShockRequest request = new() {
                Username = piShockUser.Username,
                ApiKey = piShockUser.ApiKey,
                Code = piShockUser.Code,
                Name = DisplayName,
                Operation = (int) PiShockOperation.Shock,
                Intensity = intensity,
                Duration = duration
            };
            Logger?.LogDebug( "Sending Shock {@Request}", request );
            ApiResponse<string> response = await _piShockApi.SendPiShockCommandAsync( request ).ConfigureAwait( false );

            if( response.IsSuccessStatusCode && response.Content == "Operation Succeeded." ) {
                return new PiShockResult( true, response.Content );
            }

            return new PiShockResult( false, response.Content );
        }

        public async Task<PiShockResult> SendMiniShockAsync( PiShockUser piShockUser, int intensity ) {
            PiShockRequest request = new PiShockRequest {
                Username = piShockUser.Username,
                ApiKey = piShockUser.ApiKey,
                Code = piShockUser.Code,
                Name = DisplayName,
                Operation = (int) PiShockOperation.Shock,
                Intensity = intensity,
                Duration = 300
            };
            Logger?.LogDebug( "Sending Mini-Shock {@Request}", request );
            ApiResponse<string> response = await _piShockApi.SendPiShockCommandAsync( request ).ConfigureAwait( false );

            if( response.IsSuccessStatusCode && response.Content == "Operation Succeeded." ) {
                return new PiShockResult( true, response.Content );
            }

            return new PiShockResult( false, response.Content );
        }

        public async Task<PiShockResult> SendVibrationAsync( PiShockUser piShockUser, int intensity, int duration ) {
            PiShockRequest request = new PiShockRequest {
                Username = piShockUser.Username,
                ApiKey = piShockUser.ApiKey,
                Code = piShockUser.Code,
                Name = DisplayName,
                Operation = (int) PiShockOperation.Vibrate,
                Intensity = intensity,
                Duration = duration
            };
            Logger?.LogDebug( "Sending Vibration {@Request}", request );
            ApiResponse<string> response = await _piShockApi.SendPiShockCommandAsync( request ).ConfigureAwait( false );

            if( response.IsSuccessStatusCode && response.Content == "Operation Succeeded." ) {
                return new PiShockResult( true, response.Content );
            }

            return new PiShockResult( false, response.Content );
        }

        public async Task<PiShockResult> SendBeepAsync( PiShockUser piShockUser, int intensity, int duration ) {
            PiShockRequest request = new PiShockRequest {
                Username = piShockUser.Username,
                ApiKey = piShockUser.ApiKey,
                Code = piShockUser.Code,
                Name = DisplayName,
                Operation = (int) PiShockOperation.Beep,
                Intensity = intensity,
                Duration = duration
            };
            Logger?.LogDebug( "Sending Beep {@Request}", request );
            ApiResponse<string> response = await _piShockApi.SendPiShockCommandAsync( request );

            if( response.IsSuccessStatusCode && response.Content == "Operation Succeeded." ) {
                return new PiShockResult( true, response.Content );
            }

            return new PiShockResult( false, response.Content );
        }
    }
}