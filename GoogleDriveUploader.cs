using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace DailyTaskService
{
    internal class GoogleDriveUploader
    {
        static string[] Scopes = { DriveService.Scope.DriveFile };
        static string ApplicationName = "{{Google Drive Application Name}}";
        static DriveService service;

        public static DriveService Authenticate()
        {
            UserCredential credential;

            // Load client secrets.
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                // The file client_secrets.json should be the downloaded JSON from Google Cloud Console.
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore("Drive.Api.Store")).Result;
            }

            // Create the Drive API service.
            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }
    }
}
