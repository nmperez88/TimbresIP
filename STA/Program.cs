using Newtonsoft.Json;
using STA.Controller;
using STA.Model;
using STA.Utils;
using System;
using System.IO;
using System.Windows.Forms;

namespace STA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainController.log.Info("App started!");
            Boolean run = false;
            if (!run)
            {
                //crear archivo JSON
                ValidateEntriesUtils validateEntriesUtils = new ValidateEntriesUtils();

                AutomaticRingSystemModel automaticRingSystem = new AutomaticRingSystemModel();
                automaticRingSystem.registrationRequired = true;
                automaticRingSystem.domainHost = "100.50.40.3";
                automaticRingSystem.domainPort = 5060;
                for (int i = 0; i < 1; i++)
                {
                    ConnectionCallServerModel connectionCallServer = new ConnectionCallServerModel();
                    connectionCallServer.displayName = "1230";
                    connectionCallServer.userName = "1230";
                    connectionCallServer.registerName = "1230";
                    connectionCallServer.registerPassword = "1230IA";

                    HoraryModel horary = new HoraryModel("h" + i, connectionCallServer);
                    for (int a = 0; a < 2; a++)
                    {
                        int s = i + a;
                        String sec = s < 10 ? "0" : "" + s;
                        SoundFileModel soundFile = new SoundFileModel();
                        String filename = "helloworld" + a + ".mp3";
                        soundFile.name = filename;
                        soundFile.targetPath = validateEntriesUtils.getMyDocumentsPath() + "\\" + Properties.Settings.Default.soundFolderName + "\\" + Properties.Settings.Default.horarySounds + "\\" + filename;
                        CallServerModel callServer = new CallServerModel(a + 1, "23:54:" + sec, 5, soundFile, true, "1300", "llamada " + a);
                        horary.callServerList.Add(callServer);
                    }
                    automaticRingSystem.horaryList.Add(horary);
                }

                string outputJSON = JsonConvert.SerializeObject(automaticRingSystem);
                //Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
                //settings.Formatting = Newtonsoft.Json.Formatting.Indented;
                //settings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //settings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                //settings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
                //string outputJSON = JsonConvert.SerializeObject(automaticRingSystem, settings);

                String jsonFileFullPath = validateEntriesUtils.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonFileName + Properties.Settings.Default.jsonExtension;
                File.WriteAllText(jsonFileFullPath, outputJSON);

                try
                {
                    //MainController.cypherUtils.FileEncrypt(jsonFileFullPath, Properties.Settings.Default.cypherPassword);
                    //System.IO.File.Delete(jsonFileFullPath);
                }
                catch (Exception e)
                {

                    MainController.log.Error("Intentando guardar archivo json", e);
                }
                //crear archivo JSON FIN
                
                //Crear archivo JSON de factura
                string outputJSONBill = JsonHandlerUtils.getSimplifiedObject(automaticRingSystem).ToString();
                String jsonFileBillFullPath = validateEntriesUtils.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonFileNameBills + Properties.Settings.Default.jsonExtension;
                File.WriteAllText(jsonFileBillFullPath, outputJSONBill);
                //Crear archivo JSON de factura FIN
            }

            if (run)
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                catch (Exception e)
                {
                    BaseUtils.log.Error(e);
                }
            }
        }
    }
}
