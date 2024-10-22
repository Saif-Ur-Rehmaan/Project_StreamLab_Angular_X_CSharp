using Api.CORE;
using Api.CORE.Models.TvShowModels;
using Api.REPOSITORY.Interfaces.TvShowInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.REPOSITORY.Reposotories.TvShowRepositories
{
    public class TvShowEpisodeRepository(StreamLabContext entities) : ITvShowEpisodeRepository
    {
        protected StreamLabContext _entities = entities;

        public TvShowEpisode CreateTvShowEpisode(TvShowEpisode tvShowEpisode)
        {
            var entity = _entities.TvShowEpisodes.Add(tvShowEpisode);
            _entities.SaveChanges();
            return entity.Entity;
        }

        public TvShowEpisode DeleteTvShowEpisode(TvShowEpisode tvShowEpisode)
        {
            _entities.TvShowEpisodes.Remove(tvShowEpisode);
            _entities.SaveChanges();
            return tvShowEpisode;
        }

        // Find a TvShowEpisode by id
        public TvShowEpisode? FindTvShowEpisode(int id)
        {
            return _entities.TvShowEpisodes.Include(x => x.TvShow).Include(x => x.TvShowSeason).FirstOrDefault(x => x.Id == id);
        }

        // Get all TvShowEpisodes
        public IEnumerable<TvShowEpisode> GetTvShowEpisodes()
        {
            return [.. _entities.TvShowEpisodes.Include(x => x.TvShow).Include(x => x.TvShowSeason)]; // Retrieve all episodes
        }

        // Update an existing TvShowEpisode
        public TvShowEpisode UpdateTvShowEpisode(int id, TvShowEpisode updatedTvShowEpisode)
        {
            // Find the existing episode
            var existingTvShowEpisode = FindTvShowEpisode(id);
            if (existingTvShowEpisode != null)
            {
                // Update the properties of the existing episode
                existingTvShowEpisode.TvShow = updatedTvShowEpisode.TvShow; // Assuming navigation property is updated
                existingTvShowEpisode.TvShowSeason = updatedTvShowEpisode.TvShowSeason; // Assuming navigation property is updated
                existingTvShowEpisode.Thumbnail = updatedTvShowEpisode.Thumbnail;
                existingTvShowEpisode.Views = updatedTvShowEpisode.Views;
                existingTvShowEpisode.RunTime = updatedTvShowEpisode.RunTime;
                // Save changes to the database
                _entities.SaveChanges();

            }
            // Return the updated episode
            return updatedTvShowEpisode;
        }
    }

}
