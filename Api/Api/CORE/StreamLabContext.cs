using Api.CORE.Models;
using Api.CORE.Models.Movie;
using Api.CORE.Models.TvShow;
using Microsoft.EntityFrameworkCore;

namespace Api.CORE
{
    public class StreamLabContext(DbContextOptions<StreamLabContext> options) : DbContext(options)
    {
        
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<PurchasedPackege> PurchasedPackeges { get; set; }

        //Movies
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<Movie> Movies { get; set; }


        //Tv Shows
        public DbSet<TvShowCategory> TvShowCategories { get; set; }
        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<TvShowSeason> TvShowSeasons { get; set; }
        public DbSet<TvShowEpisode> TvShowEpisodes { get; set; }

        
    }
}
