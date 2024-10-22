using Api.CORE.Models;
using Api.CORE;
using Api.CORE.Models.TvShowModels;
using Api.REPOSITORY.Interfaces.TvShowInterfaces;

namespace Api.REPOSITORY.Reposotories.TvShowRepositories
{
    public class TvShowCategoryRepository(StreamLabContext entities) : ITvShowCategoryRepository
    {
        protected StreamLabContext _entities = entities;

        public TvShowCategory CreateTvShowCategory(TvShowCategory tvShowCategory)
        {
            var entity = _entities.TvShowCategories.Add(tvShowCategory);
            _entities.SaveChanges();
            return entity.Entity;
        }

        public TvShowCategory DeleteTvShowCategory(TvShowCategory tvShowCategory)
        {
            _entities.TvShowCategories.Remove(tvShowCategory);
            _entities.SaveChanges();
            return tvShowCategory;
        }

        public TvShowCategory? FindTvShowCategory(int id)
        {
            var tvshow = _entities.TvShowCategories.Find(id);

            return tvshow;
        }

        public IEnumerable<TvShowCategory> GetTvShowCategories()
        {
            return [.. _entities.TvShowCategories];
        }

        public TvShowCategory UpdateTvShowCategory(int id, TvShowCategory tvShowCategory)
        {
            var tvc = FindTvShowCategory(id);
            if (tvc != null)
            {
                tvc.Name = tvShowCategory.Name;
                _entities.SaveChanges();
            }
            return tvShowCategory;
        }
    }
}
