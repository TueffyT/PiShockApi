namespace PiShockApi.Tests;

public class ValidateUserTest : IClassFixture<PiShockFixture> {
    public static IEnumerable<object[]> GetTestUsers() {
        yield return new object[] {
            new PiShockUser()
        };
        yield return new object[] {
            new PiShockUser() {
                ApiKey = "123"
            }
        };
        yield return new object[] {
            new PiShockUser() {
                ApiKey = "123", Code = "Code123"
            }
        };
        yield return new object[] {
            new PiShockUser() {
                ApiKey = "123", Username = "TestUsername"
            }
        };
        yield return new object[] {
            new PiShockUser() {
                Code = "123", Username = "TestUsername"
            }
        };
    }

    private PiShockFixture _piShockFixture;

    public ValidateUserTest( PiShockFixture piShockFixture ) {
        _piShockFixture = piShockFixture;
    }
    
    [Fact]
    public void TestThrowInvalidUserWhenNull() {
        Assert.Throws<ArgumentNullException>( () => _piShockFixture.ApiClient.ValidateUserAndThrow( null ) );
    }

    [Theory]
    [MemberData( nameof( GetTestUsers ) )]
    public void TestThrowInvalidUserWhenInvalid( PiShockUser user ) {
        Assert.Throws<ArgumentException>( () => _piShockFixture.ApiClient.ValidateUserAndThrow( user ) );
    }

    [Fact]
    public void TestValidUser() {
        Exception? ex = Record.Exception( () => _piShockFixture.ApiClient.ValidateUserAndThrow( new PiShockUser() {
            ApiKey = "123", Code = "Code123", Username = "TestUsername"
        } ) );
        Assert.Null( ex );
    }
}