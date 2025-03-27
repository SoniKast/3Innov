using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AdminInterface.Server.Models;
using AdminInterface.Server;
using Org.BouncyCastle.Crypto.Generators;
using System.ComponentModel.DataAnnotations;


[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(ApplicationDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Vérifie si l'utilisateur existe en base
        var user = await _context.Utilisateur.FirstOrDefaultAsync(u => u.Email == request.Email);

        // Vérification directe du mot de passe (PAS SÉCURISÉ, uniquement pour test)
        if (user == null || user.Mot_de_pass != request.MotDePasse)
        {
            return Unauthorized("Email ou mot de passe invalide");
        }

        var token = GenerateJwtToken(user);
        return Ok(new
        {
            token,
            typeUtilisateur = user.Type // Assurez-vous que cette colonne existe dans la DB });
        });
    }

    private string GenerateJwtToken(Utilisateur user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.ID_Utilisateur.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("TypeUtilisateur", user.Type)
        };

        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string MotDePasse { get; set; }
}
