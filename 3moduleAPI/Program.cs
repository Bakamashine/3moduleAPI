using _3moduleAPI;
using _3moduleAPI.Contracts.Repository;
using _3moduleAPI.Interfaces;
using _3moduleAPI.Repository;
using _3moduleAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateSlimBuilder(args);

//builder.Services.ConfigureHttpJsonOptions(options =>
//{
//    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
//});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddSingleton<IPasswordHasherService, PasswordHashService>();
builder.Services.AddSingleton<JwtOptions>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

builder.Logging.AddConsole();
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, policy => { policy.WithOrigins("http://localhost:5173"); });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new JwtOptions().GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddSignalR();
#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
builder.Services.AddControllers();
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(setup =>
// {
//     
//     // var jwtSecurityScheme = new OpenApiSecurityScheme
//     // {
//     //     BearerFormat = "JWT",
//     //     Name = "JWT Auth",
//     //     In = ParameterLocation.Header,
//     //     Type = SecuritySchemeType.Http,
//     //     Scheme =JwtBearerDefaults.AuthenticationScheme,
//     //     // Reference = new OpenApiReference
//     //     // {
//     //     //     Id = JwtBearerDefaults.AuthenticationScheme,
//     //     //     Type = ReferenceType.SecurityScheme
//     //     // }
//     // };
//     // setup.AddSecurityDefinition("Bearer", jwtSecurityScheme);
//     // setup.AddSecurityRequirement(new OpenApiSecurityRequirement
//     // {
//     //     {
//     //         jwtSecurityScheme,
//     //         Array.Empty<string>()
//     //     }
//     // });
// });
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);


const string debugUrl = "http://localhost:5018";
app.Run(debugUrl);