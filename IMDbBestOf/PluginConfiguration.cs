using MediaBrowser.Model.Plugins;

namespace IMDbBestOf
{
    public enum MetadataSource
    {
        IMDb,
        // Additional metadata providers can be added here.
    }

    public enum RatingType
    {
        User,
        Critic
    }

    public class PluginConfiguration : BasePluginConfiguration
    {
        /// <summary>
        /// The metadata provider for fetching episode ratings.
        /// </summary>
        public MetadataSource MetadataFetcher { get; set; } = MetadataSource.IMDb;

        /// <summary>
        /// The number of top episodes to include in the generated playlist.
        /// </summary>
        public int TopEpisodeCount { get; set; } = 10;

        /// <summary>
        /// The rating type to use when ranking episodes.
        /// </summary>
        public RatingType PreferredRating { get; set; } = RatingType.User;

        /// <summary>
        /// The minimum number of votes required for an episode to be considered.
        /// </summary>
        public int MinimumVoteCount { get; set; } = 50;

        /// <summary>
        /// Whether to automatically update the playlist.
        /// </summary>
        public bool AutoGeneratePlaylist { get; set; } = true;

        /// <summary>
        /// The interval in minutes at which the playlist should refresh.
        /// </summary>
        public int RefreshIntervalMinutes { get; set; } = 60;

        /// <summary>
        /// The default playlist name format. {0} will be replaced with the show name.
        /// </summary>
        public string PlaylistName { get; set; } = "IMDb Best Of {0}";
    }
}
