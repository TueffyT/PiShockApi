using Microsoft.Extensions.Configuration;

namespace PiShockApi.Tests {
    public class ApiClientTest : IClassFixture<PiShockFixture> {
        private PiShockFixture _piShockFixture;

        public ApiClientTest( PiShockFixture piShockFixture ) {
            _piShockFixture = piShockFixture;
        }

        [Fact]
        public async Task SendShockTestValid() {
            await Task.Delay( 500 );
            PiShockResult result = await _piShockFixture.ApiClient.SendShockAsync( _piShockFixture.PiShockUser, 10, 1 );
            Assert.True( result.IsSuccessful, result.Message );
        }

        [Fact]
        public async Task SendVibeTestValid() {
            await Task.Delay( 500 );
            PiShockResult result = await _piShockFixture.ApiClient.SendVibrationAsync( _piShockFixture.PiShockUser, 10, 1 );
            Assert.True( result.IsSuccessful, result.Message );
        }

        [Fact]
        public async Task SendMiniShockTestValid() {
            await Task.Delay( 500 );
            PiShockResult result = await _piShockFixture.ApiClient.SendMiniShockAsync( _piShockFixture.PiShockUser, 10 );
            Assert.True( result.IsSuccessful, result.Message );
        }

        [Fact]
        public async Task SendBeepTestValid() {
            await Task.Delay( 500 );
            PiShockResult result = await _piShockFixture.ApiClient.SendBeepAsync( _piShockFixture.PiShockUser, 10, 3 );
            Assert.True( result.IsSuccessful, result.Message );
        }

        [Fact]
        public async Task GetInfoTestValid() {
            await Task.Delay( 500 );
            PiShockInfoResult? result = await _piShockFixture.ApiClient.GetShockerInfoAsync( _piShockFixture.PiShockUser );
            Assert.NotNull( result );
        }
    }
}