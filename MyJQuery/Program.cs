namespace MyJQuery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors();
            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.UseDefaultFiles();
            
            app.UseStaticFiles();
            
            app.UseAuthentication();
            
            app.UseAuthorization();
            
            app.MapControllers();
            
            app.Run();
        }
    }
}