# CC0TexturesDownloader
This console tool downloads texture assets from [CC0 Textures](https://cc0textures.com). Please support [CC0 Textures](https://cc0textures.com) and consided becoming one of their [patreons](https://www.patreon.com/cc0textures)!

# How the tool works:

`cc0texturesdownloader.exe [--downloads=<DOWNLOAD-TYPE>,<...>] [--assets=<PATH-TO-ASSETS-FILE>]`

The optional parameter '--downloads' allows to select which downloads of an asset you want. If this parameter is ommited, only the 2k-JPG bundle file will be downloaded.

DOWNLOAD-TYPE can be one of the following:
-  2k-JPG
-  4k-JPG
-  8k-JPG
- 16k-JPG

Examples: 
- `--downloads=2k-JPG,4k-JPG,8k-JPG`
- `--downloads=4k-JPG`

The optional parameter '--assets' specifies a path pointing to an assets file, where each line contains an asset name that shall be downloaded. If this parameter is ommited or the assets file is empty, then all assets will be downloaded.

The files will be written to the location of the executable!
