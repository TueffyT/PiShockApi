namespace PiShockApi.Tests {
    public class ValidateIntensityTest {
        [Theory]
        [InlineData( 1 )]
        [InlineData( 20 )]
        [InlineData( 100 )]
        [InlineData( 0 )]
        public void ValidateValidIntensity( int intensity ) {
            PiShockApiClient apiClient = new();
            Exception? ex = Record.Exception( () => apiClient.ValidateIntensityAndThrow( intensity ) );
            Assert.Null( ex );
        }


        [Theory]
        [InlineData( -1 )]
        [InlineData( -10 )]
        [InlineData( 101 )]
        public void ValidateInvalidIntensity( int intensity ) {
            PiShockApiClient apiClient = new();
            Assert.Throws<ArgumentOutOfRangeException>( () => apiClient.ValidateIntensityAndThrow( intensity ) );
        }
    }
}