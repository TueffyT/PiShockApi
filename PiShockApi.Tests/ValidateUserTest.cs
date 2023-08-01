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
                ApiKey = "123", Code = "abcd"
            }
        };
        yield return new object[] {
            new PiShockUser() {
                ApiKey = "123", Username = "TestUsername"
            }
        };
    }

    [Fact]
    public void TestThrowInvalidUserWhenNull() {
        PiShockApiClient apiClient = new PiShockApiClient();
        Assert.Throws<ArgumentNullException>( () => apiClient.ValidateUserAndThrow( null ) );
    }

    [Theory]
    [MemberData( nameof( GetTestUsers ) )]
    public void TestThrowInvalidUserWhenInvalid( PiShockUser user ) {
        PiShockApiClient apiClient = new PiShockApiClient();
        Assert.Throws<ArgumentException>( () => apiClient.ValidateUserAndThrow( user ) );
    }

    [Fact]
    public void TestValidUser() {
        PiShockApiClient apiClient = new PiShockApiClient();
        var ex = Record.Exception( () => apiClient.ValidateUserAndThrow( new PiShockUser() {
            ApiKey = "123", Code = "Code123", Username = "TestUsername"
        } ) );
        Assert.Null( ex );
    }
}