using Api.CORE.Models.TvShowModels;

namespace Api.REPOSITORY.Interfaces.TvShowInterfaces
{
    public interface ITvShowSeasonRepository
    {
        public IEnumerable<TvShowSeason> GetTvShowSeasons();

        public TvShowSeason? FindTvShowSeason(int id);

        public TvShowSeason CreateTvShowSeason(TvShowSeason TvShowSeason);

        public TvShowSeason UpdateTvShowSeason(int id, TvShowSeason TvShowSeason);

        public TvShowSeason DeleteTvShowSeason(TvShowSeason TvShowSeason);
    }
}
