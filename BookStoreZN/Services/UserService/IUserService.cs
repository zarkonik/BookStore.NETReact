namespace BookStoreZN.Services.UserService
{
    public interface IUserService
    {
        void Login();
        void Logout();
        void Register(string email, string password);
    }
}
