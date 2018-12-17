using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimbresIP
{
    public partial class UserControlHorary : UserControl
    {
        public UserControlHorary()
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
    }
    }

