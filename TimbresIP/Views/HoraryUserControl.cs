using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TimbresIP.Controller;
using TimbresIP.Model;
using TimbresIP.Utils;
using utils;

namespace TimbresIP
{
    partial class HoraryUserControl : UserControl
    {
        ValidateEntriesUtils validateEntriesUtils = new ValidateEntriesUtils();
        ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();
        JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils();

        /// <summary>
        /// Horario.
        /// </summary>
        public HoraryModel horary;

        /// <summary>
        /// Controlador principal.
        /// </summary>
        public MainController mainController;

        ///// <summary>
        ///// Constructor por defecto.
        ///// </summary>
        //public HoraryUserControl()
        //{
        //    horary = new HoraryModel();
        //    InitializeComponent();

        //}

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
        /// Cargar datos del comboBox en interfaz.
        /// </summary>
        private SoundFileModel loadDataCellSoundFile(SoundFileModel soundFile)
        {
            string soundDir = BaseUtils.validateEntriesUtils.getMyDocumentsPath() + "\\" + Properties.Settings.Default.adminHorariosSoundFolderName + "\\" + Properties.Settings.Default.HorarySounds;
            SoundFileModel soundFileRef = null;
            if (Dialog.SelectSoundFile("Tonos disponibles", "Seleccione el tono:", ref soundFileRef, soundDir) == DialogResult.OK)
            {
                soundFile = soundFileRef;
            }
            return soundFile;

        }

        /// <summary>
        /// Binding.
        /// </summary>
        /// <returns></returns>
        public BindingSource bindingSource()
        {
            return callServerModelBindingSource;
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
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (this.dataGridViewHorary.Columns[e.ColumnIndex].Name)
                {
                    case "ColumnCall":
                        //e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                        //DataGridViewButtonCell cellBoton = this.dataGridViewHorary.Rows[e.RowIndex].Cells["ColumnCall"] as DataGridViewButtonCell;
                        Image image = Properties.Resources.call16x16;
                        e.Graphics.DrawImage(image, e.CellBounds.Left + 12, e.CellBounds.Top + 3);

                        this.dataGridViewHorary.Rows[e.RowIndex].Height = image.Height + 10;
                        this.dataGridViewHorary.Columns[e.ColumnIndex].Width = image.Width + 30;

                        e.Handled = true;
                        break;
                        //case "noDataGridViewTextBoxColumn":
                        //    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                        //    {
                        //        List<CallServerModel> callServerList = ((List<CallServerModel>)callServerModelBindingSource.DataSource);
                        //        int no = callServerList != null && callServerList.Any() ? callServerList[callServerList.Count - 1].no + 1 : 1;

                        //        //e.Graphics.DrawString(no.ToString(), e.CellStyle.Font, Brushes.Black, e.CellBounds.Left + 12, e.CellBounds.Top + 3);

                        //        //e.Handled = true;
                        //        (dataGridViewHorary.Rows[e.RowIndex].DataBoundItem as CallServerModel).no = no;
                        //    }
                        //    break;
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
                                        mainController.startJobNow(horary, callServer);
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
                            MessageBox.Show("La hora indicada no es correcta", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                this.dataGridViewHorary.AllowUserToAddRows = true;
            }
        }

        private void HoraryUserControl_Load(object sender, EventArgs e)
        {
            jsonHandlerUtils = new JsonHandlerUtils(validateEntriesUtils.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension, "TimbresIP.Model.ConfigurationParametersModel");
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

            String[] columnsToJump = new String[] { "ColumnCall", "observationsDataGridViewTextBoxColumn", "enabledDataGridViewCheckBoxColumn" };
            Boolean isRowValid = true;
            dataGridViewHorary.CurrentRow.Cells.ForEach(c =>
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
                e.Cancel = true;
                //this.dataGridViewHorary.AllowUserToAddRows = false;
            }
        }
        #endregion
    }
}


