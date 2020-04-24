using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Collections.Generic;

namespace CC0TexturesDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration configuration;

            try
            {
                configuration = new Configuration(
                    CmdParser.ParseAssets(args), 
                    CmdParser.ParseDownloadTypes(args));
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return;
            }

            try
            {
                var client = new WebClient();

                // Download the JSON.
                dynamic jsonObject = JsonConvert.DeserializeObject(client.DownloadString("https://cc0textures.com/api/v1/full_json?sort=Popular"));

                foreach (var asset in jsonObject.Assets)
                {
                    // If there are no assets defined, then go through all assets.
                    // If there are assets, then check if the asset is mentioned there and if so, then download it.
                    if (!configuration.Assets.Any() || configuration.Assets.Any(a => asset.Name == a))
                    {
                        foreach (var download in asset.Value.Downloads)
                        {
                            // If the download is a zip file and the download type is 
                            // mentioned in the configuration, then download it.
                            if (DownloadTypeMapper.TryMap(download.Name, out DownloadType downloadType))
                            {
                                if (download.Value.Filetype == "zip" && configuration.DownloadTypes.Any(t => t == downloadType))
                                {
                                    // Prepare paths.
                                    var path = Path.Combine(asset.Name, download.Name);
                                    var zipFile = Path.Combine(path, "tmp.zip");

                                    // Prepare directory.
                                    if (Directory.Exists(path)) Directory.Delete(path, true);
                                    Directory.CreateDirectory(path);

                                    // Download data.
                                    var downloadedData = client.DownloadData(download.Value.RawDownloadLink.Value);

                                    // Write to disk, unpack and delete zip file.
                                    File.WriteAllBytes(zipFile, downloadedData);
                                    ZipFile.ExtractToDirectory(zipFile, path);
                                    File.Delete(zipFile);

                                    Console.WriteLine($"Downloaded {asset.Name} {download.Name}: {downloadedData.Length / 1000000} MB");
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
