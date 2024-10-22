using Api.CORE.Models;
using Api.CORE.Models.TvShowModels;

namespace Api.REPOSITORY.Interfaces.TvShowInterfaces
{
    public interface ITvShowCategoryRepository
    {
        public IEnumerable<TvShowCategory> GetTvShowCategories();

        public TvShowCategory? FindTvShowCategory(int id);

        public TvShowCategory CreateTvShowCategory(TvShowCategory tvShowCategory);

        public TvShowCategory UpdateTvShowCategory(int id, TvShowCategory tvShowCategory);

        public TvShowCategory DeleteTvShowCategory(TvShowCategory tvShowCategory);
    }
}
