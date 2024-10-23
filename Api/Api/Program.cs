
using Api.CORE;
using Api.CORE.Constants;
using Api.REPOSITORY.Interfaces;
using Api.REPOSITORY.Interfaces.MovieInterfaces;
using Api.REPOSITORY.Interfaces.TvShowInterfaces;
using Api.REPOSITORY.Reposotories;
using Api.REPOSITORY.Reposotories.MovieRepositories;
using Api.REPOSITORY.Reposotories.TvShowRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
         
            // Add services to the container.


            builder.Services.AddControllers();
            builder.Services.AddDbContext<StreamLabContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CSharp_StreamLab")));

            // Injecting  the repositories using AddScoped  
            builder.Services.AddScoped<IMovieRepository,MovieRepository>();
            builder.Services.AddScoped<IMovieCategoryRepository,MovieCategoryRepository>();

            builder.Services.AddScoped<ITvShowRepository,TvShowRepository>();
            builder.Services.AddScoped<ITvShowCategoryRepository, TvShowCategoryRepository>();
            builder.Services.AddScoped<ITvShowEpisodeRepository, TvShowEpisodeRepository>();
            builder.Services.AddScoped<ITvShowSeasonRepository, TvShowSeasonRepository>();

            builder.Services.AddScoped<IPricingRepository,PricingRepository>();
            builder.Services.AddScoped<IPurchasedPackegeRepository,PurchasedPackegeRepository>();
            builder.Services.AddScoped<IRoleRepository,RoleRepository>();
            builder.Services.AddScoped<IUserRepository,UserRepository>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            } 
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, PathConstants.StaticFileServingFolderName)),
                RequestPath = PathConstants.RequestPath
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
