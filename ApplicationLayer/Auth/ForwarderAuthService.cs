using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class ForwarderAuthService : IForwarderAuthService
{
    private readonly IForwarderRepository _forwarders;

    public ForwarderAuthService(IForwarderRepository forwarders, IConfiguration configuration)
    {
        _forwarders = forwarders;
    }

    private string GenerateJwtToken(Forwarder forwarder)
    {
        var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: new List<Claim>()
            {
                new Claim("sub",forwarder.Email),
                new Claim("name",forwarder.Name),
            },

            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }


    public async Task<string> Login(string email, string password)
    {
        Forwarder forwarder  = await _forwarders.GetAsyncByEmail(email);
        
        if (forwarder == null)
        {
            return null;
        }

        bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, forwarder.Password);

        if(!isValidPassword){
            return null;
        }

        return  GenerateJwtToken(forwarder);
    }

    public async Task<bool> Register(string name,string surname,string email, string password)
    {
        Forwarder existingForwarder = await _forwarders.GetAsyncByEmail(email);
        password = BCrypt.Net.BCrypt.HashPassword(password);

        if(existingForwarder != null)
        {
             return false;
        }

        var forwarder = new Forwarder()
        {
            Name = name,
            Surname = surname,
            Email = email,
            Password = password
        };

        
        await _forwarders.AddAsync(forwarder);
        
        return true;
    }
}