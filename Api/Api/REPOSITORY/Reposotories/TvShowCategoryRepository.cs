using Api.CORE.Models;
using Api.CORE;
using Api.REPOSITORY.Interfaces;
using Api.CORE.Models.TvShow;

namespace Api.REPOSITORY.Reposotories
{
    public class TvShowCategoryRepository(StreamLabContext entities) : ITvShowCategoryRepository
    {
        protected StreamLabContext _entities = entities;

        public TvShowCategory CreateTvShowCategory(TvShowCategory tvShowCategory)
        {
            _entities.TvShowCategories.Add(tvShowCategory);
            _entities.SaveChanges();
            return tvShowCategory;
        }

        public TvShowCategory DeleteTvShowCategory(TvShowCategory tvShowCategory)
        {
            _entities.TvShowCategories.Remove(tvShowCategory);
            _entities.SaveChanges();
            return tvShowCategory;
        }

        public TvShowCategory FindTvShowCategory(int id)
        {
            var tvshow = _entities.TvShowCategories.Find(id);

            return tvshow ?? throw new Exception("Not Found");
        }

        public IEnumerable<TvShowCategory> GetTvShowCategories()
        {
            return  _entities.TvShowCategories.ToList();
        }

        public TvShowCategory UpdateTvShowCategory(int id, TvShowCategory tvShowCategory)
        {
            var tvc = FindTvShowCategory(id);
            tvc.Name=tvShowCategory.Name;
            _entities.SaveChanges();

            return tvShowCategory;
        }
    }
}
