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
using TimbresIP.Controller;
using log4net.Util;
using utils;

namespace TimbresIP
{
    public partial class MainForm : MaterialSkin.Controls.MaterialForm
    {
        ValidateEntriesUtils validationEntries = new ValidateEntriesUtils();
        JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils();
        SendMailUtils sendMailUtils = new SendMailUtils();
        ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();

        /// <summary>
        /// Controlador principal.
        /// </summary>
        MainController mainController;

        /// <summary>
        /// Control de usuario para sonidos generales.
        /// </summary>
        GeneralRingUserControl generalRingUserControl;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// Cargar datos en interfaz.
        /// </summary>
        private void loadData()
        {
            mainController = new MainController();
            //Datos del servidor.
            textBoxServer.Text = mainController.getAutomaticRingSystem().domainHost;
            textBoxPort.Text = mainController.getAutomaticRingSystem().domainPort.ToString();

            //Horarios.
            mainController.getAutomaticRingSystem().horaryList.ForEach(h =>
            {
                if (tabControlHorary.TabPages.Count < configurationParametersModel.numberschedules)
                {
                    HoraryUserControl horaryUserControl = new HoraryUserControl(h);
                    horaryUserControl.Dock = DockStyle.Fill;
                    TabPage horaryTabPage = new TabPage(h.name);
                    tabControlHorary.TabPages.Add(horaryTabPage);
                    horaryTabPage.ImageIndex = 0;
                    horaryTabPage.Controls.Add(horaryUserControl);
                }
            });

            //Sonidos generales.
            if (mainController.getAutomaticRingSystem().generalRingList.Any())
            {
                HoraryModel horary = mainController.getAutomaticRingSystem().generalRingList[0];
                generalRingUserControl.horary = horary;
                generalRingUserControl.loadData();
            }


        }
        #endregion

        #region Eventos
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
            if (tabControlHorary.TabPages.Count < configurationParametersModel.numberschedules)
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
                string tabPageName = tabControlHorary.SelectedTab.Text;
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
            generalRingUserControl = new GeneralRingUserControl();
            generalRingUserControl.Dock = DockStyle.Fill;
            try
            {
                jsonHandlerUtils = new JsonHandlerUtils(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension, "TimbresIP.Model.ConfigurationParametersModel");

                if (File.Exists(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension))
                {
                    File.Decrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);
                    configurationParametersModel = (ConfigurationParametersModel)jsonHandlerUtils.deserialize();

                    if (!configurationParametersModel.sendedEMail)
                    {
                        if (sendMailUtils.sendMail())
                        {
                            configurationParametersModel = new ConfigurationParametersModel(true);
                            jsonHandlerUtils.serialize(configurationParametersModel);
                            File.Encrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);
                            MessageBox.Show("Estimado usuario, hemos regisrado la instalación de su producto satisfactoriamente con fecha: "+DateTime.Now+". Esperamos sea de su agrado y utilidad. Equipo BITDATA","Bienvenido",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            DateTime fechaActual = DateTime.Now;
                            TimeSpan diferenciaDiasFechas = fechaActual - configurationParametersModel.installedDate;
                            int diasRestantes = diferenciaDiasFechas.Days;
                            if (diasRestantes == 30)
                            {
                                MessageBox.Show("Estimado usuario no hemos podido registar la instalción de su software por lo que le quedan " + (30 - diasRestantes).ToString() + " días de servicio, por tanto se suspende el uso del sistema hasta que contácte con el proveedor del sistema. Muchas gracias", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Application.Exit();
                            }
                            else
                            {
                                MessageBox.Show("Estimado usuario no hemos podido registar la instalción de su software por lo que le quedan " + (30 - diasRestantes).ToString() + "/30 días de servicio, por favor contáctese con el proveedor del sistema. Muchas gracias", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        this.groupBoxGeneralSound.Controls.Add(generalRingUserControl);
                        loadData();
                    }
                    else
                    {
                        this.groupBoxGeneralSound.Controls.Add(generalRingUserControl);
                        loadData();
                    }

                }
                else if (sendMailUtils.sendMail())
                {
                    configurationParametersModel = new ConfigurationParametersModel(true);
                    jsonHandlerUtils.serialize(configurationParametersModel);
                    File.Encrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);
                    this.groupBoxGeneralSound.Controls.Add(generalRingUserControl);
                    MessageBox.Show("Estimado usuario, hemos regisrado la instalación de su producto satisfactoriamente con fecha: " + DateTime.Now + ". Esperamos sea de su agrado y utilidad. Equipo BITDATA", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    configurationParametersModel = new ConfigurationParametersModel(false);
                    jsonHandlerUtils.serialize(configurationParametersModel);
                    File.Encrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);
                    DateTime fechaActual = DateTime.Now;
                    TimeSpan diferenciaDiasFechas = fechaActual - configurationParametersModel.installedDate;
                    int diasRestantes = diferenciaDiasFechas.Days;
                    if (diasRestantes == 30)
                    {
                        MessageBox.Show("Estimado usuario no hemos podido registar la instalción de su software por lo que le quedan " + (30 - diasRestantes).ToString() + " días de servicio, por tanto se suspende el uso del sistema hasta que contácte con el proveedor del sistema. Muchas gracias", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Estimado usuario no hemos podido registar la instalción de su software por lo que le quedan " + (30 - diasRestantes).ToString() + "/30 días de servicio, por favor contáctese con el proveedor del sistema. Muchas gracias", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception er)
            {
                log.WriteError(er);

            }
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

        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Encrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);
        }
    }

}

