using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Example appsettings.json snippet:
// {
//   "Jwt": {
//     "Key": "super_secret_long_key_here_change_in_production",
//     "Issuer": "MyApi",
//     "Audience": "MyApiClient",
//     "ExpiryMinutes": 60
//   }
// }

// 1) Bind Jwt settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>() ?? new JwtSettings();

// 2) Add authentication services
var keyBytes = Encoding.UTF8.GetBytes(jwtSettings.Key);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = !string.IsNullOrEmpty(jwtSettings.Issuer),
        ValidIssuer = jwtSettings.Issuer,
        ValidateAudience = !string.IsNullOrEmpty(jwtSettings.Audience),
        ValidAudience = jwtSettings.Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(30)
    };
});

// 3) Add authorization and controllers
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Add JWT bearer authorization to Swagger UI
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // IMPORTANT: authentication before authorization
app.UseAuthorization();

app.MapControllers();

// 4) Minimal token issuance endpoint (demo only)
//    Replace credential validation with real user store and hashing in production.
app.MapPost("/token", (UserCredentials creds) =>
{
    if (creds is null)
        return Results.BadRequest();

    // Demo validation: replace with secure validation
    if (creds.Username != "alice" || creds.Password != "password")
        return Results.Unauthorized();

    var claims = new[]
    {
        new Claim(ClaimTypes.Name, creds.Username),
        new Claim("role", "User") // add claims as needed
    };

    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: jwtSettings.Issuer,
        audience: jwtSettings.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
        signingCredentials: signingCredentials
    );

    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

    return Results.Ok(new
    {
        access_token = tokenString,
        token_type = "Bearer",
        expires_in = jwtSettings.ExpiryMinutes * 60
    });
});

app.Run();

// Supporting types
public record JwtSettings
{
    public string Key { get; init; } = "change_this_in_production";
    public string Issuer { get; init; } = "";
    public string Audience { get; init; } = "";
    public int ExpiryMinutes { get; init; } = 60;
}

public record UserCredentials(string Username, string Password);

// Example protected controller (put in Controllers folder in a real project):
/*
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet("public")]
    public IActionResult Public() => Ok("no auth required");

    [Authorize]
    [HttpGet("protected")]
    public IActionResult Protected() => Ok($"hello {User.Identity?.Name}");
}
*/

// Production notes:
// - Store the Jwt:Key securely (environment variables, Azure Key Vault). Do not check secrets into source control.
// - Use strong, sufficiently long keys (e.g. 256-bit for HMAC-SHA256).
// - Use HTTPS always.
// - Consider refresh tokens for long sessions; implement proper revocation if needed.
// - Validate claims/roles via policies or [Authorize(Roles = "Admin")].
// - Monitor token lifetime and rotate keys when necessary.
