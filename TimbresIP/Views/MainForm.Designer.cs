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
            this.groupBoxManageHorary = new System.Windows.Forms.GroupBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.buttonSaveAll = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxMainControl.SuspendLayout();
            this.groupBoxHorary.SuspendLayout();
            this.groupBoxManageHorary.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMainControl
            // 
            this.groupBoxMainControl.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxMainControl.Controls.Add(this.buttonEditServer);
            this.groupBoxMainControl.Controls.Add(this.buttonSaveServer);
            this.groupBoxMainControl.Controls.Add(this.labelPort);
            this.groupBoxMainControl.Controls.Add(this.labelServer);
            this.groupBoxMainControl.Controls.Add(this.textBoxPort);
            this.groupBoxMainControl.Controls.Add(this.textBoxServer);
            this.groupBoxMainControl.Location = new System.Drawing.Point(12, 71);
            this.groupBoxMainControl.Name = "groupBoxMainControl";
            this.groupBoxMainControl.Size = new System.Drawing.Size(440, 61);
            this.groupBoxMainControl.TabIndex = 0;
            this.groupBoxMainControl.TabStop = false;
            this.groupBoxMainControl.Text = "Configuración del servidor";
            // 
            // buttonEditServer
            // 
            this.buttonEditServer.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditServer.FlatAppearance.BorderSize = 0;
            this.buttonEditServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEditServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEditServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditServer.Image = global::TimbresIP.Properties.Resources.editc20x20;
            this.buttonEditServer.Location = new System.Drawing.Point(347, 18);
            this.buttonEditServer.Name = "buttonEditServer";
            this.buttonEditServer.Size = new System.Drawing.Size(33, 30);
            this.buttonEditServer.TabIndex = 5;
            this.buttonEditServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipFormPrincipal.SetToolTip(this.buttonEditServer, "Editar ");
            this.buttonEditServer.UseVisualStyleBackColor = false;
            this.buttonEditServer.Click += new System.EventHandler(this.buttonEditServer_Click);
            // 
            // buttonSaveServer
            // 
            this.buttonSaveServer.Enabled = false;
            this.buttonSaveServer.FlatAppearance.BorderSize = 0;
            this.buttonSaveServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonSaveServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonSaveServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.textBoxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPort_KeyPress);
            // 
            // textBoxServer
            // 
            this.textBoxServer.Enabled = false;
            this.textBoxServer.Location = new System.Drawing.Point(72, 23);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(128, 20);
            this.textBoxServer.TabIndex = 0;
            this.textBoxServer.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxServer_Validating);
            // 
            // groupBoxHorary
            // 
            this.groupBoxHorary.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxHorary.Controls.Add(this.tabControlHorary);
            this.groupBoxHorary.Location = new System.Drawing.Point(10, 137);
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
            this.groupBoxGeneralSound.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxGeneralSound.Location = new System.Drawing.Point(10, 441);
            this.groupBoxGeneralSound.Name = "groupBoxGeneralSound";
            this.groupBoxGeneralSound.Size = new System.Drawing.Size(877, 188);
            this.groupBoxGeneralSound.TabIndex = 2;
            this.groupBoxGeneralSound.TabStop = false;
            this.groupBoxGeneralSound.Text = "Sonidos generales";
            // 
            // buttonDeleteHorary
            // 
            this.buttonDeleteHorary.FlatAppearance.BorderSize = 0;
            this.buttonDeleteHorary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonDeleteHorary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonDeleteHorary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteHorary.Image = global::TimbresIP.Properties.Resources.removec20x20;
            this.buttonDeleteHorary.Location = new System.Drawing.Point(84, 18);
            this.buttonDeleteHorary.Name = "buttonDeleteHorary";
            this.buttonDeleteHorary.Size = new System.Drawing.Size(33, 30);
            this.buttonDeleteHorary.TabIndex = 5;
            this.toolTipFormPrincipal.SetToolTip(this.buttonDeleteHorary, "Seleccione primero el TabPage a eliminar");
            this.buttonDeleteHorary.UseVisualStyleBackColor = true;
            this.buttonDeleteHorary.Click += new System.EventHandler(this.buttonDeleteHorary_Click);
            // 
            // buttonEditHorary
            // 
            this.buttonEditHorary.FlatAppearance.BorderSize = 0;
            this.buttonEditHorary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonEditHorary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonEditHorary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditHorary.Image = global::TimbresIP.Properties.Resources.editc20x20;
            this.buttonEditHorary.Location = new System.Drawing.Point(45, 18);
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
            this.buttonAddHorary.FlatAppearance.BorderSize = 0;
            this.buttonAddHorary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonAddHorary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonAddHorary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddHorary.Image = global::TimbresIP.Properties.Resources.addc20x20;
            this.buttonAddHorary.Location = new System.Drawing.Point(6, 18);
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
            this.groupBoxManageHorary.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxManageHorary.Controls.Add(this.buttonAddHorary);
            this.groupBoxManageHorary.Controls.Add(this.buttonDeleteHorary);
            this.groupBoxManageHorary.Controls.Add(this.buttonEditHorary);
            this.groupBoxManageHorary.Location = new System.Drawing.Point(472, 71);
            this.groupBoxManageHorary.Name = "groupBoxManageHorary";
            this.groupBoxManageHorary.Size = new System.Drawing.Size(129, 61);
            this.groupBoxManageHorary.TabIndex = 6;
            this.groupBoxManageHorary.TabStop = false;
            this.groupBoxManageHorary.Text = "Gestionar Horarios";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxActions.Controls.Add(this.buttonSaveAll);
            this.groupBoxActions.Location = new System.Drawing.Point(621, 71);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(79, 61);
            this.groupBoxActions.TabIndex = 7;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Acciones";
            // 
            // buttonSaveAll
            // 
            this.buttonSaveAll.FlatAppearance.BorderSize = 0;
            this.buttonSaveAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonSaveAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveAll.Image = global::TimbresIP.Properties.Resources.savec24x24;
            this.buttonSaveAll.Location = new System.Drawing.Point(22, 18);
            this.buttonSaveAll.Name = "buttonSaveAll";
            this.buttonSaveAll.Size = new System.Drawing.Size(33, 30);
            this.buttonSaveAll.TabIndex = 0;
            this.buttonSaveAll.UseVisualStyleBackColor = true;
            this.buttonSaveAll.Click += new System.EventHandler(this.buttonSaveAll_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = global::TimbresIP.Properties.Resources.soundwhite32x32;
            this.pictureBoxLogo.Location = new System.Drawing.Point(222, 28);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxLogo.TabIndex = 9;
            this.pictureBoxLogo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 640);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxManageHorary);
            this.Controls.Add(this.groupBoxGeneralSound);
            this.Controls.Add(this.groupBoxHorary);
            this.Controls.Add(this.groupBoxMainControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador de Horarios";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.groupBoxMainControl.ResumeLayout(false);
            this.groupBoxMainControl.PerformLayout();
            this.groupBoxHorary.ResumeLayout(false);
            this.groupBoxManageHorary.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}

