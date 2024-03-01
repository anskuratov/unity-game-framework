using System.IO;
using UnityEngine;

namespace AS.Framework.Utils
{
    public static class PathUtils
    {
        public static string GetStreamingAssetsPath(string fileNameWithExtension)
        {
            return Path.Combine(Application.streamingAssetsPath, fileNameWithExtension);
        }

        public static string GetStreamingAssetsPath(string fileName, string extension)
        {
            return Path.Combine(Application.streamingAssetsPath, string.Format("{0}.{1}", fileName, extension)); 
        }
    }
}