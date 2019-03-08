using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using STA.Controller;
using STA.Model;
using STA.Utils;
using STA.Views;
using utils;

namespace STA
{
    //partial class GeneralRingUserControl : UserControl
    partial class GeneralRingUserControl : BaseUserControl
    {
        //ValidateEntriesUtils validateEntriesUtils = new ValidateEntriesUtils();
        //ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();


        ///// <summary>
        ///// Horario.
        ///// </summary>
        //public HoraryModel horary { get; set; }

        ///// <summary>
        ///// Controlador principal.
        ///// </summary>
        //public MainController mainController;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public GeneralRingUserControl()
        {
            horary = new HoraryModel("gs");
            InitializeComponent();
            callServerModelBindingSource.DataSource = new List<CallServerModel>();
        }

        #region Métodos
        /// <summary>
        /// Cargar datos en interfaz.
        /// </summary>
        public void loadData()
        {
            //Datos de conexión al servidor.
            textBoxGeneralSoundIdExtension.Text = horary.connectionCallServer.displayName;
            textBoxGeneralSoundExtExtension.Text = horary.connectionCallServer.registerName;
            textBoxGeneralSoundPasswordExtension.Text = horary.connectionCallServer.registerPassword;

            object pm = dataGridViewGeneralSound.Columns[5].CellType;

            //Llamadas.
            List<CallServerModel> callServerListToAdded = new List<CallServerModel>();
            if (horary.callServerList.Any())
            {

                int allowedRows = 0;
                horary.callServerList.ForEach(cs =>
                {
                    if (allowedRows < configurationParametersModel.numberHours + 1)
                    {
                        callServerListToAdded.Add(cs);
                    }
                    allowedRows++;
                });
            }
            callServerModelBindingSource.DataSource = callServerListToAdded;

        }

        /// <summary>
        /// Cargar datos del comboBox de sonido en interfaz.
        /// </summary>
        protected SoundFileModel loadDataCellSoundFile(SoundFileModel soundFile)
        {
            return loadDataCellSoundFile(soundFile, Properties.Settings.Default.generalSounds);
        }

        ///// <summary>
        ///// Cargar datos del comboBox de sonido en interfaz.
        ///// </summary>
        //private SoundFileModel loadDataCellSoundFile(SoundFileModel soundFile)
        //{
        //    string soundDir = BaseUtils.validateEntriesUtils.getMyDocumentsPath() + "\\" + Properties.Settings.Default.soundFolderName + "\\" + Properties.Settings.Default.generalSounds;
        //    SoundFileModel soundFileRef = null;
        //    if (Dialog.SelectSoundFile("Tonos disponibles", "Seleccione el tono:", soundFile, ref soundFileRef, soundDir) == DialogResult.OK)
        //    {
        //        soundFile = soundFileRef;
        //    }
        //    return soundFile;

        //}

        ///// <summary>
        ///// Cargar datos del comboBox de modos en interfaz.
        ///// </summary>
        //private ModeModel loadDataCellMode(ModeModel mode)
        //{
        //    ModeModel modeRef = null;
        //    if (Dialog.SelectMode("Modos disponibles", "Seleccione el modo:", mode, ref modeRef, mainController.modeList) == DialogResult.OK)
        //    {
        //        mode = modeRef;
        //    }
        //    return mode;

        //}

        /// <summary>
        /// Binding.
        /// </summary>
        /// <returns></returns>
        public BindingSource bindingSource()
        {
            return callServerModelBindingSource;
        }


        /// <summary>
        /// Chequear si son válidas las columnas requeridas en las filas del horario.
        /// </summary>
        /// <returns></returns>
        public Boolean isValid()
        {

            String[] columnsToJump = new String[] { "ColumnCall", "observationsDataGridViewTextBoxColumn", "startAtDataGridViewTextBoxColumn", "ColumnEndCall" };
            Boolean isRowValid = true;
            dataGridViewGeneralSound.CurrentRow.Cells.ForEach(c =>
            {
                DataGridViewCell dataGridViewCell = ((DataGridViewCell)c);
                if (!columnsToJump.Contains(dataGridViewCell.OwningColumn.Name) && (dataGridViewCell.Value == null || dataGridViewCell.Value.Equals("")))
                {
                    isRowValid = false;

                }
            });

            if (!isRowValid)
            {
                MessageBox.Show("Debe introducir todos los campos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isRowValid;
        }
        #endregion

        #region Eventos
        private void dataGridViewGeneralSound_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image image = null;
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Name)
                {
                    case "ColumnCall":
                        image = Properties.Resources.call16x16;
                        e.Graphics.DrawImage(image, e.CellBounds.Left + 12, e.CellBounds.Top + 3);

                        this.dataGridViewGeneralSound.Rows[e.RowIndex].Height = image.Height + 10;
                        this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Width = image.Width + 30;

                        e.Handled = true;
                        break;
                    case "ColumnEndCall":
                        image = Properties.Resources.endcall16x16;
                        e.Graphics.DrawImage(image, e.CellBounds.Left + 12, e.CellBounds.Top + 3);

                        this.dataGridViewGeneralSound.Rows[e.RowIndex].Height = image.Height + 10;
                        this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Width = image.Width + 30;

                        e.Handled = true;
                        break;
                }
            }
        }

        private void buttonGeneralSoundEditExtension_Click(object sender, EventArgs e)
        {
            this.textBoxGeneralSoundExtExtension.Enabled = true;
            this.textBoxGeneralSoundIdExtension.Enabled = true;
            this.textBoxGeneralSoundPasswordExtension.Enabled = true;
            this.buttonGeneralSoundSaveExtension.Enabled = true;
            this.buttonGeneralSoundEditExtension.Enabled = false;
        }

        private void buttonGeneralSoundSaveExtension_Click(object sender, EventArgs e)
        {
            this.textBoxGeneralSoundExtExtension.Enabled = false;
            this.textBoxGeneralSoundIdExtension.Enabled = false;
            this.textBoxGeneralSoundPasswordExtension.Enabled = false;
            this.buttonGeneralSoundSaveExtension.Enabled = false;
            this.buttonGeneralSoundEditExtension.Enabled = true;

            horary.connectionCallServer.displayName = horary.connectionCallServer.userName = textBoxGeneralSoundIdExtension.Text;
            horary.connectionCallServer.registerName = textBoxGeneralSoundExtExtension.Text;
            horary.connectionCallServer.registerPassword = textBoxGeneralSoundPasswordExtension.Text;
        }

        private void textBoxGeneralSoundIdExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateEntriesUtils.validateNumericEntries(e);
        }

        private void textBoxGeneralSoundExtExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateEntriesUtils.validateNumericEntries(e);
        }

        private void dataGridViewGeneralSound_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridViewGeneralSound.CurrentRow;
                    CallServerModel callServer = selectedRow.DataBoundItem as CallServerModel;
                    switch (this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Name)
                    {
                        case "soundFileDataGridViewTextBoxColumn":
                            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                            {
                                callServer.soundFile = loadDataCellSoundFile(callServer.soundFile);
                            }
                            break;

                        case "ColumnCall":
                            if (mainController.hasServerParams())
                            {
                                if (horary.connectionCallServer.isValid())
                                {
                                    if (callServer != null && File.Exists(callServer.soundFile.targetPath))
                                    {
                                        DataGridViewButtonCell callTimeButtonCell = (DataGridViewButtonCell)dataGridViewGeneralSound.CurrentCell;
                                        callTimeButtonCell.ReadOnly = true;
                                        mainController.startJobNow(horary, callServer);
                                        callTimeButtonCell.ReadOnly = false;

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Establezca los parámetros de la extensión IP.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Establezca los parametros del servidor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;

                        case "ColumnEndCall":
                            if (mainController.hasServerParams())
                            {
                                if (horary.connectionCallServer.isValid())
                                {
                                    if (callServer != null && File.Exists(callServer.soundFile.targetPath))
                                    {
                                        DataGridViewButtonCell hangUpButtonCell = (DataGridViewButtonCell)dataGridViewGeneralSound.CurrentCell;
                                        hangUpButtonCell.ReadOnly = true;
                                        mainController.hangUpNow(horary, callServer);
                                        hangUpButtonCell.ReadOnly = false;

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Establezca los parámetros de la extensión IP.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Establezca los parametros del servidor.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;

                        case "modeDataGridViewTextBoxColumn":
                            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                            {
                                callServer.mode = loadDataCellMode(callServer.mode);
                            }
                            break;
                    }
                }
                catch (Exception er)
                {

                    BaseUtils.log.Error(er);
                }

            }

        }

        private void dataGridViewGeneralSound_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Regex regularExpression = new Regex("");

            switch (dataGridViewGeneralSound.Columns[e.ColumnIndex].Name)
            {
                case "registerNameDataGridViewTextBoxColumn":
                    regularExpression = new Regex(validateEntriesUtils.NumbersRegularExpression);
                    if (!dataGridViewGeneralSound.Rows[e.RowIndex].IsNewRow)
                    {
                        if (!regularExpression.IsMatch(e.FormattedValue.ToString()) || e.FormattedValue.ToString().Equals(""))
                        {
                            MessageBox.Show("El dato introducido no es de tipo numerico", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewGeneralSound.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo numérico";
                            e.Cancel = true;
                        }
                    }

                    break;
                case "soundFileDataGridViewTextBoxColumn":
                    //Validamos si no es una fila nueva
                    if (!dataGridViewGeneralSound.Rows[e.RowIndex].IsNewRow)
                    {
                        if (e.FormattedValue.ToString().Equals(""))
                        {
                            MessageBox.Show("Debe seleccionar un tono", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewGeneralSound.Rows[e.RowIndex].ErrorText = "La celda no puede ser vacia";
                            e.Cancel = true;
                        }
                    }
                    break;
                case "callTimeDataGridViewTextBoxColumn":
                    regularExpression = new Regex(validateEntriesUtils.NumbersRegularExpression);
                    if (!dataGridViewGeneralSound.Rows[e.RowIndex].IsNewRow)
                    {
                        if (!regularExpression.IsMatch(e.FormattedValue.ToString()) || e.FormattedValue.ToString().Equals(""))
                        {
                            MessageBox.Show("El dato introducido no es de tipo numerico", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewGeneralSound.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo numérico";
                            e.Cancel = true;
                        }

                    }
                    break;
            }

        }

        private void dataGridViewGeneralSound_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Elimina el mensaje de error de la cabecera de la fila
            dataGridViewGeneralSound.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dataGridViewGeneralSound_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //String[] columnsToJump = new String[] { "ColumnCall", "observationsDataGridViewTextBoxColumn", "startAtDataGridViewTextBoxColumn", "ColumnEndCall" };
            //Boolean isRowValid = true;
            //dataGridViewGeneralSound.CurrentRow.Cells.ForEach(c =>
            //{
            //    DataGridViewCell dataGridViewCell = ((DataGridViewCell)c);
            //    if (!columnsToJump.Contains(dataGridViewCell.OwningColumn.Name) && (dataGridViewCell.Value == null || dataGridViewCell.Value.Equals("")))
            //    {
            //        isRowValid = false;

            //    }
            //});

            //if (!isRowValid)
            //{
            //    MessageBox.Show("Debe introducir todos los campos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    e.Cancel = true;
            //    //this.dataGridViewHorary.AllowUserToAddRows = false;
            //}
        }
        private void buttonGeneralAddSounds_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                int no = bindingSource().Count > 0 ? (bindingSource()[bindingSource().Count - 1] as CallServerModel).no + 1 : 1;
                bindingSource().Add(new CallServerModel(no));
                dataGridViewGeneralSound.CurrentCell = dataGridViewGeneralSound.Rows[dataGridViewGeneralSound.Rows.Count - 1].Cells[0];
            }
        }
        private void buttonGeneralDelSounds_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridViewGeneralSound.CurrentRow;
            if (selectedRow != null)
            {
                dataGridViewGeneralSound.Rows.RemoveAt(selectedRow.Index);
            }
            this.buttonGeneralDelSounds.Enabled = false;
        }
        private void dataGridViewGeneralSound_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.buttonGeneralDelSounds.Enabled = true;
        }
        #endregion
    }
}
