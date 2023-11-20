// See https://aka.ms/new-console-template for more information

using WHC.CommonLibrary.Models.Login;
using WHC.CommonLibrary.Services;

// for (var i = 0; i < 10; i++)
// {
//     Console.WriteLine(PasswordGenerator.GenerateReadablePassword());
// }
var userService = new UserService();

userService.InitUsers();

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



