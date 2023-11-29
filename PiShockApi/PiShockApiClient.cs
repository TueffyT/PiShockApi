using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PiShockApi.Enums;
using PiShockApi.Models;
using Refit;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo( "PiShockApi.Tests" )]

namespace PiShockApi {
    public class PiShockApiClient {
        private readonly IPiShockApi _piShockApi;

        private ILogger Logger => PiShockLogger.GetStaticLogger<PiShockApiClient>();

        public PiShockApiClient() {
            _piShockApi = RestService.For<IPiShockApi>( "https://do.pishock.com/api/" );
        }

        public string DisplayName {
            get;
            set;
        } = "PiShockControl";

        /// <summary>
        /// Sends a shock command
        /// </summary>
        /// <param name="piShockUser">PiShock Credentials</param>
        /// <param name="intensity">Intensity of the Shock. Range 0-100</param>
        /// <param name="duration">Duration of the Shock. Values from 1-15 are seconds. Values Above 99 are treated as ms.</param>
        /// <returns><see cref="PiShockResult"/></returns>
        public async Task<PiShockResult> SendShockAsync( PiShockUser piShockUser, int intensity, int duration ) {
            ValidateUserAndThrow( piShockUser );
            ValidateIntensityAndThrow( intensity );

            PiShockRequest request = new PiShockRequest() {
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

            if( response.IsSuccessStatusCode &&
                (response.Content == PiShockResponseMessages.Success || response.Content == PiShockResponseMessages.Attempt) ) {
                return new PiShockResult( true, response.Content );
            }

            return new PiShockResult( false, response.Content );
        }


        /// <summary>
        /// Sends a MiniShock/Zapp command
        /// </summary>
        /// <param name="piShockUser">PiShock Credentials</param>
        /// <param name="intensity">Intensity of the Shock. Range 0-100</param>
        /// <returns><see cref="PiShockResult"/></returns>
        public async Task<PiShockResult> SendMiniShockAsync( PiShockUser piShockUser, int intensity ) {
            ValidateUserAndThrow( piShockUser );
            ValidateIntensityAndThrow( intensity );

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

            if( response.IsSuccessStatusCode &&
                (response.Content == PiShockResponseMessages.Success || response.Content == PiShockResponseMessages.Attempt) ) {
                return new PiShockResult( true, response.Content );
            }

            return new PiShockResult( false, response.Content );
        }

        /// <summary>
        /// Sends a vibration command
        /// </summary>
        /// <param name="piShockUser">PiShock Credentials</param>
        /// <param name="intensity">Intensity of the vibration. Range 0-100</param>
        /// <param name="duration">Duration of the vibration. Values from 1-15 are seconds. Values Above 99 are treated as ms.</param>
        /// <returns><see cref="PiShockResult"/></returns>
        public async Task<PiShockResult> SendVibrationAsync( PiShockUser piShockUser, int intensity, int duration ) {
            ValidateUserAndThrow( piShockUser );
            ValidateIntensityAndThrow( intensity );

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

            if( response.IsSuccessStatusCode &&
                (response.Content == PiShockResponseMessages.Success || response.Content == PiShockResponseMessages.Attempt) ) {
                return new PiShockResult( true, response.Content );
            }

            return new PiShockResult( false, response.Content );
        }

        /// <summary>
        /// Sends a beep command
        /// </summary>
        /// <param name="piShockUser">PiShock Credentials</param>
        /// <param name="intensity">Intensity of the beep. Range 0-100</param>
        /// <param name="duration">Duration of the beep. Values from 1-15 are seconds. Values Above 99 are treated as ms.</param>
        /// <returns><see cref="PiShockResult"/></returns>
        public async Task<PiShockResult> SendBeepAsync( PiShockUser piShockUser, int intensity, int duration ) {
            ValidateUserAndThrow( piShockUser );
            ValidateIntensityAndThrow( intensity );

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

            if( response.IsSuccessStatusCode && (response.Content == PiShockResponseMessages.Success || response.Content == PiShockResponseMessages.Attempt) ) {
                return new PiShockResult( true, response.Content );
            }

            return new PiShockResult( false, response.Content );
        }


        /// <summary>
        /// Gets Information about a shocker
        /// </summary>
        /// <param name="piShockUser">PiShock Credentials</param>
        /// <returns><see cref="PiShockResult"/></returns>
        public async Task<PiShockInfoResult> GetShockerInfoAsync( PiShockUser piShockUser ) {
            ValidateUserAndThrow( piShockUser );

            PiShockRequest request = new PiShockRequest {
                Username = piShockUser.Username, ApiKey = piShockUser.ApiKey, Code = piShockUser.Code, Name = DisplayName,
            };
            Logger?.LogDebug( "Sending GetInfo {@Request}", request );
            ApiResponse<PiShockInfoResult> response = await _piShockApi.GetShockerInfoAsync( request );

            if( response.IsSuccessStatusCode ) {
                return response.Content;
            }

            return null;
        }

        internal void ValidateUserAndThrow( PiShockUser piShockUser ) {
            if( piShockUser == null ) {
                throw new ArgumentNullException( nameof( piShockUser ), "PiShockUser can not be null." );
            }

            if( string.IsNullOrEmpty( piShockUser.Username ) ) {
                throw new ArgumentException( "PiShockUser.Username can not be null or empty.", nameof( piShockUser ) );
            }

            if( string.IsNullOrEmpty( piShockUser.ApiKey ) ) {
                throw new ArgumentException( "PiShockUser.ApiKey can not be null or empty.", nameof( piShockUser ) );
            }

            if( string.IsNullOrEmpty( piShockUser.Code ) ) {
                throw new ArgumentException( "PiShockUser.Code can not be null or empty.", nameof( piShockUser ) );
            }
        }

        internal void ValidateIntensityAndThrow( int intensity ) {
            if( intensity < 0 || intensity > 100 ) {
                throw new ArgumentOutOfRangeException( nameof( intensity ), intensity, "Intensity must be between 0 and 100" );
            }
        }
    }
}