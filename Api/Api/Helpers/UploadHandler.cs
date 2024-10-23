using Api.CORE.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Helpers
{
    public class UploadHandler
    {
        public string[] ValidExtentions_Video { get; set; }
        public string[] ValidExtentions_Image { get; set; }
        public UploadHandler()
        {
            this.ValidExtentions_Video = [".mp4", ".avi", ".mkv", ".mov"];
            this.ValidExtentions_Image = [".jpg", ".jpeg", ".png", ".gif", ".bmp", ".svg", ".webp" ];
        }

        public  string UploadVideo(IFormFile Video)
        {
            //validating Extention
            string VideoExtention = Path.GetExtension(Video.FileName);
            if (!ValidExtentions_Video.Contains(VideoExtention)){throw new Exception($"The Video Extention {VideoExtention} is Not Valid . It should be in '{string.Join(",",ValidExtentions_Video)}'");}

            //uploading file
            string filename = Guid.NewGuid().ToString()+VideoExtention;
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), PathConstants.VideoFolderPath);
            string FolderPathWithFileName=Path.Combine(uploadsFolder, filename);
            using (var stream=new FileStream(FolderPathWithFileName,FileMode.Create))
            {
                Video.CopyTo(stream);
            }
            string FilePath =$"{PathConstants.url}/{PathConstants.VideoFolderPath}/{filename}";
            return FilePath;
        }

        public string UploadImage(IFormFile Image)
        {
            //validating Extention
            string ImageExtention = Path.GetExtension(Image.FileName);
            if (!ValidExtentions_Image.Contains(ImageExtention)) { throw new Exception($"The Image Extention {ImageExtention} is Not Valid . It should be in '{string.Join(",", ValidExtentions_Image)}'"); }
            //uploading Image
            string filename = Guid.NewGuid().ToString() + ImageExtention;
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), PathConstants.ImageFolderPath);
            string FolderPathWithFileName = Path.Combine(uploadsFolder, filename);
            using (var stream = new FileStream(FolderPathWithFileName, FileMode.Create))
            {
                Image.CopyTo(stream);
            }
            string FilePath = $"{PathConstants.url}/{PathConstants.ImageFolderPath}/{filename}";
            return FilePath;
        }
        public bool DeleteVideo(string movieUrl)
        {
            // Extract the file name from the URL
            var fileNameWithExtension = Path.GetFileName(movieUrl);

            // Construct the full path to the video file
            var fullPath = Path.Combine(PathConstants.VideoFolderPath, fileNameWithExtension);

            // Check if the movie file exists
            if (System.IO.File.Exists(fullPath))
            {
                try
                {
                    // Delete the file
                    System.IO.File.Delete(fullPath);
                    return true;

                }
                catch (Exception ex)
                {
                    // Handle exceptions such as access denied or file in use
                    throw new Exception($"Error deleting video file: {ex.Message}");
                }
            }
                return true;
        }
        public bool DeleteImage(string ImageUrl)
        {
            // Extract the file name from the URL
            var fileNameWithExtension = Path.GetFileName(ImageUrl);

            // Construct the full path to the video file
            var fullPath = Path.Combine(PathConstants.ImageFolderPath, fileNameWithExtension);

            // Check if the movie file exists
            if (System.IO.File.Exists(fullPath))
            {
                try
                {
                    // Delete the file
                    System.IO.File.Delete(fullPath);
                    return true;

                }
                catch (Exception ex)
                {
                    // Handle exceptions such as access denied or file in use
                    throw new Exception($"Error deleting image file: {ex.Message}");
                }
            }
            else
            {
                return true;
            }
        }
    
    }
}
