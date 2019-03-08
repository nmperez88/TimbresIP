using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STA.Controller;
using STA.Model;
using STA.Utils;
using System.Windows.Forms;

namespace STA.Views
{
    partial class BaseUserControl : UserControl
    {
        public ValidateEntriesUtils validateEntriesUtils = new ValidateEntriesUtils();
        public ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();
        public JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils();

        /// <summary>
        /// Horario.
        /// </summary>
        public HoraryModel horary { get; set; }

        /// <summary>
        /// Controlador principal.
        /// </summary>
        public MainController mainController { get; set; }

        protected BaseUserControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Cargar datos del comboBox de sonido en interfaz.
        /// </summary>
        protected SoundFileModel loadDataCellSoundFile(SoundFileModel soundFile, String soundFilePath)
        {
            //string soundDir = BaseUtils.validateEntriesUtils.getMyDocumentsPath() + "\\" + Properties.Settings.Default.soundFolderName + "\\" + Properties.Settings.Default.generalSounds;
            string soundDir = BaseUtils.validateEntriesUtils.getMyDocumentsPath() + "\\" + Properties.Settings.Default.soundFolderName + "\\" + soundFilePath;
            SoundFileModel soundFileRef = null;
            if (Dialog.SelectSoundFile("Tonos disponibles", "Seleccione el tono:", soundFile, ref soundFileRef, soundDir) == DialogResult.OK)
            {
                soundFile = soundFileRef;
            }
            return soundFile;

        }

        /// <summary>
        /// Cargar datos del comboBox de modos en interfaz.
        /// </summary>
        protected ModeModel loadDataCellMode(ModeModel mode)
        {
            ModeModel modeRef = null;
            if (Dialog.SelectMode("Modos disponibles", "Seleccione el modo:", mode, ref modeRef, mainController.modeList) == DialogResult.OK)
            {
                mode = modeRef;
            }
            return mode;

        }
    }
}
