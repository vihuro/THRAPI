using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Design;
using System.Text;
using ThrAPI.Settings;
using System.Security.Claims;
using ThrApi.Service.JWT;
using ThrApi.Service.Login;
using ThrAPI.Interface.Login;
using ThrApi.Interface.Login;
using ThrAPI.Interface.Estoque;
using ThrApi.Service.Estoque;
using ThrAPI.Service.Estoque;
using ThrAPI.Context;
using Microsoft.EntityFrameworkCore.Proxies;
using ThrAPI.Service.Login;
using ThrApi.Service.Mapping.Estoque;
using ThrApi.Service.Mapping.Login;
using ThrAPI.Service.Mapping.Login;
using ThrAPI.Service.Mapping.Estoque;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("SistemaTHR");

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ContextBase>(options =>
    {
        options.UseNpgsql(connectionString);
        options.UseLazyLoadingProxies(true);
    });
//options.UseNpgsql(connectionString)
//.UseLazyLoadingProxies(true));


//Mappings
builder.Services.AddAutoMapper(x =>
{
    //Estoque
    x.AddProfile(typeof(MovimentacaoMapping));
    x.AddProfile(typeof(ProdutoEstoqueMapping));
    x.AddProfile(typeof(IdentificaoMaterialMapping));

    //Login
    x.AddProfile(typeof(ClaimsMapping));
    x.AddProfile(typeof(ClaimTypeMapping));
}
);

//Interfaces

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IClaimsService, ClaimsService>();
builder.Services.AddScoped<ICreateTokenService, CreateToken>();
builder.Services.AddScoped<IEstoqueService, EstoqueService>();
builder.Services.AddScoped<IiDentificaoMaterialService, IdentificacaoMaterialService>();
builder.Services.AddScoped<IMovimentacaoEstoqueService, MovimentacaoService>();
builder.Services.AddScoped<ILocalEstocagemService,LocaisEstocagemService>();
builder.Services.AddScoped<IClaimsTypeService, ClaimsTypeService>();

//JWT

var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);

var appSettings = appSettingSection.Get<AppSettings>();

var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false

    };
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddPolicy("corsPolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.Run();
