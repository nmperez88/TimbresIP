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
namespace TimbresIP
{
    public partial class MainForm : MaterialSkin.Controls.MaterialForm
    {
        ValidateEntriesUtils validationEntries = new ValidateEntriesUtils();
        JsonHandlerUtils jsonHandlerUtils = new JsonHandlerUtils();
        SendMailUtils sendMailUtils = new SendMailUtils();
        ConfigurationParametersModel configurationParametersModel = new ConfigurationParametersModel();
        //CypherUtils cypherUtils = new CypherUtils();

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
                    horaryUserControl.mainController = mainController;
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
                generalRingUserControl.mainController = mainController;
                generalRingUserControl.loadData();
            }

        }

        private Boolean save()
        {
            Boolean validData = true;
            if (!mainController.hasServerParams())
            {
                validData = false;
                MessageBox.Show("Establezca los parámetros del servidor antes de guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<HoraryModel> horaries = new List<HoraryModel>();
                List<HoraryModel> generalRings = new List<HoraryModel>();

                //validar datos en horarios
                for (int i = 0; i < this.tabControlHorary.TabPages.Count; i++)
                {
                    //HoraryUserControl horaryUserControl = (this.tabControlHorary.TabPages[i].GetContainerControl() as HoraryUserControl);
                    HoraryUserControl horaryUserControl = (this.tabControlHorary.TabPages[i].Controls[0] as HoraryUserControl);
                    if (!horaryUserControl.horary.connectionCallServer.isValid())
                    {
                        validData = false;
                        MessageBox.Show("Existen horarios con parámetros de la extensión IP incompletos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    horaryUserControl.horary.callServerList = ((List<CallServerModel>)horaryUserControl.bindingSource().DataSource);
                    horaries.Add(horaryUserControl.horary);

                }
                //validar datos en horarios FIN

                //validar datos en sonidos generales
                if (validData && !generalRingUserControl.horary.connectionCallServer.isValid())
                {
                    validData = false;
                    MessageBox.Show("Existen sonidos generales con parámetros de la extensión IP incompletos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                generalRingUserControl.horary.callServerList = ((List<CallServerModel>)generalRingUserControl.bindingSource().DataSource);
                generalRings.Add(generalRingUserControl.horary);
                //validar datos en sonidos generales FIN

                if (validData)
                {
                    mainController.getAutomaticRingSystem().horaryList = horaries;
                    mainController.getAutomaticRingSystem().generalRingList = generalRings;
                    mainController.saveAndRestart();
                }

            }

            return validData;
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

            mainController.getAutomaticRingSystem().domainHost = textBoxServer.Text;
            mainController.getAutomaticRingSystem().domainPort = Convert.ToInt32(textBoxPort.Text);
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
                    horaryUserControl.horary.name = tabPageName;
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
                    (tabControlHorary.SelectedTab.GetContainerControl() as HoraryUserControl).horary.name = tabPageName;
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

                if (File.Exists(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension + ".aes"))
                {
                    BaseUtils.cypherUtils.FileDecrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension + ".aes", validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension, Properties.Settings.Default.cypherPassword);
                    configurationParametersModel = (ConfigurationParametersModel)jsonHandlerUtils.deserialize();
                    File.Delete(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);

                    DateTime fechaActual = DateTime.Now;
                    TimeSpan diferenciaDiasFechas = fechaActual - configurationParametersModel.installedDate;
                    int diasRestantes = diferenciaDiasFechas.Days;

                    if (configurationParametersModel.lisenceTime == diasRestantes)
                    {
                        MessageBox.Show("Estimado usuario su periodo de licencia caducó, por favor comuniquese con el proveedor del sistema para renovar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Application.Exit();
                    }

                    if (!configurationParametersModel.sendedEMail)
                    {
                        if (sendMailUtils.sendMail())
                        {
                            configurationParametersModel = new ConfigurationParametersModel(true);
                            jsonHandlerUtils.serialize(configurationParametersModel);
                            MessageBox.Show("Estimado usuario, hemos registrado la instalación de su producto satisfactoriamente con fecha: " + DateTime.Now + ". Esperamos sea de su agrado y utilidad. Equipo BITDATA.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (diasRestantes == 30)
                            {
                                MessageBox.Show("Estimado usuario, no hemos podido registrar la instalación de su producto, por lo que le quedan " + (30 - diasRestantes).ToString() + " días de servicio, por tanto se suspende el uso del sistema hasta que contácte con el proveedor. Muchas gracias y disculpe las molestias", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                Application.Exit();
                            }
                            else
                            {
                                MessageBox.Show("Estimado usuario, no hemos podido registrar la instalación de su producto, por lo que le quedan " + (30 - diasRestantes).ToString() + "/30 días de servicio, por favor contáctese con el proveedor. Muchas gracias.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    BaseUtils.cypherUtils.FileEncrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension, Properties.Settings.Default.cypherPassword);
                    File.Delete(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);
                    this.groupBoxGeneralSound.Controls.Add(generalRingUserControl);
                    MessageBox.Show("Estimado usuario, hemos registrado la instalación de su producto satisfactoriamente con fecha: " + DateTime.Now + ". Esperamos sea de su agrado y utilidad. Equipo BITDATA", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    configurationParametersModel = new ConfigurationParametersModel(false);
                    jsonHandlerUtils.serialize(configurationParametersModel);
                    BaseUtils.cypherUtils.FileEncrypt(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension, Properties.Settings.Default.cypherPassword);
                    File.Delete(validationEntries.getProgramDataPath() + "\\" + Properties.Settings.Default.jsonConfigurationParametersName + Properties.Settings.Default.jsonExtension);
                    DateTime fechaActual = DateTime.Now;
                    TimeSpan diferenciaDiasFechas = fechaActual - configurationParametersModel.installedDate;
                    int diasRestantes = diferenciaDiasFechas.Days;
                    if (diasRestantes == 30)
                    {
                        MessageBox.Show("Estimado usuario, no hemos podido registrar la instalación de su producto por lo que le quedan " + (30 - diasRestantes).ToString() + " días de servicio, por tanto se suspende el uso del sistema hasta que contácte con el proveedor. Muchas gracias", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Estimado usuario, no hemos podido registrar la instalación de su producto por lo que le quedan " + (30 - diasRestantes).ToString() + "/30 días de servicio, por favor contáctese con el proveedor del sistema. Muchas gracias", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception er)
            {
                BaseUtils.log.Error(er);

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
                MessageBox.Show("La dirección IP indicada no es correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            save();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mainController.matchData())
            {
                DialogResult dialogResult = MessageBox.Show("Estimado usuario existen cambios sin guardar, desea guardar antes de salir?", "Advertencias", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!save())
                    {
                        e.Cancel = true;
                    }
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

                mainController.stop();
            }
        }

        #endregion
    }

}

