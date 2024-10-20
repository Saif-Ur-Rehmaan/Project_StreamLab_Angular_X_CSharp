using Api.CORE.Models.TvShow;

namespace Api.REPOSITORY.Interfaces
{
    public interface ITvShowEpisodeRepository
    {

        public IEnumerable<TvShowEpisode> GetTvShowEpisodes();

        public TvShowEpisode FindTvShowEpisode(int id);

        public TvShowEpisode CreateTvShowEpisode(TvShowEpisode TvShowEpisode);

        public TvShowEpisode UpdateTvShowEpisode(int id, TvShowEpisode TvShowEpisode);

        public TvShowEpisode DeleteTvShowEpisode(TvShowEpisode TvShowEpisode);
    }
}
