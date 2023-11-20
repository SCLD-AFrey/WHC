namespace WHC.CommonLibrary.Models.UserInfo;

public class CurrentUser : User
{
    public DateTime LastLogin { get; set; } = DateTime.Now;
}