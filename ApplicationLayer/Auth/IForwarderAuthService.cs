public interface IForwarderAuthService
{
    Task<string> Login(string email,string password);
    Task<bool> Register(string name,string surname,string email,string password);
}