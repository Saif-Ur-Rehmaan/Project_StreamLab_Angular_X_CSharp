using Api.CORE.Models.TvShowModels;

namespace Api.REPOSITORY.Interfaces.TvShowInterfaces
{
    public interface ITvShowRepository
    {
        public IEnumerable<TvShow> GetTvShows();

        public TvShow? FindTvShow(int id);

        public TvShow CreateTvShow(TvShow TvShow);

        public TvShow UpdateTvShow(int id, TvShow TvShow);

        public TvShow DeleteTvShow(TvShow TvShow);
    }
}
