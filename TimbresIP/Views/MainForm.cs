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
        MailUtils sendMailUtils = new MailUtils();
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
            generalRingUserControl.mainController = mainController;
            if (mainController.getAutomaticRingSystem().generalRingList.Any())
            {
                HoraryModel horary = mainController.getAutomaticRingSystem().generalRingList[0];
                generalRingUserControl.horary = horary;
                generalRingUserControl.loadData();
            }

        }

        /// <summary>
        /// Validar parámetros introducidos en los horarios.
        /// </summary>
        /// <returns></returns>
        private Boolean validateParamsHoraries()
        {
            Boolean validParams = true;

            for (int i = 0; i < this.tabControlHorary.TabPages.Count; i++)
            {
                HoraryUserControl horaryUserControl = (this.tabControlHorary.TabPages[i].Controls[0] as HoraryUserControl);
                if (!horaryUserControl.isValid())
                {
                    validParams = false;
                    break;
                }

            }
            return validParams;
        }

        /// <summary>
        /// Validar parámetros introducidos en los sonidos generales.
        /// </summary>
        /// <returns></returns>
        private Boolean validateParamsGeneralRings()
        {
            return generalRingUserControl.isValid();
        }

        private Boolean save()
        {
            buttonSaveAll.Enabled = false;
            Boolean validData = true;
            if (!mainController.hasServerParams())
            {
                validData = false;
                MessageBox.Show("Establezca los parámetros del servidor antes de guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (!validateParamsHoraries())
            {
                validData = false;
            }
            else if (!validateParamsGeneralRings())
            {
                validData = false;
            }
            else
            {
                List<HoraryModel> horaries = new List<HoraryModel>();
                List<HoraryModel> generalRings = new List<HoraryModel>();

                //validar datos en horarios
                for (int i = 0; i < this.tabControlHorary.TabPages.Count; i++)
                {
                    HoraryUserControl horaryUserControl = (this.tabControlHorary.TabPages[i].Controls[0] as HoraryUserControl);
                    if (!horaryUserControl.horary.connectionCallServer.isValid())
                    {
                        validData = false;
                        MessageBox.Show("Existen horarios con parámetros de la extensión IP incompletos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    try
                    {
                        horaryUserControl.horary.callServerList = ((List<CallServerModel>)horaryUserControl.bindingSource().DataSource);
                    }
                    catch (Exception e)
                    {

                        BaseUtils.log.Error(e);
                    }

                    horaries.Add(horaryUserControl.horary);

                }
                //validar datos en horarios FIN

                //validar datos en sonidos generales
                if (validData && !generalRingUserControl.horary.connectionCallServer.isValid())
                {
                    validData = false;
                    MessageBox.Show("Sonidos generales con parámetros de la extensión IP incompletos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                generalRingUserControl.horary.callServerList = ((List<CallServerModel>)generalRingUserControl.bindingSource().DataSource);
                generalRings.Add(generalRingUserControl.horary);
                //validar datos en sonidos generales FIN

                //Validación cruces de horas de ejecución
                //Dictionary<String, long[]> horaryTime = new Dictionary<string, long[]>();
                List<HoraryCallServerUtils> horaryTime = new List<HoraryCallServerUtils>();
                //
                horaries.ForEach(h =>
                {
                    h.callServerList.ForEach(cs =>
                    {
                        var startAt = Convert.ToDateTime(cs.startAt);
                        HoraryCallServerUtils horaryCallServerUtils = new HoraryCallServerUtils();
                        horaryCallServerUtils.Id = h.randomId + cs.randomId;
                        horaryCallServerUtils.NameHorary = h.name;
                        horaryCallServerUtils.StartAt = startAt.Ticks;
                        horaryCallServerUtils.EndAt = startAt.AddSeconds(cs.callTime).Ticks;
                        horaryTime.Add(horaryCallServerUtils);
                    });
                });
                if (horaryTime.Count > 0)
                {
                    HoraryCallServerUtils hcs = horaryTime[0];
                    while (horaryTime.Count > 0)
                    {
                        var finded = horaryTime.Where(ht =>
                        !ht.Id.Equals(hcs.Id) && (
                        (hcs.StartAt <= ht.StartAt && hcs.EndAt >= ht.StartAt) ||
                        (hcs.StartAt <= ht.EndAt && hcs.EndAt >= ht.StartAt) ||

                        (hcs.StartAt >= ht.StartAt && hcs.StartAt <= ht.EndAt) ||
                        (hcs.EndAt >= ht.StartAt && hcs.EndAt <= ht.EndAt))
                        );
                        if (finded.Count() > 0)
                        {
                            string horaryName = hcs.NameHorary;

                            finded.ToList().ForEach(f =>
                            {
                                if (!f.NameHorary.Equals(hcs.NameHorary))
                                {
                                    horaryName += ", " + f.NameHorary;
                                }
                            });

                            MessageBox.Show("Existen horarios con horas coincidentes: " + horaryName, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            validData = false;
                            break;
                        }
                        horaryTime.Remove(hcs);
                        if (horaryTime.Count() > 0)
                        {
                            hcs = horaryTime[0];
                        }
                    }
                }

                if (validData)
                {
                    mainController.getAutomaticRingSystem().horaryList = horaries;
                    mainController.getAutomaticRingSystem().generalRingList = generalRings;
                    mainController.saveAndRestart();
                }

            }
            buttonSaveAll.Enabled = true;
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
            string tabPageName = "Horario";
            if (tabControlHorary.TabPages.Count < configurationParametersModel.numberschedules)
            {
                if (Dialog.Prompt("Crear nuevo Horario", "Ingrese el nombre del horario:", ref tabPageName) == DialogResult.OK)
                {
                    TabPage horaryTabPage = new TabPage(tabPageName);
                    HoraryModel horary = new HoraryModel(tabPageName);
                    HoraryUserControl horaryUserControl = new HoraryUserControl(horary);
                    horaryUserControl.Dock = DockStyle.Fill;
                    horaryUserControl.mainController = mainController;
                    tabControlHorary.TabPages.Add(horaryTabPage);
                    horaryTabPage.ImageIndex = 0;
                    horaryTabPage.Controls.Add(horaryUserControl);
                    tabControlHorary.SelectTab(tabControlHorary.TabPages[tabControlHorary.TabCount - 1]);
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
                {
                    mainController.getAutomaticRingSystem().horaryList.Remove((tabControlHorary.SelectedTab.Controls[0] as HoraryUserControl).horary);
                    tabControlHorary.TabPages.Remove(tabControlHorary.SelectedTab);
                }
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
                    //TabPage horaryTabPage = new TabPage(tabPageName);
                    tabControlHorary.SelectedTab.Text = tabPageName;
                    (tabControlHorary.SelectedTab.Controls[0] as HoraryUserControl).horary.name = tabPageName;
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
                        if (sendMailUtils.send())
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
                else if (sendMailUtils.send())
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

