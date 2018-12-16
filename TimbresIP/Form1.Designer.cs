namespace TimbresIP
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.groupBoxMainControl = new System.Windows.Forms.GroupBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.groupBoxHorary = new System.Windows.Forms.GroupBox();
            this.tabControlHorary = new System.Windows.Forms.TabControl();
            this.tabPageSchedule1 = new System.Windows.Forms.TabPage();
            this.dataGridViewHorary = new System.Windows.Forms.DataGridView();
            this.ColumnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSoundTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCall = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnObservations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxHoraryExtension = new System.Windows.Forms.GroupBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPasswordExtension = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxExtExtension = new System.Windows.Forms.TextBox();
            this.labelExtension = new System.Windows.Forms.Label();
            this.textBoxIdExtension = new System.Windows.Forms.TextBox();
            this.tabPageSchedule2 = new System.Windows.Forms.TabPage();
            this.imageListTabHorary = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxGeneralSound = new System.Windows.Forms.GroupBox();
            this.buttonDeleteHorary = new System.Windows.Forms.Button();
            this.buttonEditHorary = new System.Windows.Forms.Button();
            this.buttonAddHorary = new System.Windows.Forms.Button();
            this.buttonSaveExtension = new System.Windows.Forms.Button();
            this.buttonEditExtension = new System.Windows.Forms.Button();
            this.buttonEditServer = new System.Windows.Forms.Button();
            this.buttonSaveServer = new System.Windows.Forms.Button();
            this.groupBoxMainControl.SuspendLayout();
            this.groupBoxHorary.SuspendLayout();
            this.tabControlHorary.SuspendLayout();
            this.tabPageSchedule1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorary)).BeginInit();
            this.groupBoxHoraryExtension.SuspendLayout();
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
            // 
            // textBoxServer
            // 
            this.textBoxServer.Enabled = false;
            this.textBoxServer.Location = new System.Drawing.Point(72, 23);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(128, 20);
            this.textBoxServer.TabIndex = 0;
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
            this.tabControlHorary.Controls.Add(this.tabPageSchedule1);
            this.tabControlHorary.Controls.Add(this.tabPageSchedule2);
            this.tabControlHorary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlHorary.ImageList = this.imageListTabHorary;
            this.tabControlHorary.Location = new System.Drawing.Point(3, 16);
            this.tabControlHorary.Name = "tabControlHorary";
            this.tabControlHorary.SelectedIndex = 0;
            this.tabControlHorary.Size = new System.Drawing.Size(871, 279);
            this.tabControlHorary.TabIndex = 0;
            // 
            // tabPageSchedule1
            // 
            this.tabPageSchedule1.Controls.Add(this.dataGridViewHorary);
            this.tabPageSchedule1.Controls.Add(this.groupBoxHoraryExtension);
            this.tabPageSchedule1.ImageIndex = 0;
            this.tabPageSchedule1.Location = new System.Drawing.Point(4, 27);
            this.tabPageSchedule1.Name = "tabPageSchedule1";
            this.tabPageSchedule1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchedule1.Size = new System.Drawing.Size(863, 248);
            this.tabPageSchedule1.TabIndex = 0;
            this.tabPageSchedule1.Text = "tabPage1";
            this.tabPageSchedule1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewHorary
            // 
            this.dataGridViewHorary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHorary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNo,
            this.ColumnHoraInicio,
            this.ColumnSoundTime,
            this.ColumnTone,
            this.ColumnCheck,
            this.ColumnExtension,
            this.ColumnCall,
            this.ColumnObservations});
            this.dataGridViewHorary.Location = new System.Drawing.Point(6, 17);
            this.dataGridViewHorary.Name = "dataGridViewHorary";
            this.dataGridViewHorary.Size = new System.Drawing.Size(599, 224);
            this.dataGridViewHorary.TabIndex = 2;
            // 
            // ColumnNo
            // 
            this.ColumnNo.Frozen = true;
            this.ColumnNo.HeaderText = "No.";
            this.ColumnNo.Name = "ColumnNo";
            this.ColumnNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnNo.Width = 30;
            // 
            // ColumnHoraInicio
            // 
            this.ColumnHoraInicio.HeaderText = "Hora Inicio";
            this.ColumnHoraInicio.Name = "ColumnHoraInicio";
            this.ColumnHoraInicio.Width = 50;
            // 
            // ColumnSoundTime
            // 
            this.ColumnSoundTime.HeaderText = "Tiempo Sonido";
            this.ColumnSoundTime.Name = "ColumnSoundTime";
            this.ColumnSoundTime.Width = 50;
            // 
            // ColumnTone
            // 
            this.ColumnTone.HeaderText = "Tono";
            this.ColumnTone.Name = "ColumnTone";
            this.ColumnTone.Width = 150;
            // 
            // ColumnCheck
            // 
            this.ColumnCheck.HeaderText = "Habilitado";
            this.ColumnCheck.Name = "ColumnCheck";
            this.ColumnCheck.Width = 55;
            // 
            // ColumnExtension
            // 
            this.ColumnExtension.HeaderText = "Extensión";
            this.ColumnExtension.Name = "ColumnExtension";
            this.ColumnExtension.Width = 50;
            // 
            // ColumnCall
            // 
            this.ColumnCall.HeaderText = "Llamar";
            this.ColumnCall.Name = "ColumnCall";
            this.ColumnCall.Width = 40;
            // 
            // ColumnObservations
            // 
            this.ColumnObservations.HeaderText = "Observaciones";
            this.ColumnObservations.Name = "ColumnObservations";
            this.ColumnObservations.Width = 180;
            // 
            // groupBoxHoraryExtension
            // 
            this.groupBoxHoraryExtension.Controls.Add(this.buttonSaveExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.buttonEditExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.labelPassword);
            this.groupBoxHoraryExtension.Controls.Add(this.textBoxPasswordExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.labelID);
            this.groupBoxHoraryExtension.Controls.Add(this.textBoxExtExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.labelExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.textBoxIdExtension);
            this.groupBoxHoraryExtension.Location = new System.Drawing.Point(620, 6);
            this.groupBoxHoraryExtension.Name = "groupBoxHoraryExtension";
            this.groupBoxHoraryExtension.Size = new System.Drawing.Size(237, 235);
            this.groupBoxHoraryExtension.TabIndex = 1;
            this.groupBoxHoraryExtension.TabStop = false;
            this.groupBoxHoraryExtension.Text = "Extensión";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(7, 106);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxPasswordExtension
            // 
            this.textBoxPasswordExtension.Enabled = false;
            this.textBoxPasswordExtension.Location = new System.Drawing.Point(67, 102);
            this.textBoxPasswordExtension.Name = "textBoxPasswordExtension";
            this.textBoxPasswordExtension.Size = new System.Drawing.Size(100, 20);
            this.textBoxPasswordExtension.TabIndex = 4;
            this.textBoxPasswordExtension.UseSystemPasswordChar = true;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(7, 34);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 13);
            this.labelID.TabIndex = 3;
            this.labelID.Text = "ID:";
            // 
            // textBoxExtExtension
            // 
            this.textBoxExtExtension.Enabled = false;
            this.textBoxExtExtension.Location = new System.Drawing.Point(67, 67);
            this.textBoxExtExtension.Name = "textBoxExtExtension";
            this.textBoxExtExtension.Size = new System.Drawing.Size(100, 20);
            this.textBoxExtExtension.TabIndex = 2;
            // 
            // labelExtension
            // 
            this.labelExtension.AutoSize = true;
            this.labelExtension.Location = new System.Drawing.Point(7, 70);
            this.labelExtension.Name = "labelExtension";
            this.labelExtension.Size = new System.Drawing.Size(56, 13);
            this.labelExtension.TabIndex = 1;
            this.labelExtension.Text = "Extensión:";
            // 
            // textBoxIdExtension
            // 
            this.textBoxIdExtension.Enabled = false;
            this.textBoxIdExtension.Location = new System.Drawing.Point(67, 31);
            this.textBoxIdExtension.Name = "textBoxIdExtension";
            this.textBoxIdExtension.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdExtension.TabIndex = 0;
            // 
            // tabPageSchedule2
            // 
            this.tabPageSchedule2.ImageIndex = 0;
            this.tabPageSchedule2.Location = new System.Drawing.Point(4, 27);
            this.tabPageSchedule2.Name = "tabPageSchedule2";
            this.tabPageSchedule2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchedule2.Size = new System.Drawing.Size(863, 248);
            this.tabPageSchedule2.TabIndex = 1;
            this.tabPageSchedule2.Text = "tabPage2";
            this.tabPageSchedule2.UseVisualStyleBackColor = true;
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
            // buttonSaveExtension
            // 
            this.buttonSaveExtension.Enabled = false;
            this.buttonSaveExtension.Image = global::TimbresIP.Properties.Resources.savec20x20;
            this.buttonSaveExtension.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveExtension.Location = new System.Drawing.Point(92, 162);
            this.buttonSaveExtension.Name = "buttonSaveExtension";
            this.buttonSaveExtension.Size = new System.Drawing.Size(75, 30);
            this.buttonSaveExtension.TabIndex = 7;
            this.buttonSaveExtension.Text = "Guardar";
            this.buttonSaveExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSaveExtension.UseVisualStyleBackColor = true;
            this.buttonSaveExtension.Click += new System.EventHandler(this.buttonSaveExtension_Click);
            // 
            // buttonEditExtension
            // 
            this.buttonEditExtension.Image = global::TimbresIP.Properties.Resources.editc20x20;
            this.buttonEditExtension.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditExtension.Location = new System.Drawing.Point(10, 162);
            this.buttonEditExtension.Name = "buttonEditExtension";
            this.buttonEditExtension.Size = new System.Drawing.Size(75, 30);
            this.buttonEditExtension.TabIndex = 6;
            this.buttonEditExtension.Text = "Editar";
            this.buttonEditExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEditExtension.UseVisualStyleBackColor = true;
            this.buttonEditExtension.Click += new System.EventHandler(this.buttonEditExtension_Click);
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
            // FormPrincipal
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
            this.Name = "FormPrincipal";
            this.Text = "Administrador de Horarios";
            this.groupBoxMainControl.ResumeLayout(false);
            this.groupBoxMainControl.PerformLayout();
            this.groupBoxHorary.ResumeLayout(false);
            this.tabControlHorary.ResumeLayout(false);
            this.tabPageSchedule1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorary)).EndInit();
            this.groupBoxHoraryExtension.ResumeLayout(false);
            this.groupBoxHoraryExtension.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMainControl;
        private System.Windows.Forms.GroupBox groupBoxHorary;
        private System.Windows.Forms.GroupBox groupBoxGeneralSound;
        private System.Windows.Forms.TabControl tabControlHorary;
        private System.Windows.Forms.TabPage tabPageSchedule1;
        private System.Windows.Forms.TabPage tabPageSchedule2;
        private System.Windows.Forms.Button buttonSaveServer;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Button buttonEditServer;
        private System.Windows.Forms.GroupBox groupBoxHoraryExtension;
        private System.Windows.Forms.Button buttonSaveExtension;
        private System.Windows.Forms.Button buttonEditExtension;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPasswordExtension;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxExtExtension;
        private System.Windows.Forms.Label labelExtension;
        private System.Windows.Forms.TextBox textBoxIdExtension;
        private System.Windows.Forms.DataGridView dataGridViewHorary;
        private System.Windows.Forms.Button buttonAddHorary;
        private System.Windows.Forms.Button buttonEditHorary;
        private System.Windows.Forms.Button buttonDeleteHorary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSoundTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTone;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExtension;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCall;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnObservations;
        private System.Windows.Forms.ImageList imageListTabHorary;
    }
}

