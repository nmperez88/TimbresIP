using System;
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
    partial class GeneralRingUserControl : UserControl
    {
        ValidateEntriesUtils validateEntriesUtils = new ValidateEntriesUtils();


        /// <summary>
        /// Horario.
        /// </summary>
        public HoraryModel horary { get; set; }

        /// <summary>
        /// Controlador principal.
        /// </summary>
        public MainController mainController;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public GeneralRingUserControl()
        {
            InitializeComponent();
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

            //Llamadas.
            horary.callServerList.ForEach(cs =>
            {
                DataTable dataTable = (DataTable)dataGridViewGeneralSound.DataSource;
                DataRow dataRowToAdd = dataTable.NewRow();

                //dataRowToAdd["soundFileDataGridViewTextBoxColumn"] = cs.soundFile.targetPath;
                dataRowToAdd["soundFileDataGridViewTextBoxColumn"] = cs.soundFile;
                dataRowToAdd["registerNameDataGridViewTextBoxColumn"] = cs.registerName;
                dataRowToAdd["observationsDataGridViewTextBoxColumn"] = cs.observations;

                dataTable.Rows.Add(dataRowToAdd);
                dataTable.AcceptChanges();
            });

        }
        #endregion

        #region Eventos
        private void dataGridViewGeneralSound_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Name == "ColumnCall" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridViewGeneralSound.Rows[e.RowIndex].Cells["ColumnCall"] as DataGridViewButtonCell;
                Image image = Properties.Resources.call16x16;
                e.Graphics.DrawImage(image, e.CellBounds.Left + 12, e.CellBounds.Top + 3);

                this.dataGridViewGeneralSound.Rows[e.RowIndex].Height = image.Height + 10;
                this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Width = image.Width + 30;

                e.Handled = true;
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
            try
            {
                switch (this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Name)
                {
                    case "soundFileDataGridViewTextBoxColumn":
                        if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                        {
                            try
                            {
                                DataGridViewComboBoxColumn comboBox = this.dataGridViewGeneralSound.Columns["soundFileDataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn;
                                DirectoryInfo dir = new DirectoryInfo(validateEntriesUtils.getMyDocumentsPath() + "\\" + Properties.Settings.Default.adminHorariosSoundFolderName + "\\" + Properties.Settings.Default.GeneralSounds);
                                FileInfo[] files = dir.GetFiles();
                                comboBox.DataSource = files;
                                comboBox.DisplayMember = nameof(FileInfo.Name);
                            }
                            catch (Exception er)
                            {
                                BaseUtils.log.Error(er);
                            }
                        }
                        break;
                    case "ColumnCall":
                        DataGridViewRow selectedRow = dataGridViewGeneralSound.CurrentRow;
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

        private void dataGridViewGeneralSound_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Validamos si no es una fila nueva
            if (!dataGridViewGeneralSound.Rows[e.RowIndex].IsNewRow)
            {
                Regex regularExpression = new Regex(validateEntriesUtils.NumbersRegularExpression);

                if (this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Name == "registerNameDataGridViewTextBoxColumn")
                {
                    if (!regularExpression.IsMatch(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("El dato introducido no es de tipo numerico", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridViewGeneralSound.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo numérico";
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dataGridViewGeneralSound_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Elimina el mensaje de error de la cabecera de la fila
            dataGridViewGeneralSound.Rows[e.RowIndex].ErrorText = String.Empty;
        }
        #endregion
    }
}
