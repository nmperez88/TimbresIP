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

            ////crear archivo JSON
            //ValidateEntriesUtils validateEntriesUtils = new ValidateEntriesUtils();

            //AutomaticRingSystemModel automaticRingSystem = new AutomaticRingSystemModel();
            //automaticRingSystem.registrationRequired = true;
            //automaticRingSystem.domainHost = "100.50.40.3";
            //automaticRingSystem.domainPort = 5060;
            //for (int i = 0; i < 1; i++)
            //{
            //    ConnectionCallServerModel connectionCallServer = new ConnectionCallServerModel();
            //    connectionCallServer.displayName = "1230";
            //    connectionCallServer.userName = "1230";
            //    connectionCallServer.registerName = "1230";
            //    connectionCallServer.registerPassword = "1230IA";

            //    HoraryModel horary = new HoraryModel("h" + i, connectionCallServer);
            //    for (int a = 0; a < 2; a++)
            //    {
            //        //        SoundFileModel soundFile = new SoundFileModel();
            //        //        String filename = "helloworld" + a + ".mp3";
            //        //        soundFile.name = filename;
            //        //        soundFile.targetPath = filename;
            //        String soundFile = "helloworld" + a + ".mp3";
            //        CallServerModel callServer = new CallServerModel(a + 1, "23:54", 5, soundFile, true, "1300", "llamada " + a);
            //        horary.callServerList.Add(callServer);
            //    }
            //    automaticRingSystem.horaryList.Add(horary);
            //}

            //string outputJSON = JsonConvert.SerializeObject(automaticRingSystem);
            //String jsonFileFullPath = validateEntriesUtils.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonFileName + Properties.Settings.Default.jsonExtension;
            //File.WriteAllText(jsonFileFullPath, outputJSON);
            ////crear archivo JSON FIN

            //TODO callTime => ToTest!
            //Archivos mp3 en mis documentos
            //Sendmail: programData\BITDATA

            //Encrypt
            //cypherUtils.FileEncrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension, Properties.Settings.Default.cypherPassword);
            //File.Delete(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);

            //Decrypt
            //cypherUtils.FileDecrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension + ".aes", validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension, Properties.Settings.Default.cypherPassword);
            //configurationParametersModel = (ConfigurationParametersModel)jsonHandlerUtils.deserialize();
            //File.Delete(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);

            //guardar

            //MainController mainController = new MainController();
            //mainController.init();
            //mainController.start();
            //Console.ReadLine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
    }
}
