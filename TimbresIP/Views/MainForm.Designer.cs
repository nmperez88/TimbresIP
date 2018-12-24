namespace TimbresIP
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
            this.groupBoxMainControl.SuspendLayout();
            this.groupBoxHorary.SuspendLayout();
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
            this.groupBoxMainControl.Size = new System.Drawing.Size(637, 61);
            this.groupBoxMainControl.TabIndex = 0;
            this.groupBoxMainControl.TabStop = false;
            this.groupBoxMainControl.Text = "Controles globales";
            // 
            // buttonEditServer
            // 
            this.buttonEditServer.Image = global::TimbresIP.Properties.Resources.editc20x20;
            this.buttonEditServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditServer.Location = new System.Drawing.Point(347, 18);
            this.buttonEditServer.Name = "buttonEditServer";
            this.buttonEditServer.Size = new System.Drawing.Size(75, 30);
            this.buttonEditServer.TabIndex = 5;
            this.buttonEditServer.Text = "Editar";
            this.buttonEditServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEditServer.UseVisualStyleBackColor = true;
            this.buttonEditServer.Click += new System.EventHandler(this.buttonEditServer_Click);
            // 
            // buttonSaveServer
            // 
            this.buttonSaveServer.Enabled = false;
            this.buttonSaveServer.Image = global::TimbresIP.Properties.Resources.savec20x20;
            this.buttonSaveServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveServer.Location = new System.Drawing.Point(437, 18);
            this.buttonSaveServer.Name = "buttonSaveServer";
            this.buttonSaveServer.Size = new System.Drawing.Size(75, 30);
            this.buttonSaveServer.TabIndex = 4;
            this.buttonSaveServer.Text = "Guardar";
            this.buttonSaveServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.labelServer.Size = new System.Drawing.Size(59, 13);
            this.labelServer.TabIndex = 2;
            this.labelServer.Text = "ServidorIP:";
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
            this.groupBoxHorary.Location = new System.Drawing.Point(12, 75);
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
            this.groupBoxGeneralSound.Location = new System.Drawing.Point(12, 379);
            this.groupBoxGeneralSound.Name = "groupBoxGeneralSound";
            this.groupBoxGeneralSound.Size = new System.Drawing.Size(877, 170);
            this.groupBoxGeneralSound.TabIndex = 2;
            this.groupBoxGeneralSound.TabStop = false;
            this.groupBoxGeneralSound.Text = "Sonidos generales";
            // 
            // buttonDeleteHorary
            // 
            this.buttonDeleteHorary.Image = global::TimbresIP.Properties.Resources.removec20x20;
            this.buttonDeleteHorary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteHorary.Location = new System.Drawing.Point(782, 42);
            this.buttonDeleteHorary.Name = "buttonDeleteHorary";
            this.buttonDeleteHorary.Size = new System.Drawing.Size(110, 30);
            this.buttonDeleteHorary.TabIndex = 5;
            this.buttonDeleteHorary.Text = "Eliminar Horario";
            this.buttonDeleteHorary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipFormPrincipal.SetToolTip(this.buttonDeleteHorary, "Seleccione primero el TabPage a eliminar");
            this.buttonDeleteHorary.UseVisualStyleBackColor = true;
            this.buttonDeleteHorary.Click += new System.EventHandler(this.buttonDeleteHorary_Click);
            // 
            // buttonEditHorary
            // 
            this.buttonEditHorary.Image = global::TimbresIP.Properties.Resources.editc20x20;
            this.buttonEditHorary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditHorary.Location = new System.Drawing.Point(782, 12);
            this.buttonEditHorary.Name = "buttonEditHorary";
            this.buttonEditHorary.Size = new System.Drawing.Size(110, 30);
            this.buttonEditHorary.TabIndex = 4;
            this.buttonEditHorary.Text = "Editar Horario";
            this.buttonEditHorary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipFormPrincipal.SetToolTip(this.buttonEditHorary, "Seleccionar primero el TabPage a modificar");
            this.buttonEditHorary.UseVisualStyleBackColor = true;
            this.buttonEditHorary.Click += new System.EventHandler(this.buttonEditHorary_Click);
            // 
            // buttonAddHorary
            // 
            this.buttonAddHorary.Image = global::TimbresIP.Properties.Resources.addc20x20;
            this.buttonAddHorary.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddHorary.Location = new System.Drawing.Point(676, 19);
            this.buttonAddHorary.Name = "buttonAddHorary";
            this.buttonAddHorary.Size = new System.Drawing.Size(96, 46);
            this.buttonAddHorary.TabIndex = 3;
            this.buttonAddHorary.Text = "Agregar Horario";
            this.buttonAddHorary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddHorary.UseVisualStyleBackColor = true;
            this.buttonAddHorary.Click += new System.EventHandler(this.buttonAddHorary_Click);
            // 
            // toolTipFormPrincipal
            // 
            this.toolTipFormPrincipal.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipFormPrincipal.ToolTipTitle = "Información";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 561);
            this.Controls.Add(this.buttonDeleteHorary);
            this.Controls.Add(this.buttonEditHorary);
            this.Controls.Add(this.buttonAddHorary);
            this.Controls.Add(this.groupBoxGeneralSound);
            this.Controls.Add(this.groupBoxHorary);
            this.Controls.Add(this.groupBoxMainControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Administrador de Horarios";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.groupBoxMainControl.ResumeLayout(false);
            this.groupBoxMainControl.PerformLayout();
            this.groupBoxHorary.ResumeLayout(false);
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
    }
}

