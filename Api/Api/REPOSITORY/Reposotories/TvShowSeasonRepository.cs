using Api.CORE;
using Api.CORE.Models.TvShow;
using Api.REPOSITORY.Interfaces;

namespace Api.REPOSITORY.Reposotories
{
    public class TvShowSeasonRepository(StreamLabContext entities):ITvShowSeasonRepository
    {
        protected StreamLabContext _entities = entities;

        public TvShowSeason CreateTvShowSeason(TvShowSeason TvShowSeason)
        {
            var entity=_entities.TvShowSeasons.Add(TvShowSeason);
            _entities.SaveChanges();
            return entity.Entity;
        }

        public TvShowSeason DeleteTvShowSeason(TvShowSeason TvShowSeason)
        {
            _entities.TvShowSeasons.Remove(TvShowSeason);
            _entities.SaveChanges();
            return TvShowSeason;
        }

        public TvShowSeason? FindTvShowSeason(int id)
        {
            var tss = _entities.TvShowSeasons.Find(id) ;
            return tss;
        }

        public IEnumerable<TvShowSeason> GetTvShowSeasons()
        {
            return [.. _entities.TvShowSeasons];
        }
        public TvShowSeason UpdateTvShowSeason(int id, TvShowSeason updatedTvShowSeason)
        {
            var existingTvShowSeason = FindTvShowSeason(id);
            if (existingTvShowSeason != null)
            {
                existingTvShowSeason.Name = updatedTvShowSeason.Name;
                existingTvShowSeason.SeasonNumber = updatedTvShowSeason.SeasonNumber;
                existingTvShowSeason.SeasonDescription = updatedTvShowSeason.SeasonDescription;
             
                _entities.SaveChanges();

            }

            // Return the updated entity
            return updatedTvShowSeason;
        }
    }
}
