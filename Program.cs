using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Hospital_Management_System.Helpers;
using Microsoft.OpenApi.Models;
using Hospital_Management_System.Repository.AuthRepository;
using Hospital_Management_System.Repository.UserRepository;
using Hospital_Management_System.Services.AuthServices;
using Hospital_Management_System.Services.UserServices;
using Hospital_Management_System.Services.PatientServices;
using Hospital_Management_System.Repository.PatientRepository;
using Hospital_Management_System.Repository.AppointmentRepository;
using Hospital_Management_System.Services.AppointmentServices;
using Hospital_Management_System.Repository.RecordsRepository;
using Hospital_Management_System.Services.RecordServices;
using Hospital_Management_System.Middleware;
using Hospital_Management_System.Hubs;
using Hospital_Management_System.Repository.MessageRepository;
using Hospital_Management_System.Repository.ChatRepository;
using Hospital_Management_System.Services.MessageServices;
using Hospital_Management_System.Services.ChatServices;
using Hospital_Management_System.Services.DoctorServices;
using Hospital_Management_System.Repository.DoctorRepository;
using Hospital_Management_System.Services.DepartmentService;
using Hospital_Management_System.Repository.DepartmentRepository;
using Hospital_Management_System.Repository.VaccineRepository;
using Hospital_Management_System.Services.VaccineServices;
using Hospital_Management_System.Repository.PatientVaccineRepository;
using Hospital_Management_System.Services.PatientVaccineServices;
using Hospital_Management_System.Services.IllnessServices;
using Hospital_Management_System.Repository.IllnessRepository;
using Hospital_Management_System.Services.MedicationServices;
using Hospital_Management_System.Repository.MedicationRepository;
using Hospital_Management_System.Services.AllergyServices;
using Hospital_Management_System.Repository.AllergyRepository;
using Hospital_Management_System.Repository.PatientInformationRepository;
using Hospital_Management_System.Services.PatientInformationServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddScoped<PasswordHasher>();
builder.Services.AddScoped<JwtTokenGenerator>();



builder.Services.AddAuthentication(cfg =>
{
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            if(string.IsNullOrEmpty(accessToken) == false)
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IRecordService, RecordService>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IVaccineService, VaccineService>();
builder.Services.AddScoped<IPatientVaccineService, PatientVaccineService>();
builder.Services.AddScoped<IIllnessService, IllnessService>();
builder.Services.AddScoped<IMedicationService, MedicationService>();
builder.Services.AddScoped<IAllergyService, AllergyService>();
builder.Services.AddScoped<IPatientInformationService, PatientInformationService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IRecordRepository, RecordRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IPatientVaccineRepository, PatientVaccineRepository>();
builder.Services.AddScoped<IIllnessRepository, IllnessRepository>();
builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();
builder.Services.AddScoped<IPatientInformationRepository, PatientInformationRepository>();



builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true; //Delete this when pushing to github
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter 'Bearer' [space] and then your token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();
app.MapHub<ChatHub>("/Chat");
app.Run();
