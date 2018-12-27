using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TimbresIP.Model;
using TimbresIP.Utils;

namespace TimbresIP
{
    partial class GeneralRingUserControl : UserControl
    {
        ValidateEntriesUtils validationEntries = new ValidateEntriesUtils();


        /// <summary>
        /// Horario.
        /// </summary>
        public HoraryModel horary { get; set; }

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

                dataRowToAdd["ColumnTone"] = cs.soundFile.targetPath;
                dataRowToAdd["ColumnExtension"] = cs.registerName;
                dataRowToAdd["ColumnObservation"] = cs.observations;

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
            validationEntries.validateNumericEntries(e);
        }

        private void textBoxGeneralSoundExtExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationEntries.validateNumericEntries(e);
        }

        private void dataGridViewGeneralSound_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Name)
            {
                case "ColumnTone":
                    if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                    {
                        DataGridViewComboBoxColumn comboBox = this.dataGridViewGeneralSound.Columns["ColumnTone"] as DataGridViewComboBoxColumn;
                        DirectoryInfo dir = new DirectoryInfo(validationEntries.getMyDocumentsPath() + "\\" + Properties.Settings.Default.adminHorariosSoundFolderName);
                        FileInfo[] files = dir.GetFiles();
                        comboBox.DataSource = files;
                        comboBox.DisplayMember = nameof(FileInfo.Name);
                    }
                    break;
                case "ColumnCall":
                    MessageBox.Show("ColumnCall");
                    break;
            }
        }

        private void dataGridViewGeneralSound_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Validamos si no es una fila nueva
            if (!dataGridViewGeneralSound.Rows[e.RowIndex].IsNewRow)
            {
                Regex regularExpression = new Regex(validationEntries.NumbersRegularExpression);

                if (this.dataGridViewGeneralSound.Columns[e.ColumnIndex].Name== "ColumnExtension")
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
