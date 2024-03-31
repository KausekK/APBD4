using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void ValidateName_Should_Return_False_When_Missing_FirstName()
    {
        var validator = new Validator();

        var result = validator.validateName(null, "Doe");
        Assert.False(result);
    }
    [Fact]
    public void ValidateName_Should_Return_False_When_Missing_LastName()
    {
        var validator = new Validator();

        var result = validator.validateName("John", null);
        Assert.False(result);
    }
    [Fact]
    public void ValidateName_Should_Return_True()
    {
        var validator = new Validator();

        var result = validator.validateName("John", "Doe");
        Assert.True(result);
    }
    [Fact]
    public void ValidateMail_Should_Return_False_When_Mail_Not_Contain_At_And_Dot()
    {
        var validator = new Validator();

        var result = validator.validateMail("xyzgmailcom");
        Assert.False(result);
    }
    [Fact]
    public void ValidateMail_Should_Return_True_When_Mail_Contain_At()
    {
        var validator = new Validator();

        var result = validator.validateMail("xyz@com");
        Assert.True(result);
    }
    [Fact]
    public void ValidateMail_Should_Return_True_When_Mail_Contain_Dot()
    {
        var validator = new Validator();

        var result = validator.validateMail("xyz.com");
        Assert.True(result);
    }
    [Fact]
    public void ValidateDateOfBirth_Should_Return_False_When_Age_Is_Under_21()
    {
        var validator = new Validator();
        DateTime dateOfBirth = new DateTime(2009, 3, 31);
        var result = validator.validateDateOfBirth(dateOfBirth);
        Assert.False(result);
    }
    [Fact]
    public void ValidateDateOfBirth_Should_Return_True()
    {
        var validator = new Validator();
        DateTime dateOfBirth = new DateTime(2000, 1, 31);
        var result = validator.validateDateOfBirth(dateOfBirth);
        Assert.True(result);
    }
    
    [Fact]
    public void GetById_Existing_ClientId_Return_True()
    {
        var repository = new ClientRepository();
        int existingClientId = 1;
        
        var client = repository.GetById(existingClientId);
        Assert.NotNull(client); 
        Assert.Equal(existingClientId, client.ClientId);
    }

    [Fact]
    public void GetById_NonExistingClientId_ThrowsArgumentException()
    {
        var repository = new ClientRepository();
        int nonExistingClientId = 10; 

        var exception = Assert.Throws<ArgumentException>(() => repository.GetById(nonExistingClientId));
        Assert.Contains("User with id " + nonExistingClientId + " does not exist in database", exception.Message); 
    }
    
    [Fact]
    public void SetCreditLimit_Should_Return_NoCreditLimit_When_VeryImportantClient()
    {
        var user = new User();
        var client = new Client { Type = "VeryImportantClient" };
        var userCreditService = new UserCreditService();

        userCreditService.SetCreditLimit(user, client);

        Assert.False(user.HasCreditLimit);
        Assert.Equal(0, user.CreditLimit);
    }
    
}