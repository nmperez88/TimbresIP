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

namespace TimbresIP
{
    public partial class UserControlGeneralSound : UserControl
    {
        public UserControlGeneralSound()
        {
            InitializeComponent();
        }

        private void UserControlGeneralSound_Load(object sender, EventArgs e)
        {
            listViewGeneralSound.View = View.Details;
            listViewGeneralSound.Columns.Add("Tono", 200, HorizontalAlignment.Left);
            listViewGeneralSound.Columns.Add("Extensión", 150, HorizontalAlignment.Left);
            listViewGeneralSound.Columns.Add("Llamar", 150, HorizontalAlignment.Left);
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

        private void buttonGeneralSoundAdd_Click(object sender, EventArgs e)
        {
            Button button = new Button();
            TextBox textBox = new TextBox();
            OpenFileDialog openFileDialog = new OpenFileDialog();


        }
    }
}
