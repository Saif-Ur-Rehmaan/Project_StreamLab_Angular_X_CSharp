using Api.CORE.Models.TvShowModels;

namespace Api.REPOSITORY.Interfaces.TvShowInterfaces
{
    public interface ITvShowEpisodeRepository
    {

        public IEnumerable<TvShowEpisode> GetTvShowEpisodes();

        public TvShowEpisode? FindTvShowEpisode(int id);

        public TvShowEpisode CreateTvShowEpisode(TvShowEpisode TvShowEpisode);

        public TvShowEpisode UpdateTvShowEpisode(int id, TvShowEpisode TvShowEpisode);

        public TvShowEpisode DeleteTvShowEpisode(TvShowEpisode TvShowEpisode);
    }
}
