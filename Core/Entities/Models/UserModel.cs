namespace Core.Entities.Models
{
    public class UserModel : UserLogin
    {
        public string Email { get; set; }
        public string Role { get; set; }
    }

    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }

    public class UserInfo
    {
        public static List<UserModel> users = new List<UserModel>()
        {
            new UserModel(){ UserName = "admin", Password = "123", Email = "akm.william2021@gmail.com", Role = "Administrator"},
            new UserModel(){ UserName = "akm", Password = "123", Email = "akm.william2021@gmail.com", Role = "User"}
        };
    }

    public class RefreshTokenInfo
    {
        public static string key = "This is the key to refresh token";
    }
}
