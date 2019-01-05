namespace TimbresIP
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
            this.dataGridViewHorary = new System.Windows.Forms.DataGridView();
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
            this.callServerModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.callServerModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soundFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.registerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCall = new System.Windows.Forms.DataGridViewButtonColumn();
            this.observationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorary)).BeginInit();
            this.groupBoxHoraryExtension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource1)).BeginInit();
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
            this.noDataGridViewTextBoxColumn,
            this.startAtDataGridViewTextBoxColumn,
            this.callTimeDataGridViewTextBoxColumn,
            this.soundFileDataGridViewTextBoxColumn,
            this.registerNameDataGridViewTextBoxColumn,
            this.enabledDataGridViewCheckBoxColumn,
            this.ColumnCall,
            this.observationsDataGridViewTextBoxColumn,
            this.randomIdDataGridViewTextBoxColumn});
            this.dataGridViewHorary.DataSource = this.callServerModelBindingSource;
            this.dataGridViewHorary.Location = new System.Drawing.Point(6, 18);
            this.dataGridViewHorary.Name = "dataGridViewHorary";
            this.dataGridViewHorary.RowHeadersWidth = 30;
            this.dataGridViewHorary.Size = new System.Drawing.Size(599, 224);
            this.dataGridViewHorary.TabIndex = 4;
            this.dataGridViewHorary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHorary_CellClick);
            this.dataGridViewHorary.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewHorary_CellPainting);
            this.dataGridViewHorary.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewHorary_CellValidating);
            this.dataGridViewHorary.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewHorary_DataError);
            this.dataGridViewHorary.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHorary_RowLeave);
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
            this.buttonHorarySaveExtension.FlatAppearance.BorderSize = 0;
            this.buttonHorarySaveExtension.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonHorarySaveExtension.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonHorarySaveExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.buttonHoraryEditExtension.FlatAppearance.BorderSize = 0;
            this.buttonHoraryEditExtension.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonHoraryEditExtension.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonHoraryEditExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.textBoxHoraryIdExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHoraryIdExtension_KeyPress);
            // 
            // toolTipHorary
            // 
            this.toolTipHorary.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipHorary.ToolTipTitle = "Información";
            // 
            // callServerModelBindingSource
            // 
            this.callServerModelBindingSource.DataSource = typeof(TimbresIP.Model.CallServerModel);
            // 
            // callServerModelBindingSource1
            // 
            this.callServerModelBindingSource1.DataSource = typeof(TimbresIP.Model.CallServerModel);
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "no";
            this.noDataGridViewTextBoxColumn.HeaderText = "No.";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.Width = 30;
            // 
            // startAtDataGridViewTextBoxColumn
            // 
            this.startAtDataGridViewTextBoxColumn.DataPropertyName = "startAt";
            this.startAtDataGridViewTextBoxColumn.HeaderText = "H/Inicio";
            this.startAtDataGridViewTextBoxColumn.Name = "startAtDataGridViewTextBoxColumn";
            this.startAtDataGridViewTextBoxColumn.Width = 50;
            // 
            // callTimeDataGridViewTextBoxColumn
            // 
            this.callTimeDataGridViewTextBoxColumn.DataPropertyName = "callTime";
            this.callTimeDataGridViewTextBoxColumn.HeaderText = "T/Sonido";
            this.callTimeDataGridViewTextBoxColumn.Name = "callTimeDataGridViewTextBoxColumn";
            this.callTimeDataGridViewTextBoxColumn.Width = 55;
            // 
            // soundFileDataGridViewTextBoxColumn
            // 
            this.soundFileDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.soundFileDataGridViewTextBoxColumn.DataPropertyName = "soundFile";
            this.soundFileDataGridViewTextBoxColumn.DataSource = this.callServerModelBindingSource;
            this.soundFileDataGridViewTextBoxColumn.DisplayMember = "soundFile";
            this.soundFileDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.soundFileDataGridViewTextBoxColumn.DropDownWidth = 200;
            this.soundFileDataGridViewTextBoxColumn.FillWeight = 30F;
            this.soundFileDataGridViewTextBoxColumn.HeaderText = "Tono";
            this.soundFileDataGridViewTextBoxColumn.Name = "soundFileDataGridViewTextBoxColumn";
            this.soundFileDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.soundFileDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.soundFileDataGridViewTextBoxColumn.ValueMember = "soundFile";
            // 
            // registerNameDataGridViewTextBoxColumn
            // 
            this.registerNameDataGridViewTextBoxColumn.DataPropertyName = "registerName";
            this.registerNameDataGridViewTextBoxColumn.HeaderText = "Extensión";
            this.registerNameDataGridViewTextBoxColumn.Name = "registerNameDataGridViewTextBoxColumn";
            this.registerNameDataGridViewTextBoxColumn.Width = 60;
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "enabled";
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "Habilitado";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.Width = 55;
            // 
            // ColumnCall
            // 
            this.ColumnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCall.HeaderText = "Llamar";
            this.ColumnCall.Name = "ColumnCall";
            this.ColumnCall.Text = "Llamar";
            this.ColumnCall.Width = 40;
            // 
            // observationsDataGridViewTextBoxColumn
            // 
            this.observationsDataGridViewTextBoxColumn.DataPropertyName = "observations";
            this.observationsDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            this.observationsDataGridViewTextBoxColumn.Name = "observationsDataGridViewTextBoxColumn";
            this.observationsDataGridViewTextBoxColumn.Width = 157;
            // 
            // randomIdDataGridViewTextBoxColumn
            // 
            this.randomIdDataGridViewTextBoxColumn.DataPropertyName = "randomId";
            this.randomIdDataGridViewTextBoxColumn.HeaderText = "randomId";
            this.randomIdDataGridViewTextBoxColumn.Name = "randomIdDataGridViewTextBoxColumn";
            this.randomIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // HoraryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dataGridViewHorary);
            this.Controls.Add(this.groupBoxHoraryExtension);
            this.Name = "HoraryUserControl";
            this.Size = new System.Drawing.Size(863, 248);
            this.Load += new System.EventHandler(this.HoraryUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorary)).EndInit();
            this.groupBoxHoraryExtension.ResumeLayout(false);
            this.groupBoxHoraryExtension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource1)).EndInit();
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
        private System.Windows.Forms.BindingSource callServerModelBindingSource;
        private System.Windows.Forms.ToolTip toolTipHorary;
        private System.Windows.Forms.BindingSource callServerModelBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn callTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn soundFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCall;
        private System.Windows.Forms.DataGridViewTextBoxColumn observationsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomIdDataGridViewTextBoxColumn;
    }
}
