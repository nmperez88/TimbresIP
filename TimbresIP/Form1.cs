﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using InputKey;

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
            inputBox input = new inputBox();
            string tabPageName = "Horario";
            if (input.InputBox("Crear nuevo Horario", "Ingrese el nombre del horario:", ref tabPageName) == DialogResult.OK)
            {
                TabPage horaryTabPage = new TabPage(tabPageName);
                tabControlHorary.TabPages.Add(horaryTabPage);
                horaryTabPage.ImageIndex = 0;
            }
            //string tabTitle = InputDialog.mostrar("Ingrese nombre del TabPage:", "Crear nuevo TabPage", InputDialog.ACEPTAR_CANCELAR_BOTON, InputDialog.MENSAJE_PREGUNTA);
            //if (tabTitle != "")
            //{
            //    string title = tabTitle.ToString();
            //    TabPage horaryTabPage = new TabPage(title);
            //    tabControlHorary.TabPages.Add(horaryTabPage);
            //    horaryTabPage.ImageIndex = 0;
            //}
        }

        private void buttonDeleteHorary_Click(object sender, EventArgs e)
        {
            tabControlHorary.TabPages.Remove(tabControlHorary.SelectedTab);
        }

        private void buttonEditHorary_Click(object sender, EventArgs e)
        {
            inputBox input = new inputBox();
            string tabPageName = "";
            if (input.InputBox("Modificar Horario", "Ingrese el nuevo nombre del horario:", ref tabPageName) == DialogResult.OK)
            {
                TabPage horaryTabPage = new TabPage(tabPageName);
                tabControlHorary.SelectedTab.Text = tabPageName;
            }
            //string tabTitle = InputDialog.mostrar("Ingrese nombre del Horario:", "Modificar nombre horario",InputDialog.ACEPTAR_CANCELAR_BOTON,InputDialog.MENSAJE_INFORMACION);
            //if (tabTitle != "")
            //{
            //    string title = tabTitle.ToString();
            //    TabPage horaryTabPage = new TabPage(title);
            //    tabControlHorary.SelectedTab.Text = title;
            //}
        }
    }
}
