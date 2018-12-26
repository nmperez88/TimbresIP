using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using TimbresIP.Controller;
using TimbresIP.Model;

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

            //AutomaticRingSystemModel automaticRingSystem = new AutomaticRingSystemModel();
            //automaticRingSystem.registrationRequired = true;
            //automaticRingSystem.domainHost = "100.50.40.3";
            //automaticRingSystem.domainPort = 5060;
            //for (int i = 0; i < 1; i++)
            //{
            //    ConnectionCallServerModel connectionCallServer = new ConnectionCallServerModel();
            //    connectionCallServer.displayName = "1300";
            //    connectionCallServer.userName = "1300";
            //    connectionCallServer.registerName = "1300";
            //    connectionCallServer.registerPassword = "1300IA";

            //    HoraryModel horary = new HoraryModel("h" + i, connectionCallServer);
            //    for (int a = 0; a < 2; a++)
            //    {
            //        SoundFileModel soundFile = new SoundFileModel();
            //        String filename = "helloworld" + a + ".mp3";
            //        soundFile.name = filename;
            //        soundFile.targetPath = filename;
            //        CallServerModel callServer = new CallServerModel("23:54", "5", soundFile, true, "", "llamada " + a);
            //        horary.callServerList.Add(callServer);
            //    }
            //    automaticRingSystem.horaryList.Add(horary);
            //}

            ////TODO callTime

            //string outputJSON = JsonConvert.SerializeObject(automaticRingSystem);
            //String jsonFileFullPath = Properties.Settings.Default.jsonFolderDirectory + Properties.Settings.Default.jsonFileName + Properties.Settings.Default.jsonExtension;
            //File.WriteAllText(jsonFileFullPath, outputJSON);


            //MainController mainController = new MainController();
            //mainController.init();
            //mainController.start();
            //Console.ReadKey();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
    }
}
