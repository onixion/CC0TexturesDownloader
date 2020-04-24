using GroundWork.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace CC0TexturesDownloader
{
    /// <summary>
    /// Configuration.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Assets to download.
        /// </summary>
        public HashSet<string> Assets { get; } = new HashSet<string>();

        /// <summary>
        /// Download types.
        /// </summary>
        public IEnumerable<DownloadType> DownloadTypes { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="assets"></param>
        /// <param name="downloadTypes"></param>
        public Configuration(IEnumerable<string> assets, IEnumerable<DownloadType> downloadTypes)
        {
            assets.ForEach(str => Assets.Add(str));
            DownloadTypes = downloadTypes.ToArray();

            if (!DownloadTypes.Any())
                DownloadTypes = new DownloadType[] { DownloadType.Jpg2k };
        }
    }
}
