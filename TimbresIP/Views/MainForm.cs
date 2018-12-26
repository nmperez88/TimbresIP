using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimbresIP.Utils;
using TimbresIP.Model;

namespace TimbresIP
{
    public partial class MainForm : Form 
    {
        //String configParamsFullPath = @"ComboDataExample\ConfigurationParameters";
        ValidateEntriesUtils validationEntries = new ValidateEntriesUtils();
        ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();
        JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils(@"C:\Users\Noslen Martinez\Documents\Visual Studio 2017\Projects\TimbresIP\TimbresIP\Resources\ComboDataExample\ConfigurationParameters", "ConfigurationParametersModel");
        //JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils(@"ComboDataExample\ConfigurationParameters");
        //JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils(@"ComboDataExample\ConfigurationParameters","ConfigurationParametersModel");
        //ConfigurationParametersJsonHandlerUtils configurationParametersJsonHandlerUtils = new ConfigurationParametersJsonHandlerUtils(@"ComboDataExample\\ConfigurationParameters");


        public MainForm()
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

        private void buttonAddHorary_Click(object sender, EventArgs e)
        {
            HoraryUserControl horaryUserControl = new HoraryUserControl();
            horaryUserControl.Dock = DockStyle.Fill;
            string tabPageName = "Horario";
            if (tabControlHorary.TabPages.Count < 5)
            {
                if (Dialog.Prompt("Crear nuevo Horario", "Ingrese el nombre del horario:", ref tabPageName) == DialogResult.OK)
                {
                    TabPage horaryTabPage = new TabPage(tabPageName);
                    tabControlHorary.TabPages.Add(horaryTabPage);
                    horaryTabPage.ImageIndex = 0;
                    horaryTabPage.Controls.Add(horaryUserControl);
                }
            }
            else { MessageBox.Show("No se puede crear más horarios, ya exedio el límite licenciado. Por favor póngase en contacto con el proveedor del sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void buttonDeleteHorary_Click(object sender, EventArgs e)
        {
            if (tabControlHorary.TabPages.Count > 0)
            {
                string tabName = tabControlHorary.SelectedTab.Text;
                if ((MessageBox.Show("Esta seguro que desea eliminar: " + tabName, "Eliminar Horario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)) == DialogResult.OK)

                    tabControlHorary.TabPages.Remove(tabControlHorary.SelectedTab);
            }
            else { MessageBox.Show("No tiene horarios creados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void buttonEditHorary_Click(object sender, EventArgs e)
        {
            if (tabControlHorary.TabPages.Count > 0)
            {
                string tabPageName = "";
                if (Dialog.Prompt("Modificar Horario", "Ingrese el nuevo nombre del horario:", ref tabPageName) == DialogResult.OK)
                {
                    TabPage horaryTabPage = new TabPage(tabPageName);
                    tabControlHorary.SelectedTab.Text = tabPageName;
                }
            }
            else { MessageBox.Show("Debe crear horarios primeramente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            SendMailUtils sendMailUtils = new SendMailUtils();

            if (jsonHandlerUtils.deserialize()!=null)
            {
                ConfigurationParametersModel configurationParameters = (ConfigurationParametersModel)jsonHandlerUtils.deserialize();
                configurationParametersModel.sendedEMail = configurationParameters.sendedEMail;
            }
            else if (sendMailUtils.sendMail())
                {
                ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel(true, DateTime.Now);
                jsonHandlerUtils.serialize(configurationParametersModel);
                }

            //if (!configurationParametersModel.sendedEMail)
            //{
            //    int diasRestantes = 30;

            //    MessageBox.Show("Estimado usuario no hemos podido registar la instalción de su software por lo que le quedan " + diasRestantes.ToString() + " días de servicio, por favor contáctese con el proveedor del sistema. Muchas gracias", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            GeneralRingUserControl generalRingUserControl = new GeneralRingUserControl();
            this.groupBoxGeneralSound.Controls.Add(generalRingUserControl);
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            validationEntries.validateNumericEntries(e);
        }

        private void textBoxServer_Validating(object sender, CancelEventArgs e)
        {
            if (!validationEntries.validateIPAddr(textBoxServer.Text))
            {
                MessageBox.Show("La dirección IP del servidor no es correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

