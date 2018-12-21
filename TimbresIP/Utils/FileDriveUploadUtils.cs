using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace TimbresIP
{
    class FileDriveUploadUtils
    {
        //private static userDriveCredentials getUserDriveCredentials()
        //{
        //    using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
        //    {
        //        string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //        creadPath = Path.Combine(creadPath, "driveApiCredentials", "drive credentials.json");

        //        return GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            Scopes,
        //            "User",
        //            Cancel
        //            );
        //    }
        //}
    }
}
