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
            this.groupBoxGeneralSound = new System.Windows.Forms.GroupBox();
            this.menuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSchedule = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listViewSchedule = new System.Windows.Forms.ListView();
            this.columnHeaderStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSoundTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEnable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCall = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderObservations = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxSchedule.SuspendLayout();
            this.menuStripPrincipal.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMainControl
            // 
            this.groupBoxMainControl.Location = new System.Drawing.Point(12, 28);
            this.groupBoxMainControl.Name = "groupBoxMainControl";
            this.groupBoxMainControl.Size = new System.Drawing.Size(637, 83);
            this.groupBoxMainControl.TabIndex = 0;
            this.groupBoxMainControl.TabStop = false;
            this.groupBoxMainControl.Text = "Controles globales";
            // 
            // groupBoxSchedule
            // 
            this.groupBoxSchedule.Controls.Add(this.tabControl1);
            this.groupBoxSchedule.Location = new System.Drawing.Point(12, 117);
            this.groupBoxSchedule.Name = "groupBoxSchedule";
            this.groupBoxSchedule.Size = new System.Drawing.Size(637, 253);
            this.groupBoxSchedule.TabIndex = 1;
            this.groupBoxSchedule.TabStop = false;
            this.groupBoxSchedule.Text = "Horarios";
            // 
            // groupBoxGeneralSound
            // 
            this.groupBoxGeneralSound.Location = new System.Drawing.Point(12, 376);
            this.groupBoxGeneralSound.Name = "groupBoxGeneralSound";
            this.groupBoxGeneralSound.Size = new System.Drawing.Size(637, 170);
            this.groupBoxGeneralSound.TabIndex = 2;
            this.groupBoxGeneralSound.TabStop = false;
            this.groupBoxGeneralSound.Text = "Sonidos generales";
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem});
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Size = new System.Drawing.Size(661, 24);
            this.menuStripPrincipal.TabIndex = 3;
            this.menuStripPrincipal.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSchedule);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 228);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageSchedule
            // 
            this.tabPageSchedule.Controls.Add(this.listViewSchedule);
            this.tabPageSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabPageSchedule.Name = "tabPageSchedule";
            this.tabPageSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchedule.Size = new System.Drawing.Size(617, 202);
            this.tabPageSchedule.TabIndex = 0;
            this.tabPageSchedule.Text = "tabPage1";
            this.tabPageSchedule.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.listViewSchedule.Size = new System.Drawing.Size(611, 196);
            this.listViewSchedule.TabIndex = 0;
            this.listViewSchedule.UseCompatibleStateImageBehavior = false;
            this.listViewSchedule.View = System.Windows.Forms.View.Details;
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
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "No.";
            this.columnHeaderNumber.Width = 32;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 561);
            this.Controls.Add(this.groupBoxGeneralSound);
            this.Controls.Add(this.groupBoxSchedule);
            this.Controls.Add(this.groupBoxMainControl);
            this.Controls.Add(this.menuStripPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripPrincipal;
            this.Name = "FormPrincipal";
            this.Text = "Administrador de Horarios";
            this.groupBoxSchedule.ResumeLayout(false);
            this.menuStripPrincipal.ResumeLayout(false);
            this.menuStripPrincipal.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSchedule.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMainControl;
        private System.Windows.Forms.GroupBox groupBoxSchedule;
        private System.Windows.Forms.GroupBox groupBoxGeneralSound;
        private System.Windows.Forms.MenuStrip menuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
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
    }
}

