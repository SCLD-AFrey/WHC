// See https://aka.ms/new-console-template for more information

using WHC.CommonLibrary.Interfaces;
using WHC.CommonLibrary.Models;
using WHC.CommonLibrary.Models.Login;
using WHC.CommonLibrary.Services;

// for (var i = 0; i < 10; i++)
// {
//     Console.WriteLine(PasswordGenerator.GenerateReadablePassword());
// }


var encryptor = new EncryptionService();
var config = new ClientConfigurationService();
var userService = new UserService();
userService.InitUsers();


var u = new User(1);

var attempt = userService.Login(new LoginAttempt()
{
    UserName = "admin",
    Password = "password"
});

switch (attempt)
{
    case FailedLoginAttempt failedAttempt:
        Console.WriteLine(failedAttempt.FailMessage);
        break;
    case SuccessfulLoginAttempt goodAttempt:
        Console.WriteLine(goodAttempt.User!.ToString());
        break;
}



