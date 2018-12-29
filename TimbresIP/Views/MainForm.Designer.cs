﻿namespace TimbresIP
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBoxMainControl = new System.Windows.Forms.GroupBox();
            this.buttonEditServer = new System.Windows.Forms.Button();
            this.buttonSaveServer = new System.Windows.Forms.Button();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.groupBoxHorary = new System.Windows.Forms.GroupBox();
            this.tabControlHorary = new System.Windows.Forms.TabControl();
            this.imageListTabHorary = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxGeneralSound = new System.Windows.Forms.GroupBox();
            this.buttonDeleteHorary = new System.Windows.Forms.Button();
            this.buttonEditHorary = new System.Windows.Forms.Button();
            this.buttonAddHorary = new System.Windows.Forms.Button();
            this.toolTipFormPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxManageHorary = new System.Windows.Forms.GroupBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.buttonSaveAll = new System.Windows.Forms.Button();
            this.groupBoxCallTails = new System.Windows.Forms.GroupBox();
            this.labelCallTails = new System.Windows.Forms.Label();
            this.groupBoxMainControl.SuspendLayout();
            this.groupBoxHorary.SuspendLayout();
            this.groupBoxManageHorary.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxCallTails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMainControl
            // 
            this.groupBoxMainControl.Controls.Add(this.buttonEditServer);
            this.groupBoxMainControl.Controls.Add(this.buttonSaveServer);
            this.groupBoxMainControl.Controls.Add(this.labelPort);
            this.groupBoxMainControl.Controls.Add(this.labelServer);
            this.groupBoxMainControl.Controls.Add(this.textBoxPort);
            this.groupBoxMainControl.Controls.Add(this.textBoxServer);
            this.groupBoxMainControl.Location = new System.Drawing.Point(12, 8);
            this.groupBoxMainControl.Name = "groupBoxMainControl";
            this.groupBoxMainControl.Size = new System.Drawing.Size(440, 61);
            this.groupBoxMainControl.TabIndex = 0;
            this.groupBoxMainControl.TabStop = false;
            this.groupBoxMainControl.Text = "Configuración del servidor";
            // 
            // buttonEditServer
            // 
            this.buttonEditServer.Image = global::TimbresIP.Properties.Resources.editc20x20;
            this.buttonEditServer.Location = new System.Drawing.Point(347, 18);
            this.buttonEditServer.Name = "buttonEditServer";
            this.buttonEditServer.Size = new System.Drawing.Size(33, 30);
            this.buttonEditServer.TabIndex = 5;
            this.buttonEditServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipFormPrincipal.SetToolTip(this.buttonEditServer, "Editar ");
            this.buttonEditServer.UseVisualStyleBackColor = true;
            this.buttonEditServer.Click += new System.EventHandler(this.buttonEditServer_Click);
            // 
            // buttonSaveServer
            // 
            this.buttonSaveServer.Enabled = false;
            this.buttonSaveServer.Image = global::TimbresIP.Properties.Resources.savec20x20;
            this.buttonSaveServer.Location = new System.Drawing.Point(388, 18);
            this.buttonSaveServer.Name = "buttonSaveServer";
            this.buttonSaveServer.Size = new System.Drawing.Size(33, 30);
            this.buttonSaveServer.TabIndex = 4;
            this.buttonSaveServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipFormPrincipal.SetToolTip(this.buttonSaveServer, "Guardar");
            this.buttonSaveServer.UseVisualStyleBackColor = true;
            this.buttonSaveServer.Click += new System.EventHandler(this.buttonSaveServer_Click);
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(217, 27);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(41, 13);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Puerto:";
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(10, 27);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(55, 13);
            this.labelServer.TabIndex = 2;
            this.labelServer.Text = "Dirección:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Enabled = false;
            this.textBoxPort.Location = new System.Drawing.Point(264, 23);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(65, 20);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "5060";
            this.textBoxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPort_KeyPress);
            // 
            // textBoxServer
            // 
            this.textBoxServer.Enabled = false;
            this.textBoxServer.Location = new System.Drawing.Point(72, 23);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(128, 20);
            this.textBoxServer.TabIndex = 0;
            this.textBoxServer.Text = "100.50.40.3";
            this.textBoxServer.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxServer_Validating);
            // 
            // groupBoxHorary
            // 
            this.groupBoxHorary.Controls.Add(this.tabControlHorary);
            this.groupBoxHorary.Location = new System.Drawing.Point(10, 74);
            this.groupBoxHorary.Name = "groupBoxHorary";
            this.groupBoxHorary.Size = new System.Drawing.Size(877, 298);
            this.groupBoxHorary.TabIndex = 1;
            this.groupBoxHorary.TabStop = false;
            this.groupBoxHorary.Text = "Horarios";
            // 
            // tabControlHorary
            // 
            this.tabControlHorary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlHorary.ImageList = this.imageListTabHorary;
            this.tabControlHorary.Location = new System.Drawing.Point(3, 16);
            this.tabControlHorary.Name = "tabControlHorary";
            this.tabControlHorary.SelectedIndex = 0;
            this.tabControlHorary.Size = new System.Drawing.Size(871, 279);
            this.tabControlHorary.TabIndex = 0;
            // 
            // imageListTabHorary
            // 
            this.imageListTabHorary.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabHorary.ImageStream")));
            this.imageListTabHorary.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTabHorary.Images.SetKeyName(0, "clock24x24.png");
            // 
            // groupBoxGeneralSound
            // 
            this.groupBoxGeneralSound.Location = new System.Drawing.Point(10, 378);
            this.groupBoxGeneralSound.Name = "groupBoxGeneralSound";
            this.groupBoxGeneralSound.Size = new System.Drawing.Size(877, 170);
            this.groupBoxGeneralSound.TabIndex = 2;
            this.groupBoxGeneralSound.TabStop = false;
            this.groupBoxGeneralSound.Text = "Sonidos generales";
            // 
            // buttonDeleteHorary
            // 
            this.buttonDeleteHorary.Image = global::TimbresIP.Properties.Resources.removec20x20;
            this.buttonDeleteHorary.Location = new System.Drawing.Point(84, 23);
            this.buttonDeleteHorary.Name = "buttonDeleteHorary";
            this.buttonDeleteHorary.Size = new System.Drawing.Size(33, 30);
            this.buttonDeleteHorary.TabIndex = 5;
            this.toolTipFormPrincipal.SetToolTip(this.buttonDeleteHorary, "Seleccione primero el TabPage a eliminar");
            this.buttonDeleteHorary.UseVisualStyleBackColor = true;
            this.buttonDeleteHorary.Click += new System.EventHandler(this.buttonDeleteHorary_Click);
            // 
            // buttonEditHorary
            // 
            this.buttonEditHorary.Image = global::TimbresIP.Properties.Resources.editc20x20;
            this.buttonEditHorary.Location = new System.Drawing.Point(45, 23);
            this.buttonEditHorary.Name = "buttonEditHorary";
            this.buttonEditHorary.Size = new System.Drawing.Size(33, 30);
            this.buttonEditHorary.TabIndex = 4;
            this.buttonEditHorary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipFormPrincipal.SetToolTip(this.buttonEditHorary, "Seleccionar primero el TabPage a modificar");
            this.buttonEditHorary.UseVisualStyleBackColor = true;
            this.buttonEditHorary.Click += new System.EventHandler(this.buttonEditHorary_Click);
            // 
            // buttonAddHorary
            // 
            this.buttonAddHorary.Image = global::TimbresIP.Properties.Resources.addc20x20;
            this.buttonAddHorary.Location = new System.Drawing.Point(6, 23);
            this.buttonAddHorary.Name = "buttonAddHorary";
            this.buttonAddHorary.Size = new System.Drawing.Size(33, 30);
            this.buttonAddHorary.TabIndex = 3;
            this.buttonAddHorary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTipFormPrincipal.SetToolTip(this.buttonAddHorary, "Agregar Horario");
            this.buttonAddHorary.UseVisualStyleBackColor = true;
            this.buttonAddHorary.Click += new System.EventHandler(this.buttonAddHorary_Click);
            // 
            // toolTipFormPrincipal
            // 
            this.toolTipFormPrincipal.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipFormPrincipal.ToolTipTitle = "Información";
            // 
            // groupBoxManageHorary
            // 
            this.groupBoxManageHorary.Controls.Add(this.buttonAddHorary);
            this.groupBoxManageHorary.Controls.Add(this.buttonDeleteHorary);
            this.groupBoxManageHorary.Controls.Add(this.buttonEditHorary);
            this.groupBoxManageHorary.Location = new System.Drawing.Point(472, 8);
            this.groupBoxManageHorary.Name = "groupBoxManageHorary";
            this.groupBoxManageHorary.Size = new System.Drawing.Size(129, 61);
            this.groupBoxManageHorary.TabIndex = 6;
            this.groupBoxManageHorary.TabStop = false;
            this.groupBoxManageHorary.Text = "Gestionar Horarios";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.buttonSaveAll);
            this.groupBoxActions.Location = new System.Drawing.Point(621, 8);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(79, 61);
            this.groupBoxActions.TabIndex = 7;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Acciones";
            // 
            // buttonSaveAll
            // 
            this.buttonSaveAll.Image = global::TimbresIP.Properties.Resources.savec20x20;
            this.buttonSaveAll.Location = new System.Drawing.Point(25, 19);
            this.buttonSaveAll.Name = "buttonSaveAll";
            this.buttonSaveAll.Size = new System.Drawing.Size(33, 30);
            this.buttonSaveAll.TabIndex = 0;
            this.buttonSaveAll.UseVisualStyleBackColor = true;
            // 
            // groupBoxCallTails
            // 
            this.groupBoxCallTails.Controls.Add(this.labelCallTails);
            this.groupBoxCallTails.Location = new System.Drawing.Point(717, 8);
            this.groupBoxCallTails.Name = "groupBoxCallTails";
            this.groupBoxCallTails.Size = new System.Drawing.Size(170, 61);
            this.groupBoxCallTails.TabIndex = 8;
            this.groupBoxCallTails.TabStop = false;
            this.groupBoxCallTails.Text = "Cola de Llamadas";
            // 
            // labelCallTails
            // 
            this.labelCallTails.AutoSize = true;
            this.labelCallTails.Location = new System.Drawing.Point(7, 15);
            this.labelCallTails.Name = "labelCallTails";
            this.labelCallTails.Size = new System.Drawing.Size(35, 13);
            this.labelCallTails.TabIndex = 0;
            this.labelCallTails.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 561);
            this.Controls.Add(this.groupBoxCallTails);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxManageHorary);
            this.Controls.Add(this.groupBoxGeneralSound);
            this.Controls.Add(this.groupBoxHorary);
            this.Controls.Add(this.groupBoxMainControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Administrador de Horarios";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.groupBoxMainControl.ResumeLayout(false);
            this.groupBoxMainControl.PerformLayout();
            this.groupBoxHorary.ResumeLayout(false);
            this.groupBoxManageHorary.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxCallTails.ResumeLayout(false);
            this.groupBoxCallTails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMainControl;
        private System.Windows.Forms.GroupBox groupBoxHorary;
        private System.Windows.Forms.GroupBox groupBoxGeneralSound;
        private System.Windows.Forms.TabControl tabControlHorary;
        private System.Windows.Forms.Button buttonSaveServer;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Button buttonEditServer;
        private System.Windows.Forms.Button buttonAddHorary;
        private System.Windows.Forms.Button buttonEditHorary;
        private System.Windows.Forms.Button buttonDeleteHorary;
        private System.Windows.Forms.ImageList imageListTabHorary;
        private System.Windows.Forms.ToolTip toolTipFormPrincipal;
        private System.Windows.Forms.GroupBox groupBoxManageHorary;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button buttonSaveAll;
        private System.Windows.Forms.GroupBox groupBoxCallTails;
        private System.Windows.Forms.Label labelCallTails;
    }
}

