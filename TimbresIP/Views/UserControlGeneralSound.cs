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
    public partial class UserControlGeneralSound : UserControl
    {
        public UserControlGeneralSound()
        {
            InitializeComponent();
        }

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
    }
}
