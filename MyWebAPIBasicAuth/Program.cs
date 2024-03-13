using MyWebAPIBasicAuth.Auth;
using Microsoft.AspNetCore.Authentication;

namespace MyWebAPIBasicAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(); // добавляем сервисы CORS

            builder.Services.AddControllers();
            
            builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuth>("BasicAuthentication", null);

            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .WithMethods("POST"));

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            //app.UseHttpsRedirection();
            //var options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("Html/Index.html");
            //app.UseDefaultFiles(options);

            //app.UseStaticFiles();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
