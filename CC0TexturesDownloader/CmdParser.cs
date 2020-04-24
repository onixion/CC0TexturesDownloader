using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CC0TexturesDownloader
{
    public static class CmdParser
    {
        /// <summary>
        /// Parse assets.
        /// </summary>
        public static IEnumerable<string> ParseAssets(string[] args)
        {
            if (!TryFindParameter(args, "assets", out string argument))
                return new string[0];

            if (!File.Exists(argument))
                throw new FileNotFoundException($"File not found: {argument}.");

            return File.ReadAllText(argument).Split(Environment.NewLine);
        }

        /// <summary>
        /// Parse download types.
        /// </summary>
        public static IEnumerable<DownloadType> ParseDownloadTypes(string[] args)
        {
            if (TryFindParameter(args, "downloads", out string argument))
            {
                string[] downloadTypes = argument.Split(',');

                foreach (string downloadType in downloadTypes)
                {
                    if (!DownloadTypeMapper.TryMap(downloadType, out DownloadType type))
                        throw new Exception($"Download type {downloadType} unknown.");

                    yield return type;
                }
            }
        }

        static bool TryFindParameter(string[] args, string parameterName, out string argument)
        {
            foreach(var arg in args)
            {
                if (arg.StartsWith($"--{parameterName}="))
                {
                    argument = arg.Replace($"--{parameterName}=", "");
                    return true;
                }
            }

            argument = null;
            return false;
        }
    }
}
