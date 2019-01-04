using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
        ValidateEntriesUtils validationEntries = new ValidateEntriesUtils();
        ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();
        JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils();

        /// <summary>
        /// Horario.
        /// </summary>
        HoraryModel horary;

        /// <summary>
        /// Controlador principal.
        /// </summary>
        public MainController mainController;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public HoraryUserControl()
        {
            horary = new HoraryModel();
            InitializeComponent();

        }

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
            int allowedRows = 0;
            horary.callServerList.ForEach(cs =>
            {
                if (allowedRows < configurationParametersModel.numberHours + 1)
                {
                    callServerListToAdded.Add(cs);
                }
                allowedRows++;
            });

            dataGridViewHorary.DataSource = callServerListToAdded;

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
        }

        private void dataGridViewHorary_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridViewHorary.Columns[e.ColumnIndex].Name == "ColumnCall" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridViewHorary.Rows[e.RowIndex].Cells["ColumnCall"] as DataGridViewButtonCell;
                Image image = Properties.Resources.call16x16;
                e.Graphics.DrawImage(image, e.CellBounds.Left + 12, e.CellBounds.Top + 3);

                this.dataGridViewHorary.Rows[e.RowIndex].Height = image.Height + 10;
                this.dataGridViewHorary.Columns[e.ColumnIndex].Width = image.Width + 30;

                e.Handled = true;
            }
        }

        private void textBoxHoraryIdExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationEntries.validateNumericEntries(e);
        }

        private void textBoxHoraryExtExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationEntries.validateNumericEntries(e);
        }

        private void dataGridViewHorary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                try
                {
                    switch (this.dataGridViewHorary.Columns[e.ColumnIndex].Name)
                    {
                        case "soundFileDataGridViewTextBoxColumn":
                            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                            {
                                try
                                {
                                    DataGridViewComboBoxColumn comboBox = this.dataGridViewHorary.Columns["soundFileDataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn;
                                    DirectoryInfo dirInfo = new DirectoryInfo(validationEntries.getMyDocumentsPath() + "\\" + Properties.Settings.Default.adminHorariosSoundFolderName + "\\" + Properties.Settings.Default.HorarySounds);
                                    FileInfo[] files = dirInfo.GetFiles();
                                    comboBox.DataSource = files;
                                    comboBox.DisplayMember = nameof(FileInfo.Name);
                                    //comboBox.dis
                                }
                                catch (Exception er)
                                {
                                    BaseUtils.log.Error(er);
                                }

                            }
                            break;
                        case "ColumnCall":
                            DataGridViewRow selectedRow = dataGridViewHorary.CurrentRow;
                            CallServerModel callServer = selectedRow.DataBoundItem as CallServerModel;
                            mainController.startJobNow(horary, callServer);
                            break;
                    }
                }
                catch (Exception er)
                {

                    log.WriteError(er);
                }

            }
        }

        private void dataGridViewHorary_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            switch (dataGridViewHorary.Columns[e.ColumnIndex].Name)
            {
                case "registerNameDataGridViewTextBoxColumn":
                    //Validamos si no es una fila nueva
                    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                    {
                        Regex regularExpression = new Regex(validationEntries.NumbersRegularExpression);
                        if (!regularExpression.IsMatch(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("El dato introducido no es de tipo numerico", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewHorary.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo numérico";
                            e.Cancel = true;
                        }
                    }
                    break;
                case "noDataGridViewTextBoxColumn":
                    //Validamos si no es una fila nueva
                    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                    {
                        Regex regularExpression = new Regex(validationEntries.NumbersRegularExpression);
                        if (!regularExpression.IsMatch(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("El dato introducido no es de tipo numerico", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewHorary.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo numérico";
                            e.Cancel = true;
                        }
                    }
                    break;

                case "startAtDataGridViewTextBoxColumn":
                    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                    {
                        Regex regularExpression = new Regex(validationEntries.TimeRegularExpression);
                        if (!regularExpression.IsMatch(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("La hora indicada no es correcta", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewHorary.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo horario";
                            e.Cancel = true;
                        }
                    }
                    break;
                case "callTimeDataGridViewTextBoxColumn":
                    if (!dataGridViewHorary.Rows[e.RowIndex].IsNewRow)
                    {
                        Regex regularExpression = new Regex(validationEntries.TimeRegularExpression);
                        if (!regularExpression.IsMatch(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("La hora indicada no es correcta", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridViewHorary.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo horario";
                            e.Cancel = true;
                        }
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
            jsonHandlerUtils = new JsonHandlerUtils(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension, "TimbresIP.Model.ConfigurationParametersModel");
            configurationParametersModel = (ConfigurationParametersModel)jsonHandlerUtils.deserialize();
            //loadData();
        }
        #endregion
    }
}


