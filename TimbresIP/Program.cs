using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using TimbresIP.Controller;
using TimbresIP.Model;
using TimbresIP.Utils;

namespace TimbresIP
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
            Boolean run = true;
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
                        SoundFileModel soundFile = new SoundFileModel();
                        String filename = "helloworld" + a + ".mp3";
                        soundFile.name = filename;
                        soundFile.targetPath = validateEntriesUtils.getMyDocumentsPath() + "\\" + Properties.Settings.Default.adminHorariosSoundFolderName + "\\" + Properties.Settings.Default.HorarySounds + "\\" + filename;
                        CallServerModel callServer = new CallServerModel(a + 1, "23:54", 5, soundFile, true, "1300", "llamada " + a);
                        horary.callServerList.Add(callServer);
                    }
                    automaticRingSystem.horaryList.Add(horary);
                }

                string outputJSON = JsonConvert.SerializeObject(automaticRingSystem);
                String jsonFileFullPath = validateEntriesUtils.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonFileName + Properties.Settings.Default.jsonExtension;
                File.WriteAllText(jsonFileFullPath, outputJSON);

                try
                {
                    MainController.cypherUtils.FileEncrypt(jsonFileFullPath, Properties.Settings.Default.cypherPassword);
                    //System.IO.File.Delete(jsonFileFullPath);
                }
                catch (Exception e)
                {

                    MainController.log.Error("Intentando guardar archivo json", e);
                }
                //crear archivo JSON FIN
            }


            //TODO callTime => ToTest!
            //TODO guardar => ToTest!
            //TODO cargar combobox => BASOFIA!

            //MainController mainController = new MainController();
            //mainController.init();
            //mainController.start();
            //Console.ReadLine();

            if (run)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }


        }
    }
}
