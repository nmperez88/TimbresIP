﻿namespace TimbresIP
{
    partial class HoraryUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewHorary = new System.Windows.Forms.DataGridView();
            this.ColumnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSoundTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCall = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnObservations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxHoraryExtension = new System.Windows.Forms.GroupBox();
            this.buttonHorarySaveExtension = new System.Windows.Forms.Button();
            this.buttonHoraryEditExtension = new System.Windows.Forms.Button();
            this.labelHoraryPassword = new System.Windows.Forms.Label();
            this.textBoxHoraryPasswordExtension = new System.Windows.Forms.TextBox();
            this.labelHoraryID = new System.Windows.Forms.Label();
            this.textBoxHoraryExtExtension = new System.Windows.Forms.TextBox();
            this.labelHoraryExtension = new System.Windows.Forms.Label();
            this.textBoxHoraryIdExtension = new System.Windows.Forms.TextBox();
            this.toolTipHorary = new System.Windows.Forms.ToolTip(this.components);
            this.ColumnTone = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.randomIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soundFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.registerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callServerModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorary)).BeginInit();
            this.groupBoxHoraryExtension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHorary
            // 
            this.dataGridViewHorary.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHorary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHorary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHorary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNo,
            this.ColumnHoraInicio,
            this.ColumnSoundTime,
            this.ColumnTone,
            this.ColumnCheck,
            this.ColumnExtension,
            this.ColumnCall,
            this.ColumnObservations,
            this.randomIdDataGridViewTextBoxColumn,
            this.noDataGridViewTextBoxColumn,
            this.startAtDataGridViewTextBoxColumn,
            this.callTimeDataGridViewTextBoxColumn,
            this.soundFileDataGridViewTextBoxColumn,
            this.enabledDataGridViewCheckBoxColumn,
            this.registerNameDataGridViewTextBoxColumn,
            this.observationsDataGridViewTextBoxColumn});
            this.dataGridViewHorary.DataSource = this.callServerModelBindingSource;
            this.dataGridViewHorary.Location = new System.Drawing.Point(6, 18);
            this.dataGridViewHorary.Name = "dataGridViewHorary";
            this.dataGridViewHorary.RowHeadersWidth = 30;
            this.dataGridViewHorary.Size = new System.Drawing.Size(599, 224);
            this.dataGridViewHorary.TabIndex = 4;
            this.dataGridViewHorary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHorary_CellClick);
            this.dataGridViewHorary.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewHorary_CellPainting);
            this.dataGridViewHorary.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewHorary_CellValidating);
            this.dataGridViewHorary.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHorary_RowLeave);
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
            this.ColumnHoraInicio.DataPropertyName = "startAt";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnHoraInicio.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnHoraInicio.HeaderText = "H/Inicio";
            this.ColumnHoraInicio.Name = "ColumnHoraInicio";
            this.ColumnHoraInicio.Width = 50;
            // 
            // ColumnSoundTime
            // 
            this.ColumnSoundTime.DataPropertyName = "callTime";
            this.ColumnSoundTime.HeaderText = "T/Sonido";
            this.ColumnSoundTime.Name = "ColumnSoundTime";
            this.ColumnSoundTime.Width = 55;
            // 
            // ColumnCheck
            // 
            this.ColumnCheck.DataPropertyName = "enabled";
            this.ColumnCheck.HeaderText = "Habilitado";
            this.ColumnCheck.Name = "ColumnCheck";
            this.ColumnCheck.Width = 55;
            // 
            // ColumnExtension
            // 
            this.ColumnExtension.DataPropertyName = "registerName";
            this.ColumnExtension.HeaderText = "Extensión";
            this.ColumnExtension.Name = "ColumnExtension";
            this.ColumnExtension.Width = 60;
            // 
            // ColumnCall
            // 
            this.ColumnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCall.HeaderText = "Llamar";
            this.ColumnCall.Name = "ColumnCall";
            this.ColumnCall.Text = "Llamar";
            this.ColumnCall.Width = 40;
            // 
            // ColumnObservations
            // 
            this.ColumnObservations.DataPropertyName = "observations";
            this.ColumnObservations.HeaderText = "Observaciones";
            this.ColumnObservations.Name = "ColumnObservations";
            this.ColumnObservations.Width = 157;
            // 
            // groupBoxHoraryExtension
            // 
            this.groupBoxHoraryExtension.Controls.Add(this.buttonHorarySaveExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.buttonHoraryEditExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.labelHoraryPassword);
            this.groupBoxHoraryExtension.Controls.Add(this.textBoxHoraryPasswordExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.labelHoraryID);
            this.groupBoxHoraryExtension.Controls.Add(this.textBoxHoraryExtExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.labelHoraryExtension);
            this.groupBoxHoraryExtension.Controls.Add(this.textBoxHoraryIdExtension);
            this.groupBoxHoraryExtension.Location = new System.Drawing.Point(620, 7);
            this.groupBoxHoraryExtension.Name = "groupBoxHoraryExtension";
            this.groupBoxHoraryExtension.Size = new System.Drawing.Size(237, 235);
            this.groupBoxHoraryExtension.TabIndex = 3;
            this.groupBoxHoraryExtension.TabStop = false;
            this.groupBoxHoraryExtension.Text = "Extensión";
            // 
            // buttonHorarySaveExtension
            // 
            this.buttonHorarySaveExtension.Enabled = false;
            this.buttonHorarySaveExtension.Image = global::TimbresIP.Properties.Resources.savec20x20;
            this.buttonHorarySaveExtension.Location = new System.Drawing.Point(134, 162);
            this.buttonHorarySaveExtension.Name = "buttonHorarySaveExtension";
            this.buttonHorarySaveExtension.Size = new System.Drawing.Size(33, 30);
            this.buttonHorarySaveExtension.TabIndex = 7;
            this.buttonHorarySaveExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipHorary.SetToolTip(this.buttonHorarySaveExtension, "Guardar");
            this.buttonHorarySaveExtension.UseVisualStyleBackColor = true;
            this.buttonHorarySaveExtension.Click += new System.EventHandler(this.buttonSaveExtension_Click);
            // 
            // buttonHoraryEditExtension
            // 
            this.buttonHoraryEditExtension.Image = global::TimbresIP.Properties.Resources.editc20x20;
            this.buttonHoraryEditExtension.Location = new System.Drawing.Point(91, 162);
            this.buttonHoraryEditExtension.Name = "buttonHoraryEditExtension";
            this.buttonHoraryEditExtension.Size = new System.Drawing.Size(33, 30);
            this.buttonHoraryEditExtension.TabIndex = 6;
            this.buttonHoraryEditExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipHorary.SetToolTip(this.buttonHoraryEditExtension, "Editar");
            this.buttonHoraryEditExtension.UseVisualStyleBackColor = true;
            this.buttonHoraryEditExtension.Click += new System.EventHandler(this.buttonEditExtension_Click);
            // 
            // labelHoraryPassword
            // 
            this.labelHoraryPassword.AutoSize = true;
            this.labelHoraryPassword.Location = new System.Drawing.Point(7, 106);
            this.labelHoraryPassword.Name = "labelHoraryPassword";
            this.labelHoraryPassword.Size = new System.Drawing.Size(56, 13);
            this.labelHoraryPassword.TabIndex = 5;
            this.labelHoraryPassword.Text = "Password:";
            // 
            // textBoxHoraryPasswordExtension
            // 
            this.textBoxHoraryPasswordExtension.Enabled = false;
            this.textBoxHoraryPasswordExtension.Location = new System.Drawing.Point(67, 102);
            this.textBoxHoraryPasswordExtension.Name = "textBoxHoraryPasswordExtension";
            this.textBoxHoraryPasswordExtension.Size = new System.Drawing.Size(100, 20);
            this.textBoxHoraryPasswordExtension.TabIndex = 4;
            this.textBoxHoraryPasswordExtension.Text = "Caeunagota";
            this.textBoxHoraryPasswordExtension.UseSystemPasswordChar = true;
            // 
            // labelHoraryID
            // 
            this.labelHoraryID.AutoSize = true;
            this.labelHoraryID.Location = new System.Drawing.Point(7, 34);
            this.labelHoraryID.Name = "labelHoraryID";
            this.labelHoraryID.Size = new System.Drawing.Size(21, 13);
            this.labelHoraryID.TabIndex = 3;
            this.labelHoraryID.Text = "ID:";
            // 
            // textBoxHoraryExtExtension
            // 
            this.textBoxHoraryExtExtension.Enabled = false;
            this.textBoxHoraryExtExtension.Location = new System.Drawing.Point(67, 67);
            this.textBoxHoraryExtExtension.Name = "textBoxHoraryExtExtension";
            this.textBoxHoraryExtExtension.Size = new System.Drawing.Size(100, 20);
            this.textBoxHoraryExtExtension.TabIndex = 2;
            this.textBoxHoraryExtExtension.Text = "4578";
            this.textBoxHoraryExtExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHoraryExtExtension_KeyPress);
            // 
            // labelHoraryExtension
            // 
            this.labelHoraryExtension.AutoSize = true;
            this.labelHoraryExtension.Location = new System.Drawing.Point(7, 70);
            this.labelHoraryExtension.Name = "labelHoraryExtension";
            this.labelHoraryExtension.Size = new System.Drawing.Size(56, 13);
            this.labelHoraryExtension.TabIndex = 1;
            this.labelHoraryExtension.Text = "Extensión:";
            // 
            // textBoxHoraryIdExtension
            // 
            this.textBoxHoraryIdExtension.Enabled = false;
            this.textBoxHoraryIdExtension.Location = new System.Drawing.Point(67, 31);
            this.textBoxHoraryIdExtension.Name = "textBoxHoraryIdExtension";
            this.textBoxHoraryIdExtension.Size = new System.Drawing.Size(100, 20);
            this.textBoxHoraryIdExtension.TabIndex = 0;
            this.textBoxHoraryIdExtension.Text = "4578";
            this.textBoxHoraryIdExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHoraryIdExtension_KeyPress);
            // 
            // toolTipHorary
            // 
            this.toolTipHorary.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipHorary.ToolTipTitle = "Información";
            // 
            // ColumnTone
            // 
            this.ColumnTone.DataPropertyName = "soundFile";
            this.ColumnTone.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnTone.HeaderText = "Tono";
            this.ColumnTone.Name = "ColumnTone";
            this.ColumnTone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnTone.Width = 114;
            // 
            // randomIdDataGridViewTextBoxColumn
            // 
            this.randomIdDataGridViewTextBoxColumn.DataPropertyName = "randomId";
            this.randomIdDataGridViewTextBoxColumn.HeaderText = "randomId";
            this.randomIdDataGridViewTextBoxColumn.Name = "randomIdDataGridViewTextBoxColumn";
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "no";
            this.noDataGridViewTextBoxColumn.HeaderText = "no";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            // 
            // startAtDataGridViewTextBoxColumn
            // 
            this.startAtDataGridViewTextBoxColumn.DataPropertyName = "startAt";
            this.startAtDataGridViewTextBoxColumn.HeaderText = "startAt";
            this.startAtDataGridViewTextBoxColumn.Name = "startAtDataGridViewTextBoxColumn";
            // 
            // callTimeDataGridViewTextBoxColumn
            // 
            this.callTimeDataGridViewTextBoxColumn.DataPropertyName = "callTime";
            this.callTimeDataGridViewTextBoxColumn.HeaderText = "callTime";
            this.callTimeDataGridViewTextBoxColumn.Name = "callTimeDataGridViewTextBoxColumn";
            // 
            // soundFileDataGridViewTextBoxColumn
            // 
            this.soundFileDataGridViewTextBoxColumn.DataPropertyName = "soundFile";
            this.soundFileDataGridViewTextBoxColumn.HeaderText = "soundFile";
            this.soundFileDataGridViewTextBoxColumn.Name = "soundFileDataGridViewTextBoxColumn";
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "enabled";
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "enabled";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            // 
            // registerNameDataGridViewTextBoxColumn
            // 
            this.registerNameDataGridViewTextBoxColumn.DataPropertyName = "registerName";
            this.registerNameDataGridViewTextBoxColumn.HeaderText = "registerName";
            this.registerNameDataGridViewTextBoxColumn.Name = "registerNameDataGridViewTextBoxColumn";
            // 
            // observationsDataGridViewTextBoxColumn
            // 
            this.observationsDataGridViewTextBoxColumn.DataPropertyName = "observations";
            this.observationsDataGridViewTextBoxColumn.HeaderText = "observations";
            this.observationsDataGridViewTextBoxColumn.Name = "observationsDataGridViewTextBoxColumn";
            // 
            // callServerModelBindingSource
            // 
            this.callServerModelBindingSource.DataSource = typeof(TimbresIP.Model.CallServerModel);
            // 
            // HoraryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewHorary);
            this.Controls.Add(this.groupBoxHoraryExtension);
            this.Name = "HoraryUserControl";
            this.Size = new System.Drawing.Size(863, 248);
            this.Load += new System.EventHandler(this.HoraryUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorary)).EndInit();
            this.groupBoxHoraryExtension.ResumeLayout(false);
            this.groupBoxHoraryExtension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHorary;
        private System.Windows.Forms.GroupBox groupBoxHoraryExtension;
        private System.Windows.Forms.Button buttonHorarySaveExtension;
        private System.Windows.Forms.Button buttonHoraryEditExtension;
        private System.Windows.Forms.Label labelHoraryPassword;
        private System.Windows.Forms.TextBox textBoxHoraryPasswordExtension;
        private System.Windows.Forms.Label labelHoraryID;
        private System.Windows.Forms.TextBox textBoxHoraryExtExtension;
        private System.Windows.Forms.Label labelHoraryExtension;
        private System.Windows.Forms.TextBox textBoxHoraryIdExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSoundTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnTone;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExtension;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCall;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnObservations;
        private System.Windows.Forms.BindingSource callServerModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn callTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soundFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observationsDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolTip toolTipHorary;
    }
}
