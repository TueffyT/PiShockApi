namespace PiShockApi.Tests;

public class ValidateUserTest {
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

    [Fact]
    public void TestThrowInvalidUserWhenNull() {
        PiShockApiClient apiClient = new();
        Assert.Throws<ArgumentNullException>( () => apiClient.ValidateUserAndThrow( null ) );
    }

    [Theory]
    [MemberData( nameof( GetTestUsers ) )]
    public void TestThrowInvalidUserWhenInvalid( PiShockUser user ) {
        PiShockApiClient apiClient = new();
        Assert.Throws<ArgumentException>( () => apiClient.ValidateUserAndThrow( user ) );
    }

    [Fact]
    public void TestValidUser() {
        PiShockApiClient apiClient = new();
        Exception? ex = Record.Exception( () => apiClient.ValidateUserAndThrow( new PiShockUser() {
            ApiKey = "123", Code = "Code123", Username = "TestUsername"
        } ) );
        Assert.Null( ex );
    }
}