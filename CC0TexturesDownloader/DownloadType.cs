using System;

namespace CC0TexturesDownloader
{
    /// <summary>
    /// Download types.
    /// </summary>
    public enum DownloadType
    {
        None,
        Jpg2k,
        Jpg4k,
        Jpg8k,
        Jpg16k,
    }

    public static class DownloadTypeMapper
    {
        /// <summary>
        /// Map text to download type.
        /// </summary>
        public static bool TryMap(string text, out DownloadType downloadType)
        {
            switch (text.Trim().ToLowerInvariant())
            {
                case "2k-jpg":
                    downloadType = DownloadType.Jpg2k;
                    return true;

                case "4k-jpg":
                    downloadType = DownloadType.Jpg4k;
                    return true;

                case "8k-jpg":
                    downloadType = DownloadType.Jpg8k;
                    return true;

                case "16k-jpg":
                    downloadType = DownloadType.Jpg16k;
                    return true;

                default:
                    downloadType = DownloadType.None;
                    return false;
            }
        }
    }
}
