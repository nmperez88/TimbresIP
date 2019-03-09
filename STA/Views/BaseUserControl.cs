using STA.Controller;
using STA.Model;
using STA.Utils;
using System;
using System.Linq;
using System.Windows.Forms;
using utils;

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


        /// <summary>
        /// Chequear si son válidas las columnas requeridas en las filas del horario.
        /// </summary>
        /// <returns></returns>
        protected Boolean isValid(DataGridView dataGridView, String[] columnsToJump)
        {
            Boolean isRowValid = true;
            dataGridView.Rows.ForEach(r =>
            {
                DataGridViewRow dataGridViewRow = ((DataGridViewRow)r);
                dataGridViewRow.Cells.ForEach(c =>
                {
                    DataGridViewCell dataGridViewCell = ((DataGridViewCell)c);
                    if (!columnsToJump.Contains(dataGridViewCell.OwningColumn.Name) && (dataGridViewCell.Value == null || dataGridViewCell.Value.Equals("")))
                    {
                        isRowValid = false;
                    }
                });
            });

            if (!isRowValid)
            {
                MessageBox.Show("Existen filas con datos erróneos o incompletos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isRowValid;
        }
    }
}
