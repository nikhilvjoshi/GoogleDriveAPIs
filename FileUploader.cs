using Google.Apis.Drive.v3;

namespace DailyTaskService
{
    internal class FileUploader
    {
        internal static async Task UploadFileAsync(ILogger<Worker> logger, DriveService service, string folderId, string filePath)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(filePath);
                FileInfo[] files = directory.GetFiles(); //Getting Text files.
                foreach (var fileInfo in files)
                {
                    // Create a new file metadata object
                    Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File()
                    {
                        Name = fileInfo.Name,
                        Parents = new List<string> { folderId }
                    };

                    // Upload the file
                    using (FileStream fs = new FileStream(fileInfo.FullName, FileMode.Open))
                    {
                        FilesResource.CreateMediaUpload request = service.Files.Create(fileMetadata, fs, "application/octet-stream");
                        request.Upload();

                        // Get the uploaded file details
                        Google.Apis.Drive.v3.Data.File uploadedFile = request.ResponseBody;

                        logger.LogInformation(" File Name : {0} File ID:{1}\r\n", fileInfo.Name, uploadedFile.Id);
                    }
                    fileInfo.Delete();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error Occured", ex);
            }
        }
        public static async Task<string> CreateFolderAsync(ILogger<Worker> logger, DriveService service, string folderName)
        {
            try
            {
                var fileMetadata = new Google.Apis.Drive.v3.Data.File
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder"
                };

                var request = service.Files.Create(fileMetadata);
                request.Fields = "id";
                var folder = request.Execute();

                logger.LogInformation($"Created folder: {folderName} with id {folder.Id}");
                Console.WriteLine("Folder ID: " + folder.Id);
                return folder.Id;
            }
            catch (Exception ex)
            {
                logger.LogError("Error Occured ", ex);
            }
            return string.Empty;
        }
    }
}
