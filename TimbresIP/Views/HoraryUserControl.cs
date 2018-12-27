using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TimbresIP.Utils;
using TimbresIP.Model;
using System.Text.RegularExpressions;

namespace TimbresIP
{
    public partial class HoraryUserControl : UserControl
    {
        ValidateEntriesUtils validationEntries = new ValidateEntriesUtils();
        ConfigurationParametersModel configurationParametersModel= new ConfigurationParametersModel();
        JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils();

        public HoraryUserControl()
        {
            InitializeComponent();
        }

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
                switch (this.dataGridViewHorary.Columns[e.ColumnIndex].Name)
                {
                    case "ColumnTone":
                        if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                        {
                            DataGridViewComboBoxColumn comboBox = this.dataGridViewHorary.Columns["ColumnTone"] as DataGridViewComboBoxColumn;
                            DirectoryInfo dirInfo = new DirectoryInfo(validationEntries.getMyDocumentsPath()+ "\\" + Properties.Settings.Default.adminHorariosSoundFolderName);
                            FileInfo[] files = dirInfo.GetFiles();
                            comboBox.DataSource = files;
                            comboBox.DisplayMember = nameof(FileInfo.Name);
                        }
                        break;
                    case "ColumnCall":
                        MessageBox.Show("ColumnCall");
                        break;
                }
            }
        }

        private void dataGridViewHorary_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            switch (dataGridViewHorary.Columns[e.ColumnIndex].Name)
            {
                case "ColumnExtension":
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
                case "ColumnNo":
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

                case "ColumnHoraInicio":
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
                case "ColumnSoundTime":
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
            jsonHandlerUtils = new JsonHandlerUtils(validationEntries.getProgramDataPath(), "TimbresIP.Model.ConfigurationParametersModel");
            configurationParametersModel = (ConfigurationParametersModel)jsonHandlerUtils.deserialize();
        }
    }
}


