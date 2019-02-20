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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewHorary = new System.Windows.Forms.DataGridView();
            this.ColumnCall = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnEndCall = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.buttonHoraryAddHours = new System.Windows.Forms.Button();
            this.buttonHoraryDelHours = new System.Windows.Forms.Button();
            this.groupBoxHoraryActions = new System.Windows.Forms.GroupBox();
            this.randomIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soundFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.observationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callServerModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.soundFileModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorary)).BeginInit();
            this.groupBoxHoraryExtension.SuspendLayout();
            this.groupBoxHoraryActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundFileModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHorary
            // 
            this.dataGridViewHorary.AllowUserToAddRows = false;
            this.dataGridViewHorary.AllowUserToDeleteRows = false;
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
            this.randomIdDataGridViewTextBoxColumn,
            this.noDataGridViewTextBoxColumn,
            this.startAtDataGridViewTextBoxColumn,
            this.callTimeDataGridViewTextBoxColumn,
            this.soundFileDataGridViewTextBoxColumn,
            this.registerNameDataGridViewTextBoxColumn,
            this.enabledDataGridViewCheckBoxColumn,
            this.ColumnCall,
            this.ColumnEndCall,
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
            this.dataGridViewHorary.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewHorary_DataError);
            this.dataGridViewHorary.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewHorary_RowHeaderMouseClick);
            this.dataGridViewHorary.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHorary_RowLeave);
            this.dataGridViewHorary.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridViewHorary_RowPrePaint);
            this.dataGridViewHorary.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewHorary_RowValidating);
            this.dataGridViewHorary.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewHorary_UserAddedRow);
            // 
            // ColumnCall
            // 
            this.ColumnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCall.HeaderText = "Llamar";
            this.ColumnCall.Name = "ColumnCall";
            this.ColumnCall.Text = "Llamar";
            this.ColumnCall.Width = 40;
            // 
            // ColumnEndCall
            // 
            this.ColumnEndCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnEndCall.HeaderText = "Colgar";
            this.ColumnEndCall.Name = "ColumnEndCall";
            this.ColumnEndCall.Text = "Colgar";
            this.ColumnEndCall.Width = 40;
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
            this.groupBoxHoraryExtension.Size = new System.Drawing.Size(237, 175);
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
            this.buttonHorarySaveExtension.Location = new System.Drawing.Point(134, 132);
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
            this.buttonHoraryEditExtension.Location = new System.Drawing.Point(91, 132);
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
            // buttonHoraryAddHours
            // 
            this.buttonHoraryAddHours.FlatAppearance.BorderSize = 0;
            this.buttonHoraryAddHours.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonHoraryAddHours.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonHoraryAddHours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHoraryAddHours.Image = global::TimbresIP.Properties.Resources.addc20x20;
            this.buttonHoraryAddHours.Location = new System.Drawing.Point(10, 17);
            this.buttonHoraryAddHours.Name = "buttonHoraryAddHours";
            this.buttonHoraryAddHours.Size = new System.Drawing.Size(33, 30);
            this.buttonHoraryAddHours.TabIndex = 7;
            this.buttonHoraryAddHours.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipHorary.SetToolTip(this.buttonHoraryAddHours, "Agregar hora");
            this.buttonHoraryAddHours.UseVisualStyleBackColor = true;
            this.buttonHoraryAddHours.Click += new System.EventHandler(this.buttonHoraryAddHours_Click);
            // 
            // buttonHoraryDelHours
            // 
            this.buttonHoraryDelHours.Enabled = false;
            this.buttonHoraryDelHours.FlatAppearance.BorderSize = 0;
            this.buttonHoraryDelHours.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonHoraryDelHours.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonHoraryDelHours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHoraryDelHours.Image = global::TimbresIP.Properties.Resources.removec20x20;
            this.buttonHoraryDelHours.Location = new System.Drawing.Point(49, 17);
            this.buttonHoraryDelHours.Name = "buttonHoraryDelHours";
            this.buttonHoraryDelHours.Size = new System.Drawing.Size(33, 30);
            this.buttonHoraryDelHours.TabIndex = 8;
            this.buttonHoraryDelHours.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipHorary.SetToolTip(this.buttonHoraryDelHours, "Editar");
            this.buttonHoraryDelHours.UseVisualStyleBackColor = true;
            this.buttonHoraryDelHours.Click += new System.EventHandler(this.buttonHoraryDelHours_Click);
            // 
            // groupBoxHoraryActions
            // 
            this.groupBoxHoraryActions.Controls.Add(this.buttonHoraryDelHours);
            this.groupBoxHoraryActions.Controls.Add(this.buttonHoraryAddHours);
            this.groupBoxHoraryActions.Location = new System.Drawing.Point(620, 189);
            this.groupBoxHoraryActions.Name = "groupBoxHoraryActions";
            this.groupBoxHoraryActions.Size = new System.Drawing.Size(237, 53);
            this.groupBoxHoraryActions.TabIndex = 5;
            this.groupBoxHoraryActions.TabStop = false;
            this.groupBoxHoraryActions.Text = "Acciones sobre las Horas";
            // 
            // randomIdDataGridViewTextBoxColumn
            // 
            this.randomIdDataGridViewTextBoxColumn.DataPropertyName = "randomId";
            this.randomIdDataGridViewTextBoxColumn.HeaderText = "randomId";
            this.randomIdDataGridViewTextBoxColumn.Name = "randomIdDataGridViewTextBoxColumn";
            this.randomIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "no";
            this.noDataGridViewTextBoxColumn.HeaderText = "No.";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.Width = 30;
            // 
            // startAtDataGridViewTextBoxColumn
            // 
            this.startAtDataGridViewTextBoxColumn.DataPropertyName = "startAt";
            dataGridViewCellStyle2.NullValue = null;
            this.startAtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.soundFileDataGridViewTextBoxColumn.FillWeight = 30F;
            this.soundFileDataGridViewTextBoxColumn.HeaderText = "Tono";
            this.soundFileDataGridViewTextBoxColumn.Name = "soundFileDataGridViewTextBoxColumn";
            this.soundFileDataGridViewTextBoxColumn.ReadOnly = true;
            this.soundFileDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // observationsDataGridViewTextBoxColumn
            // 
            this.observationsDataGridViewTextBoxColumn.DataPropertyName = "observations";
            this.observationsDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            this.observationsDataGridViewTextBoxColumn.Name = "observationsDataGridViewTextBoxColumn";
            this.observationsDataGridViewTextBoxColumn.Width = 117;
            // 
            // callServerModelBindingSource
            // 
            this.callServerModelBindingSource.DataSource = typeof(TimbresIP.Model.CallServerModel);
            // 
            // soundFileModelBindingSource
            // 
            this.soundFileModelBindingSource.DataSource = typeof(TimbresIP.Model.SoundFileModel);
            // 
            // HoraryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxHoraryActions);
            this.Controls.Add(this.dataGridViewHorary);
            this.Controls.Add(this.groupBoxHoraryExtension);
            this.Name = "HoraryUserControl";
            this.Size = new System.Drawing.Size(863, 248);
            this.Load += new System.EventHandler(this.HoraryUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorary)).EndInit();
            this.groupBoxHoraryExtension.ResumeLayout(false);
            this.groupBoxHoraryExtension.PerformLayout();
            this.groupBoxHoraryActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundFileModelBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource soundFileModelBindingSource;
        private System.Windows.Forms.GroupBox groupBoxHoraryActions;
        private System.Windows.Forms.Button buttonHoraryDelHours;
        private System.Windows.Forms.Button buttonHoraryAddHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn callTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soundFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCall;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEndCall;
        private System.Windows.Forms.DataGridViewTextBoxColumn observationsDataGridViewTextBoxColumn;
    }
}
