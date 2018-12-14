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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.groupBoxMainControl = new System.Windows.Forms.GroupBox();
            this.groupBoxSchedule = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSchedule = new System.Windows.Forms.TabPage();
            this.listViewSchedule = new System.Windows.Forms.ListView();
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSoundTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEnable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderObservations = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxGeneralSound = new System.Windows.Forms.GroupBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.buttonSaveServer = new System.Windows.Forms.Button();
            this.buttonEditServer = new System.Windows.Forms.Button();
            this.groupBoxMainControl.SuspendLayout();
            this.groupBoxSchedule.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSchedule.SuspendLayout();
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
            // groupBoxSchedule
            // 
            this.groupBoxSchedule.Controls.Add(this.tabControl1);
            this.groupBoxSchedule.Location = new System.Drawing.Point(12, 75);
            this.groupBoxSchedule.Name = "groupBoxSchedule";
            this.groupBoxSchedule.Size = new System.Drawing.Size(637, 298);
            this.groupBoxSchedule.TabIndex = 1;
            this.groupBoxSchedule.TabStop = false;
            this.groupBoxSchedule.Text = "Horarios";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSchedule);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 273);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageSchedule
            // 
            this.tabPageSchedule.Controls.Add(this.listViewSchedule);
            this.tabPageSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabPageSchedule.Name = "tabPageSchedule";
            this.tabPageSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchedule.Size = new System.Drawing.Size(617, 247);
            this.tabPageSchedule.TabIndex = 0;
            this.tabPageSchedule.Text = "tabPage1";
            this.tabPageSchedule.UseVisualStyleBackColor = true;
            // 
            // listViewSchedule
            // 
            this.listViewSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumber,
            this.columnHeaderStartTime,
            this.columnHeaderSoundTime,
            this.columnHeaderTone,
            this.columnHeaderEnable,
            this.columnHeaderCall,
            this.columnHeaderObservations});
            this.listViewSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSchedule.Location = new System.Drawing.Point(3, 3);
            this.listViewSchedule.Name = "listViewSchedule";
            this.listViewSchedule.Size = new System.Drawing.Size(611, 241);
            this.listViewSchedule.TabIndex = 0;
            this.listViewSchedule.UseCompatibleStateImageBehavior = false;
            this.listViewSchedule.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "No.";
            this.columnHeaderNumber.Width = 32;
            // 
            // columnHeaderStartTime
            // 
            this.columnHeaderStartTime.Text = "Hora Inicio";
            this.columnHeaderStartTime.Width = 69;
            // 
            // columnHeaderSoundTime
            // 
            this.columnHeaderSoundTime.Text = "Tiempo Sonido";
            this.columnHeaderSoundTime.Width = 91;
            // 
            // columnHeaderTone
            // 
            this.columnHeaderTone.Text = "Tono";
            this.columnHeaderTone.Width = 135;
            // 
            // columnHeaderEnable
            // 
            this.columnHeaderEnable.Text = "Habilitado";
            this.columnHeaderEnable.Width = 61;
            // 
            // columnHeaderCall
            // 
            this.columnHeaderCall.Text = "Llamar";
            this.columnHeaderCall.Width = 49;
            // 
            // columnHeaderObservations
            // 
            this.columnHeaderObservations.Text = "Observaciones";
            this.columnHeaderObservations.Width = 166;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(617, 202);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxGeneralSound
            // 
            this.groupBoxGeneralSound.Location = new System.Drawing.Point(12, 379);
            this.groupBoxGeneralSound.Name = "groupBoxGeneralSound";
            this.groupBoxGeneralSound.Size = new System.Drawing.Size(637, 170);
            this.groupBoxGeneralSound.TabIndex = 2;
            this.groupBoxGeneralSound.TabStop = false;
            this.groupBoxGeneralSound.Text = "Sonidos generales";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Enabled = false;
            this.textBoxServer.Location = new System.Drawing.Point(72, 23);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(128, 20);
            this.textBoxServer.TabIndex = 0;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Enabled = false;
            this.textBoxPort.Location = new System.Drawing.Point(264, 23);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(65, 20);
            this.textBoxPort.TabIndex = 1;
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
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(217, 27);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(41, 13);
            this.labelPort.TabIndex = 3;
            this.labelPort.Text = "Puerto:";
            // 
            // buttonSaveServer
            // 
            this.buttonSaveServer.Enabled = false;
            this.buttonSaveServer.Location = new System.Drawing.Point(437, 23);
            this.buttonSaveServer.Name = "buttonSaveServer";
            this.buttonSaveServer.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveServer.TabIndex = 4;
            this.buttonSaveServer.Text = "Guardar";
            this.buttonSaveServer.UseVisualStyleBackColor = true;
            this.buttonSaveServer.Click += new System.EventHandler(this.buttonSaveServer_Click);
            // 
            // buttonEditServer
            // 
            this.buttonEditServer.Location = new System.Drawing.Point(347, 23);
            this.buttonEditServer.Name = "buttonEditServer";
            this.buttonEditServer.Size = new System.Drawing.Size(75, 23);
            this.buttonEditServer.TabIndex = 5;
            this.buttonEditServer.Text = "Editar";
            this.buttonEditServer.UseVisualStyleBackColor = true;
            this.buttonEditServer.Click += new System.EventHandler(this.buttonEditServer_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 561);
            this.Controls.Add(this.groupBoxGeneralSound);
            this.Controls.Add(this.groupBoxSchedule);
            this.Controls.Add(this.groupBoxMainControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.Text = "Administrador de Horarios";
            this.groupBoxMainControl.ResumeLayout(false);
            this.groupBoxMainControl.PerformLayout();
            this.groupBoxSchedule.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSchedule.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMainControl;
        private System.Windows.Forms.GroupBox groupBoxSchedule;
        private System.Windows.Forms.GroupBox groupBoxGeneralSound;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSchedule;
        private System.Windows.Forms.ListView listViewSchedule;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderStartTime;
        private System.Windows.Forms.ColumnHeader columnHeaderSoundTime;
        private System.Windows.Forms.ColumnHeader columnHeaderTone;
        private System.Windows.Forms.ColumnHeader columnHeaderEnable;
        private System.Windows.Forms.ColumnHeader columnHeaderCall;
        private System.Windows.Forms.ColumnHeader columnHeaderObservations;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonSaveServer;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Button buttonEditServer;
    }
}

