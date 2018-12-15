using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimbresIP
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEditServer_Click(object sender, EventArgs e)
        {
            this.textBoxServer.Enabled = true;
            this.textBoxPort.Enabled = true;
            this.buttonSaveServer.Enabled = true;
            this.buttonEditServer.Enabled = false;
        }

        private void buttonSaveServer_Click(object sender, EventArgs e)
        {
            this.textBoxServer.Enabled = false;
            this.textBoxPort.Enabled = false;
            this.buttonSaveServer.Enabled = false;
            this.buttonEditServer.Enabled = true;
        }

        private void buttonEditExtension_Click(object sender, EventArgs e)
        {
            this.textBoxExtExtension.Enabled = true;
            this.textBoxIdExtension.Enabled = true;
            this.textBoxPasswordExtension.Enabled = true;
            this.buttonSaveExtension.Enabled = true;
            this.buttonEditExtension.Enabled = false;
        }

        private void buttonSaveExtension_Click(object sender, EventArgs e)
        {
            this.textBoxExtExtension.Enabled = false;
            this.textBoxIdExtension.Enabled = false;
            this.textBoxPasswordExtension.Enabled = false;
            this.buttonSaveExtension.Enabled = false;
            this.buttonEditExtension.Enabled = true;
        }

        private void buttonAddHorary_Click(object sender, EventArgs e)
        {
            string tabTitle;
            if(){ }
            tabTitle = Microsoft.VisualBasic.Interaction.InputBox("Ingrese nombre del TAB: ", "Crear nuevo TAB", "TabPage ",100,100);
            string title = tabTitle.ToString()+ " " + (tabControlHorary.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControlHorary.TabPages.Add(myTabPage);
        }

        private void buttonDeleteHorary_Click(object sender, EventArgs e)
        {
            tabControlHorary.TabPages.Remove(tabControlHorary.SelectedTab);
        }
    }
}
