using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComissioner
{
    public static class ImageUtils
    {
        public static readonly string[] SupportedExtensions = { ".bmp", ".jpg", ".jpeg", ".png", ".gif", ".tiff", ".tif", ".ico" };
        public static readonly int MaxImageCount = 2500;
        // Function to retrieve image paths from a directory (with optional recursion)
        public static string[] GetImagePaths(string folderPath, bool includeSubfolders)
        {
            List<string> imagePaths = new List<string>();

            try
            {
                SearchImages(folderPath, includeSubfolders, imagePaths);

                // Limit results to 3000 taggedImages
                if (imagePaths.Count > MaxImageCount)
                {
                    imagePaths = imagePaths.GetRange(0, MaxImageCount);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scanning folder: {ex.Message}");
            }

            return imagePaths.ToArray();
        }

        private static void SearchImages(string folderPath, bool includeSubfolders, List<string> imagePaths)
        {
            if (!Directory.Exists(folderPath)) return;

            foreach (string file in Directory.GetFiles(folderPath))
            {
                if (imagePaths.Count >= MaxImageCount) return; // Stop if limit is reached

                string extension = Path.GetExtension(file).ToLower();
                if (Array.Exists(SupportedExtensions, ext => ext == extension))
                {
                    imagePaths.Add(file);
                }
            }

            if (includeSubfolders)
            {
                foreach (string subfolder in Directory.GetDirectories(folderPath))
                {
                    if (imagePaths.Count >= MaxImageCount) return; // Stop if limit is reached
                    SearchImages(subfolder, includeSubfolders, imagePaths);
                }
            }
        }

    }
}
