using Api.CORE;
using Api.CORE.Models.TvShow;
using Api.REPOSITORY.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.REPOSITORY.Reposotories
{
    public class TvShowRepository (StreamLabContext e): ITvShowRepository
    {
        protected StreamLabContext _entities = e;
        public TvShow CreateTvShow(TvShow TvShow)
        {
             var entity = _entities.TvShows.Add(TvShow);
            _entities.SaveChanges();
            return entity.Entity;
        }

        public TvShow DeleteTvShow(TvShow TvShow)
        {
            _entities.TvShows.Remove(TvShow);
            _entities.SaveChanges();
            return TvShow;
        }

        public TvShow? FindTvShow(int id)
        {
            return _entities.TvShows.Include(x => x.Category).FirstOrDefault(x=>x.Id==id)  ;
        }

        public IEnumerable<TvShow> GetTvShows()
        {
            return [.. _entities.TvShows.Include(x => x.Category)];
        }

        public TvShow UpdateTvShow(int id, TvShow updatedTvShow)
        {

            var existingTvShow =FindTvShow(id);
            if (existingTvShow!=null)
            {
                existingTvShow.Category = updatedTvShow.Category; 
                existingTvShow.Title = updatedTvShow.Title;
                existingTvShow.Thumbnail = updatedTvShow.Thumbnail;
                existingTvShow.TvShowDescription = updatedTvShow.TvShowDescription;
             
                _entities.SaveChanges();

            }

            return updatedTvShow;
        }
    }
}
