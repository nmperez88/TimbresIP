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
    //partial class HoraryUserControl : UserControl
    partial class HoraryUserControl : BaseUserControl
    {
        //ValidateEntriesUtils validateEntriesUtils = new ValidateEntriesUtils();
        //ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();
        //JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils();

        ///// <summary>
        ///// Horario.
        ///// </summary>
        //public HoraryModel horary;

        ///// <summary>
        ///// Controlador principal.
        ///// </summary>
        //public MainController mainController;

        /// <summary>
        /// Constructor. Para cargar datos en interfaz.
        /// </summary>
        /// <param name="horary"></param>
        public HoraryUserControl(HoraryModel horary)
        {
            this.horary = horary;
            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// Cargar datos en interfaz.
        /// </summary>
        private void loadData()
        {
            //Datos de conexión al servidor.
            textBoxHoraryIdExtension.Text = horary.connectionCallServer.displayName;
            textBoxHoraryExtExtension.Text = horary.connectionCallServer.registerName;
            textBoxHoraryPasswordExtension.Text = horary.connectionCallServer.registerPassword;

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

            for (int i = 0; i < dataGridViewHorary.Rows.Count - 1; i++)
            {
                dataGridViewHorary.Rows[i].Cells["enabledDataGridViewCheckBoxColumn"].Value = callServerListToAdded[i].enabled;
            }

        }

        /// <summary>
        /// Cargar datos del comboBox de sonido en interfaz.
        /// </summary>
        protected SoundFileModel loadDataCellSoundFile(SoundFileModel soundFile)
        {
            return loadDataCellSoundFile(soundFile, Properties.Settings.Default.horarySounds);
        }

        ///// <summary>
        ///// Cargar datos del comboBox en interfaz.
        ///// </summary>
        //private SoundFileModel loadDataCellSoundFile(SoundFileModel soundFile)
        //{
        //    string soundDir = BaseUtils.validateEntriesUtils.getMyDocumentsPath() + "\\" + Properties.Settings.Default.soundFolderName + "\\" + Properties.Settings.Default.horarySounds;
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
            String[] columnsToJump = new String[] { "ColumnCall", "observationsDataGridViewTextBoxColumn", "enabledDataGridViewCheckBoxColumn", "ColumnEndCall" };
            Boolean isRowValid = true;
            dataGridViewHorary.Rows.ForEach(r =>
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

        #endregion

        #region Eventos
        private void buttonEditExtension_Click(object sender, EventArgs e)
        {
            this.textBoxHoraryExtExtension.Enabled = true;
            this.textBoxHoraryIdExtension.Enabled = true;
            this.textBoxHoraryPasswordExtension.Enabled = true;
            this.buttonHorarySaveExtension.Enabled = true;
            this.buttonHoraryEditExtension.Enabled = false;
        }

        private void buttonSaveExtension_Click(object sender, EventArgs e)
        {
            this.textBoxHoraryExtExtension.Enabled = false;
            this.textBoxHoraryIdExtension.Enabled = false;
            this.textBoxHoraryPasswordExtension.Enabled = false;
            this.buttonHorarySaveExtension.Enabled = false;
            this.buttonHoraryEditExtension.Enabled = true;

            horary.connectionCallServer.displayName = horary.connectionCallServer.userName = textBoxHoraryIdExtension.Text;
            horary.connectionCallServer.registerName = textBoxHoraryExtExtension.Text;
            horary.connectionCallServer.registerPassword = textBoxHoraryPasswordExtension.Text;
        }

        private void dataGridViewHorary_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Image image = null;
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (this.dataGridViewHorary.Columns[e.ColumnIndex].Name)
                {
                    case "ColumnCall":
                        //e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                        //DataGridViewButtonCell cellBoton = this.dataGridViewHorary.Rows[e.RowIndex].Cells["ColumnCall"] as DataGridViewButtonCell;
                        image = Properties.Resources.call16x16;
                        e.Graphics.DrawImage(image, e.CellBounds.Left + 12, e.CellBounds.Top + 3);

                        this.dataGridViewHorary.Rows[e.RowIndex].Height = image.Height + 10;
                        this.dataGridViewHorary.Columns[e.ColumnIndex].Width = image.Width + 30;

                        e.Handled = true;
                        break;
                    case "ColumnEndCall":
                        //e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                        //DataGridViewButtonCell cellBoton = this.dataGridViewHorary.Rows[e.RowIndex].Cells["ColumnCall"] as DataGridViewButtonCell;
                        image = Properties.Resources.endcall16x16;
                        e.Graphics.DrawImage(image, e.CellBounds.Left + 12, e.CellBounds.Top + 3);

                        this.dataGridViewHorary.Rows[e.RowIndex].Height = image.Height + 10;
                        this.dataGridViewHorary.Columns[e.ColumnIndex].Width = image.Width + 30;

                        e.Handled = true;
                        break;
                }
            }
        }

        private void textBoxHoraryIdExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateEntriesUtils.validateNumericEntries(e);
        }

        private void textBoxHoraryExtExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateEntriesUtils.validateNumericEntries(e);
        }

        private void dataGridViewHorary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridViewHorary.CurrentRow;
                    CallServerModel callServer = selectedRow.DataBoundItem as CallServerModel;
                    switch (this.dataGridViewHorary.Columns[e.ColumnIndex].Name)
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
                                        DataGridViewButtonCell callTimeButtonCell = (DataGridViewButtonCell)dataGridViewHorary.CurrentCell;
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
                                        DataGridViewButtonCell hangUpButtonCell = (DataGridViewButtonCell)dataGridViewHorary.CurrentCell;
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
                    }
                }
                catch (Exception er)
                {
                    BaseUtils.log.Error(er);
                }

            }
        }

        private void dataGridViewHorary_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Regex regularExpression = new Regex("");
            switch (dataGridViewHorary.Columns[e.ColumnIndex].Name)
            {
                case "registerNameDataGridViewTextBoxColumn":
                    regularExpression = new Regex(validateEntriesUtils.NumbersRegularExpression);
                    //Validamos si no es una fila nueva
                    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                    {

                        if (!regularExpression.IsMatch(e.FormattedValue.ToString()) || e.FormattedValue.ToString().Equals(""))
                        {
                            MessageBox.Show("El dato introducido no es de tipo numerico", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewHorary.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo numérico";
                            e.Cancel = true;
                        }
                    }
                    break;
                //case "noDataGridViewTextBoxColumn":
                //    //Validamos si no es una fila nueva
                //    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                //    {
                //        Regex regularExpression = new Regex(validateEntriesUtils.NumbersRegularExpression);
                //        if (!regularExpression.IsMatch(e.FormattedValue.ToString()) || e.FormattedValue.ToString().Equals(""))
                //        {
                //            MessageBox.Show("El dato introducido no es de tipo numerico", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            dataGridViewHorary.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo numérico";
                //            e.Cancel = true;
                //        }
                //    }
                //    break;

                case "soundFileDataGridViewTextBoxColumn":
                    //Validamos si no es una fila nueva
                    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                    {
                        if (e.FormattedValue.ToString().Equals(""))
                        {
                            MessageBox.Show("Debe seleccionar un tono", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewHorary.Rows[e.RowIndex].ErrorText = "La celda no puede ser vacia";
                            e.Cancel = true;
                        }
                    }
                    break;

                case "startAtDataGridViewTextBoxColumn":
                    regularExpression = new Regex(validateEntriesUtils.TimeRegularExpression);
                    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                    {
                        if (!regularExpression.IsMatch(e.FormattedValue.ToString()) || e.FormattedValue.ToString().Equals(""))
                        {
                            MessageBox.Show("La hora indicada no es correcta, debe ser formato hh:mm:ss", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewHorary.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo horario";
                            e.Cancel = true;
                        }
                    }
                    break;
                case "callTimeDataGridViewTextBoxColumn":
                    regularExpression = new Regex(validateEntriesUtils.NumbersRegularExpression);
                    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                    {

                        if (!regularExpression.IsMatch(e.FormattedValue.ToString()) || e.FormattedValue.ToString().Equals(""))
                        {
                            MessageBox.Show("El dato introducido no es de tipo numerico", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewHorary.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo numérico";
                            e.Cancel = true;
                        }
                        //Regex regularExpression = new Regex(validateEntriesUtils.TimeRegularExpression);
                        //if (!regularExpression.IsMatch(e.FormattedValue.ToString()))
                        //{
                        //    MessageBox.Show("La hora indicada no es correcta", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    dataGridViewHorary.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo horario";
                        //    e.Cancel = true;
                        //}
                    }
                    break;
            }

        }

        private void dataGridViewHorary_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

            if (this.dataGridViewHorary.Rows.Count == configurationParametersModel.numberHours + 1)
            {
                this.dataGridViewHorary.AllowUserToAddRows = false;
                MessageBox.Show("No se puede crear más horas, ya exedio el límite licenciado. Por favor póngase en contacto con el proveedor del sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else
            //{
            //    this.dataGridViewHorary.AllowUserToAddRows = true;
            //}
        }

        private void HoraryUserControl_Load(object sender, EventArgs e)
        {
            jsonHandlerUtils = new JsonHandlerUtils(validateEntriesUtils.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigParamsName + Properties.Settings.Default.jsonExtension, "STA.Model.ConfigurationParametersModel");
            configurationParametersModel = (ConfigurationParametersModel)jsonHandlerUtils.deserialize();

            loadData();
        }

        private void dataGridViewHorary_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            BaseUtils.log.Error(e);
        }

        private void dataGridViewHorary_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //BaseUtils.log.Error(callServerModelBindingSource.DataSource);
            //BaseUtils.log.Error("callServerModelBindingSource: " + ((List<CallServerModel>)callServerModelBindingSource.DataSource).Count);
            //BaseUtils.log.Error("horary.callServerList.Count: "+horary.callServerList.Count);
        }

        private void dataGridViewHorary_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                List<CallServerModel> callServerList = ((List<CallServerModel>)callServerModelBindingSource.DataSource);
                //List<CallServerModel> callServerList = ((List<CallServerModel>)dataGridViewHorary.DataSource); No funciona ni con datos
                if (callServerList != null && callServerList.Any())
                {
                    callServerList[callServerList.Count - 1].no = callServerList.Count >= 2 ? callServerList[callServerList.Count - 2].no + 1 : 1;
                }
            }
            catch (Exception er)
            {

                BaseUtils.log.Error(er);
            }
        }

        private void dataGridViewHorary_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //String[] columnsToJump = new String[] { "ColumnCall", "observationsDataGridViewTextBoxColumn", "enabledDataGridViewCheckBoxColumn", "ColumnEndCall" };
            //Boolean isRowValid = true;
            //dataGridViewHorary.CurrentRow.Cells.ForEach(c =>
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
        private void buttonHoraryAddHours_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                if (this.dataGridViewHorary.Rows.Count == configurationParametersModel.numberHours + 1)
                {
                    MessageBox.Show("No se puede crear más horas, ya exedió el límite licenciado. Por favor póngase en contacto con el proveedor del sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int no = bindingSource().Count > 0 ? (bindingSource()[bindingSource().Count - 1] as CallServerModel).no + 1 : 1;
                    bindingSource().Add(new CallServerModel(no));
                    dataGridViewHorary.CurrentCell = dataGridViewHorary.Rows[dataGridViewHorary.Rows.Count - 1].Cells[1];
                }
            }
        }
        private void buttonHoraryDelHours_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridViewHorary.CurrentRow;
            if (selectedRow != null)
            {
                dataGridViewHorary.Rows.RemoveAt(selectedRow.Index);
            }
            this.buttonHoraryDelHours.Enabled = false;
        }

        private void dataGridViewHorary_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.buttonHoraryDelHours.Enabled = true;
        }
        #endregion

    }
}


