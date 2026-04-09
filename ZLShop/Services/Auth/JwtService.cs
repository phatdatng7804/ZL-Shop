using ZLShop.Models.Entities;
using ZLShop.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ZLShop.Services.Auth;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(User user);
}

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public JwtService(IConfiguration configuration, AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public async Task<string> GenerateTokenAsync(User user)
    {
        // Query permissions for the user's role
        var permissionCodes = await _context.RolePermissions
            .Where(rp => rp.RoleId == user.RoleId && rp.IsEnabled && !rp.IsDeleted)
            .Include(rp => rp.Permission)
            .Where(rp => rp.Permission != null && !rp.Permission.IsDeleted)
            .Select(rp => rp.Permission!.Code)
            .ToListAsync();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("name", user.Username ?? ""),
            new(ClaimTypes.Role, user.Role?.Name ?? "User"),
            new("permissions", string.Join(",", permissionCodes))
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "default_key_change_in_prod"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
