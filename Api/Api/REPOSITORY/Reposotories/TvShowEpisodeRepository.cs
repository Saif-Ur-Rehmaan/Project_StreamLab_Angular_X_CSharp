using Api.CORE;
using Api.CORE.Models.TvShow;
using Api.REPOSITORY.Interfaces;

namespace Api.REPOSITORY.Reposotories
{
    public class TvShowEpisodeRepository(StreamLabContext entities) : ITvShowEpisodeRepository
    {
        protected StreamLabContext _entities = entities;
         
        public TvShowEpisode CreateTvShowEpisode(TvShowEpisode tvShowEpisode)
        {
            _entities.TvShowEpisodes.Add(tvShowEpisode);  
            _entities.SaveChanges();  
            return tvShowEpisode;  
        }
         
        public TvShowEpisode DeleteTvShowEpisode(TvShowEpisode tvShowEpisode)
        {
            _entities.TvShowEpisodes.Remove(tvShowEpisode); 
            _entities.SaveChanges();  
            return tvShowEpisode;  
        }

        // Find a TvShowEpisode by id
        public TvShowEpisode FindTvShowEpisode(int id)
        {
            return _entities.TvShowEpisodes.Find(id) ?? throw new Exception("TvShowEpisode Not Found");
        }

        // Get all TvShowEpisodes
        public IEnumerable<TvShowEpisode> GetTvShowEpisodes()
        {
            return _entities.TvShowEpisodes.ToList(); // Retrieve all episodes
        }

        // Update an existing TvShowEpisode
        public TvShowEpisode UpdateTvShowEpisode(int id, TvShowEpisode updatedTvShowEpisode)
        {
            // Find the existing episode
            var existingTvShowEpisode = FindTvShowEpisode(id);

            // Update the properties of the existing episode
            existingTvShowEpisode.TvShow = updatedTvShowEpisode.TvShow; // Assuming navigation property is updated
            existingTvShowEpisode.TvShowSeason = updatedTvShowEpisode.TvShowSeason; // Assuming navigation property is updated
            existingTvShowEpisode.Thumbnail = updatedTvShowEpisode.Thumbnail;
            existingTvShowEpisode.Views = updatedTvShowEpisode.Views;
            existingTvShowEpisode.RunTime = updatedTvShowEpisode.RunTime;

            // Save changes to the database
            _entities.SaveChanges();

            // Return the updated episode
            return existingTvShowEpisode;
        }
    }

}
