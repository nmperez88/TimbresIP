namespace STA
{
    partial class GeneralRingUserControl
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
            this.groupBoxGeneralSoundExtension = new System.Windows.Forms.GroupBox();
            this.buttonGeneralSoundSaveExtension = new System.Windows.Forms.Button();
            this.buttonGeneralSoundEditExtension = new System.Windows.Forms.Button();
            this.labelGeneralSoundPassword = new System.Windows.Forms.Label();
            this.textBoxGeneralSoundPasswordExtension = new System.Windows.Forms.TextBox();
            this.labelGeneralSoundID = new System.Windows.Forms.Label();
            this.textBoxGeneralSoundExtExtension = new System.Windows.Forms.TextBox();
            this.labelGeneralSoundExtension = new System.Windows.Forms.Label();
            this.textBoxGeneralSoundIdExtension = new System.Windows.Forms.TextBox();
            this.dataGridViewGeneralSound = new System.Windows.Forms.DataGridView();
            this.callServerModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipGeneralRings = new System.Windows.Forms.ToolTip(this.components);
            this.buttonGeneralAddSounds = new System.Windows.Forms.Button();
            this.buttonGeneralDelSounds = new System.Windows.Forms.Button();
            this.groupBoxGeneralActions = new System.Windows.Forms.GroupBox();
            this.soundFileModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.callTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soundFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCall = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnEndCall = new System.Windows.Forms.DataGridViewButtonColumn();
            this.modeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBoxGeneralSoundExtension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGeneralSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource)).BeginInit();
            this.groupBoxGeneralActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundFileModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxGeneralSoundExtension
            // 
            this.groupBoxGeneralSoundExtension.Controls.Add(this.buttonGeneralSoundSaveExtension);
            this.groupBoxGeneralSoundExtension.Controls.Add(this.buttonGeneralSoundEditExtension);
            this.groupBoxGeneralSoundExtension.Controls.Add(this.labelGeneralSoundPassword);
            this.groupBoxGeneralSoundExtension.Controls.Add(this.textBoxGeneralSoundPasswordExtension);
            this.groupBoxGeneralSoundExtension.Controls.Add(this.labelGeneralSoundID);
            this.groupBoxGeneralSoundExtension.Controls.Add(this.textBoxGeneralSoundExtExtension);
            this.groupBoxGeneralSoundExtension.Controls.Add(this.labelGeneralSoundExtension);
            this.groupBoxGeneralSoundExtension.Controls.Add(this.textBoxGeneralSoundIdExtension);
            this.groupBoxGeneralSoundExtension.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxGeneralSoundExtension.Location = new System.Drawing.Point(634, 0);
            this.groupBoxGeneralSoundExtension.Name = "groupBoxGeneralSoundExtension";
            this.groupBoxGeneralSoundExtension.Size = new System.Drawing.Size(237, 162);
            this.groupBoxGeneralSoundExtension.TabIndex = 0;
            this.groupBoxGeneralSoundExtension.TabStop = false;
            this.groupBoxGeneralSoundExtension.Text = "Configurar extensión";
            this.toolTipGeneralRings.SetToolTip(this.groupBoxGeneralSoundExtension, "Configurar extensión de los sonidos generales");
            // 
            // buttonGeneralSoundSaveExtension
            // 
            this.buttonGeneralSoundSaveExtension.Enabled = false;
            this.buttonGeneralSoundSaveExtension.FlatAppearance.BorderSize = 0;
            this.buttonGeneralSoundSaveExtension.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGeneralSoundSaveExtension.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGeneralSoundSaveExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGeneralSoundSaveExtension.Image = global::STA.Properties.Resources.savec20x20;
            this.buttonGeneralSoundSaveExtension.Location = new System.Drawing.Point(132, 115);
            this.buttonGeneralSoundSaveExtension.Name = "buttonGeneralSoundSaveExtension";
            this.buttonGeneralSoundSaveExtension.Size = new System.Drawing.Size(33, 30);
            this.buttonGeneralSoundSaveExtension.TabIndex = 15;
            this.buttonGeneralSoundSaveExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipGeneralRings.SetToolTip(this.buttonGeneralSoundSaveExtension, "Guardar");
            this.buttonGeneralSoundSaveExtension.UseVisualStyleBackColor = true;
            this.buttonGeneralSoundSaveExtension.Click += new System.EventHandler(this.buttonGeneralSoundSaveExtension_Click);
            // 
            // buttonGeneralSoundEditExtension
            // 
            this.buttonGeneralSoundEditExtension.FlatAppearance.BorderSize = 0;
            this.buttonGeneralSoundEditExtension.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGeneralSoundEditExtension.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGeneralSoundEditExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGeneralSoundEditExtension.Image = global::STA.Properties.Resources.editc20x20;
            this.buttonGeneralSoundEditExtension.Location = new System.Drawing.Point(89, 115);
            this.buttonGeneralSoundEditExtension.Name = "buttonGeneralSoundEditExtension";
            this.buttonGeneralSoundEditExtension.Size = new System.Drawing.Size(33, 30);
            this.buttonGeneralSoundEditExtension.TabIndex = 14;
            this.buttonGeneralSoundEditExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipGeneralRings.SetToolTip(this.buttonGeneralSoundEditExtension, "Editar");
            this.buttonGeneralSoundEditExtension.UseVisualStyleBackColor = true;
            this.buttonGeneralSoundEditExtension.Click += new System.EventHandler(this.buttonGeneralSoundEditExtension_Click);
            // 
            // labelGeneralSoundPassword
            // 
            this.labelGeneralSoundPassword.AutoSize = true;
            this.labelGeneralSoundPassword.Location = new System.Drawing.Point(6, 88);
            this.labelGeneralSoundPassword.Name = "labelGeneralSoundPassword";
            this.labelGeneralSoundPassword.Size = new System.Drawing.Size(56, 13);
            this.labelGeneralSoundPassword.TabIndex = 13;
            this.labelGeneralSoundPassword.Text = "Password:";
            // 
            // textBoxGeneralSoundPasswordExtension
            // 
            this.textBoxGeneralSoundPasswordExtension.Enabled = false;
            this.textBoxGeneralSoundPasswordExtension.Location = new System.Drawing.Point(66, 84);
            this.textBoxGeneralSoundPasswordExtension.Name = "textBoxGeneralSoundPasswordExtension";
            this.textBoxGeneralSoundPasswordExtension.Size = new System.Drawing.Size(100, 20);
            this.textBoxGeneralSoundPasswordExtension.TabIndex = 12;
            this.textBoxGeneralSoundPasswordExtension.UseSystemPasswordChar = true;
            // 
            // labelGeneralSoundID
            // 
            this.labelGeneralSoundID.AutoSize = true;
            this.labelGeneralSoundID.Location = new System.Drawing.Point(6, 16);
            this.labelGeneralSoundID.Name = "labelGeneralSoundID";
            this.labelGeneralSoundID.Size = new System.Drawing.Size(21, 13);
            this.labelGeneralSoundID.TabIndex = 11;
            this.labelGeneralSoundID.Text = "ID:";
            // 
            // textBoxGeneralSoundExtExtension
            // 
            this.textBoxGeneralSoundExtExtension.Enabled = false;
            this.textBoxGeneralSoundExtExtension.Location = new System.Drawing.Point(66, 49);
            this.textBoxGeneralSoundExtExtension.Name = "textBoxGeneralSoundExtExtension";
            this.textBoxGeneralSoundExtExtension.Size = new System.Drawing.Size(100, 20);
            this.textBoxGeneralSoundExtExtension.TabIndex = 10;
            this.textBoxGeneralSoundExtExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGeneralSoundExtExtension_KeyPress);
            // 
            // labelGeneralSoundExtension
            // 
            this.labelGeneralSoundExtension.AutoSize = true;
            this.labelGeneralSoundExtension.Location = new System.Drawing.Point(6, 52);
            this.labelGeneralSoundExtension.Name = "labelGeneralSoundExtension";
            this.labelGeneralSoundExtension.Size = new System.Drawing.Size(56, 13);
            this.labelGeneralSoundExtension.TabIndex = 9;
            this.labelGeneralSoundExtension.Text = "Extensión:";
            // 
            // textBoxGeneralSoundIdExtension
            // 
            this.textBoxGeneralSoundIdExtension.Enabled = false;
            this.textBoxGeneralSoundIdExtension.Location = new System.Drawing.Point(66, 13);
            this.textBoxGeneralSoundIdExtension.Name = "textBoxGeneralSoundIdExtension";
            this.textBoxGeneralSoundIdExtension.Size = new System.Drawing.Size(100, 20);
            this.textBoxGeneralSoundIdExtension.TabIndex = 8;
            this.textBoxGeneralSoundIdExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGeneralSoundIdExtension_KeyPress);
            // 
            // dataGridViewGeneralSound
            // 
            this.dataGridViewGeneralSound.AllowUserToAddRows = false;
            this.dataGridViewGeneralSound.AllowUserToDeleteRows = false;
            this.dataGridViewGeneralSound.AutoGenerateColumns = false;
            this.dataGridViewGeneralSound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGeneralSound.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.callTimeDataGridViewTextBoxColumn,
            this.soundFileDataGridViewTextBoxColumn,
            this.registerNameDataGridViewTextBoxColumn,
            this.ColumnCall,
            this.ColumnEndCall,
            this.modeDataGridViewTextBoxColumn,
            this.observationsDataGridViewTextBoxColumn,
            this.randomIdDataGridViewTextBoxColumn,
            this.noDataGridViewTextBoxColumn,
            this.startAtDataGridViewTextBoxColumn,
            this.enabledDataGridViewCheckBoxColumn});
            this.dataGridViewGeneralSound.DataSource = this.callServerModelBindingSource;
            this.dataGridViewGeneralSound.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewGeneralSound.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGeneralSound.Name = "dataGridViewGeneralSound";
            this.dataGridViewGeneralSound.RowHeadersWidth = 30;
            this.dataGridViewGeneralSound.Size = new System.Drawing.Size(515, 162);
            this.dataGridViewGeneralSound.TabIndex = 4;
            this.dataGridViewGeneralSound.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGeneralSound_CellClick);
            this.dataGridViewGeneralSound.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGeneralSound_CellEndEdit);
            this.dataGridViewGeneralSound.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewGeneralSound_CellPainting);
            this.dataGridViewGeneralSound.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewGeneralSound_CellValidating);
            this.dataGridViewGeneralSound.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewGeneralSound_RowHeaderMouseClick);
            // 
            // callServerModelBindingSource
            // 
            this.callServerModelBindingSource.DataSource = typeof(STA.Model.CallServerModel);
            // 
            // toolTipGeneralRings
            // 
            this.toolTipGeneralRings.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipGeneralRings.ToolTipTitle = "Información";
            // 
            // buttonGeneralAddSounds
            // 
            this.buttonGeneralAddSounds.FlatAppearance.BorderSize = 0;
            this.buttonGeneralAddSounds.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGeneralAddSounds.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGeneralAddSounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGeneralAddSounds.Image = global::STA.Properties.Resources.addc20x20;
            this.buttonGeneralAddSounds.Location = new System.Drawing.Point(6, 35);
            this.buttonGeneralAddSounds.Name = "buttonGeneralAddSounds";
            this.buttonGeneralAddSounds.Size = new System.Drawing.Size(33, 30);
            this.buttonGeneralAddSounds.TabIndex = 15;
            this.buttonGeneralAddSounds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipGeneralRings.SetToolTip(this.buttonGeneralAddSounds, "Agregar");
            this.buttonGeneralAddSounds.UseVisualStyleBackColor = true;
            this.buttonGeneralAddSounds.Click += new System.EventHandler(this.buttonGeneralAddSounds_Click);
            // 
            // buttonGeneralDelSounds
            // 
            this.buttonGeneralDelSounds.Enabled = false;
            this.buttonGeneralDelSounds.FlatAppearance.BorderSize = 0;
            this.buttonGeneralDelSounds.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGeneralDelSounds.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGeneralDelSounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGeneralDelSounds.Image = global::STA.Properties.Resources.removec20x20;
            this.buttonGeneralDelSounds.Location = new System.Drawing.Point(45, 35);
            this.buttonGeneralDelSounds.Name = "buttonGeneralDelSounds";
            this.buttonGeneralDelSounds.Size = new System.Drawing.Size(33, 30);
            this.buttonGeneralDelSounds.TabIndex = 16;
            this.buttonGeneralDelSounds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipGeneralRings.SetToolTip(this.buttonGeneralDelSounds, "Eliminar");
            this.buttonGeneralDelSounds.UseVisualStyleBackColor = true;
            this.buttonGeneralDelSounds.Click += new System.EventHandler(this.buttonGeneralDelSounds_Click);
            // 
            // groupBoxGeneralActions
            // 
            this.groupBoxGeneralActions.Controls.Add(this.buttonGeneralDelSounds);
            this.groupBoxGeneralActions.Controls.Add(this.buttonGeneralAddSounds);
            this.groupBoxGeneralActions.Location = new System.Drawing.Point(521, 0);
            this.groupBoxGeneralActions.Name = "groupBoxGeneralActions";
            this.groupBoxGeneralActions.Size = new System.Drawing.Size(107, 162);
            this.groupBoxGeneralActions.TabIndex = 5;
            this.groupBoxGeneralActions.TabStop = false;
            this.groupBoxGeneralActions.Text = "Acciones";
            this.toolTipGeneralRings.SetToolTip(this.groupBoxGeneralActions, "Acciones sobre los timbres de sonidos generales");
            // 
            // soundFileModelBindingSource
            // 
            this.soundFileModelBindingSource.DataSource = typeof(STA.Model.SoundFileModel);
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
            // modeDataGridViewTextBoxColumn
            // 
            this.modeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.modeDataGridViewTextBoxColumn.DataPropertyName = "mode";
            this.modeDataGridViewTextBoxColumn.FillWeight = 30F;
            this.modeDataGridViewTextBoxColumn.HeaderText = "Modo";
            this.modeDataGridViewTextBoxColumn.Name = "modeDataGridViewTextBoxColumn";
            this.modeDataGridViewTextBoxColumn.ReadOnly = true;
            this.modeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // observationsDataGridViewTextBoxColumn
            // 
            this.observationsDataGridViewTextBoxColumn.DataPropertyName = "observations";
            this.observationsDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            this.observationsDataGridViewTextBoxColumn.Name = "observationsDataGridViewTextBoxColumn";
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
            this.noDataGridViewTextBoxColumn.HeaderText = "no";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.Visible = false;
            // 
            // startAtDataGridViewTextBoxColumn
            // 
            this.startAtDataGridViewTextBoxColumn.DataPropertyName = "startAt";
            this.startAtDataGridViewTextBoxColumn.HeaderText = "startAt";
            this.startAtDataGridViewTextBoxColumn.Name = "startAtDataGridViewTextBoxColumn";
            this.startAtDataGridViewTextBoxColumn.Visible = false;
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "enabled";
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "enabled";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.Visible = false;
            // 
            // GeneralRingUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBoxGeneralActions);
            this.Controls.Add(this.dataGridViewGeneralSound);
            this.Controls.Add(this.groupBoxGeneralSoundExtension);
            this.Name = "GeneralRingUserControl";
            this.Size = new System.Drawing.Size(871, 162);
            this.groupBoxGeneralSoundExtension.ResumeLayout(false);
            this.groupBoxGeneralSoundExtension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGeneralSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.callServerModelBindingSource)).EndInit();
            this.groupBoxGeneralActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soundFileModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxGeneralSoundExtension;
        private System.Windows.Forms.Button buttonGeneralSoundSaveExtension;
        private System.Windows.Forms.Button buttonGeneralSoundEditExtension;
        private System.Windows.Forms.Label labelGeneralSoundPassword;
        private System.Windows.Forms.TextBox textBoxGeneralSoundPasswordExtension;
        private System.Windows.Forms.Label labelGeneralSoundID;
        private System.Windows.Forms.TextBox textBoxGeneralSoundExtExtension;
        private System.Windows.Forms.Label labelGeneralSoundExtension;
        private System.Windows.Forms.TextBox textBoxGeneralSoundIdExtension;
        private System.Windows.Forms.DataGridView dataGridViewGeneralSound;
        private System.Windows.Forms.BindingSource callServerModelBindingSource;
        private System.Windows.Forms.ToolTip toolTipGeneralRings;
        private System.Windows.Forms.BindingSource soundFileModelBindingSource;
        private System.Windows.Forms.GroupBox groupBoxGeneralActions;
        private System.Windows.Forms.Button buttonGeneralDelSounds;
        private System.Windows.Forms.Button buttonGeneralAddSounds;
        private System.Windows.Forms.DataGridViewTextBoxColumn callTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soundFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCall;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEndCall;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observationsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
    }
}
