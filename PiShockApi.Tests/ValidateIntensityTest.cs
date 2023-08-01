namespace PiShockApi.Tests {
    public class ValidateIntensityTest : IClassFixture<PiShockFixture> {
        
        private PiShockFixture _piShockFixture;

        public ValidateIntensityTest( PiShockFixture piShockFixture ) {
            _piShockFixture = piShockFixture;
        }
        
        [Theory]
        [InlineData( 1 )]
        [InlineData( 20 )]
        [InlineData( 100 )]
        [InlineData( 0 )]
        public void ValidateValidIntensity( int intensity ) {
            Exception? ex = Record.Exception( () => _piShockFixture.ApiClient.ValidateIntensityAndThrow( intensity ) );
            Assert.Null( ex );
        }


        [Theory]
        [InlineData( -1 )]
        [InlineData( -10 )]
        [InlineData( 101 )]
        public void ValidateInvalidIntensity( int intensity ) {
            Assert.Throws<ArgumentOutOfRangeException>( () => _piShockFixture.ApiClient.ValidateIntensityAndThrow( intensity ) );
        }
    }
}