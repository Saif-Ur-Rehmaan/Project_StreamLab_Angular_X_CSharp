using Api.CORE;
using Api.CORE.Models.TvShow;
using Api.REPOSITORY.Interfaces;

namespace Api.REPOSITORY.Reposotories
{
    public class TvShowRepository (StreamLabContext e): ITvShowRepository
    {
        protected StreamLabContext _entities = e;
        public TvShow CreateTvShow(TvShow TvShow)
        {
            _entities.TvShows.Add(TvShow);
            _entities.SaveChanges();
            return TvShow;
        }

        public TvShow DeleteTvShow(TvShow TvShow)
        {
            _entities.TvShows.Remove(TvShow);
            _entities.SaveChanges();
            return TvShow;
        }

        public TvShow FindTvShow(int id)
        {
            return _entities.TvShows.Find(id) ?? throw new Exception("Tv Show Not Found");
        }

        public IEnumerable<TvShow> GetTvShows()
        {
            return _entities.TvShows.ToList();
        }

        public TvShow UpdateTvShow(int id, TvShow updatedTvShow)
        {

            var existingTvShow =FindTvShow(id); 

            existingTvShow.Category = updatedTvShow.Category; 
            existingTvShow.Title = updatedTvShow.Title;
            existingTvShow.Thumbnail = updatedTvShow.Thumbnail;
            existingTvShow.TvShowDescription = updatedTvShow.TvShowDescription;
             
            _entities.SaveChanges();

            return existingTvShow;
        }
    }
}
