namespace TimbresIP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.ColumnTone = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCall = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnObservation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxGeneralSoundExtension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGeneralSound)).BeginInit();
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
            this.groupBoxGeneralSoundExtension.Location = new System.Drawing.Point(633, 3);
            this.groupBoxGeneralSoundExtension.Name = "groupBoxGeneralSoundExtension";
            this.groupBoxGeneralSoundExtension.Size = new System.Drawing.Size(237, 156);
            this.groupBoxGeneralSoundExtension.TabIndex = 0;
            this.groupBoxGeneralSoundExtension.TabStop = false;
            this.groupBoxGeneralSoundExtension.Text = "Extensión";
            // 
            // buttonGeneralSoundSaveExtension
            // 
            this.buttonGeneralSoundSaveExtension.Enabled = false;
            this.buttonGeneralSoundSaveExtension.Image = global::TimbresIP.Properties.Resources.savec20x20;
            this.buttonGeneralSoundSaveExtension.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGeneralSoundSaveExtension.Location = new System.Drawing.Point(122, 115);
            this.buttonGeneralSoundSaveExtension.Name = "buttonGeneralSoundSaveExtension";
            this.buttonGeneralSoundSaveExtension.Size = new System.Drawing.Size(75, 30);
            this.buttonGeneralSoundSaveExtension.TabIndex = 15;
            this.buttonGeneralSoundSaveExtension.Text = "Guardar";
            this.buttonGeneralSoundSaveExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGeneralSoundSaveExtension.UseVisualStyleBackColor = true;
            this.buttonGeneralSoundSaveExtension.Click += new System.EventHandler(this.buttonGeneralSoundSaveExtension_Click);
            // 
            // buttonGeneralSoundEditExtension
            // 
            this.buttonGeneralSoundEditExtension.Image = global::TimbresIP.Properties.Resources.editc20x20;
            this.buttonGeneralSoundEditExtension.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGeneralSoundEditExtension.Location = new System.Drawing.Point(40, 115);
            this.buttonGeneralSoundEditExtension.Name = "buttonGeneralSoundEditExtension";
            this.buttonGeneralSoundEditExtension.Size = new System.Drawing.Size(75, 30);
            this.buttonGeneralSoundEditExtension.TabIndex = 14;
            this.buttonGeneralSoundEditExtension.Text = "Editar";
            this.buttonGeneralSoundEditExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.textBoxGeneralSoundPasswordExtension.Text = "Caeunagota";
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
            this.textBoxGeneralSoundExtExtension.Text = "1111";
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
            this.textBoxGeneralSoundIdExtension.Text = "1111";
            this.textBoxGeneralSoundIdExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGeneralSoundIdExtension_KeyPress);
            // 
            // dataGridViewGeneralSound
            // 
            this.dataGridViewGeneralSound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGeneralSound.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTone,
            this.ColumnExtension,
            this.ColumnCall,
            this.ColumnObservation});
            this.dataGridViewGeneralSound.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewGeneralSound.Name = "dataGridViewGeneralSound";
            this.dataGridViewGeneralSound.RowHeadersWidth = 30;
            this.dataGridViewGeneralSound.Size = new System.Drawing.Size(515, 156);
            this.dataGridViewGeneralSound.TabIndex = 4;
            this.dataGridViewGeneralSound.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGeneralSound_CellClick);
            this.dataGridViewGeneralSound.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGeneralSound_CellEndEdit);
            this.dataGridViewGeneralSound.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewGeneralSound_CellPainting);
            this.dataGridViewGeneralSound.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewGeneralSound_CellValidating);
            // 
            // ColumnTone
            // 
            this.ColumnTone.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ColumnTone.HeaderText = "Tono";
            this.ColumnTone.Name = "ColumnTone";
            this.ColumnTone.Width = 121;
            // 
            // ColumnExtension
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.ColumnExtension.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnExtension.HeaderText = "Extesión";
            this.ColumnExtension.Name = "ColumnExtension";
            this.ColumnExtension.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnExtension.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnExtension.Width = 50;
            // 
            // ColumnCall
            // 
            this.ColumnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnCall.HeaderText = "Llamar";
            this.ColumnCall.Name = "ColumnCall";
            this.ColumnCall.Text = "Llamar";
            this.ColumnCall.Width = 50;
            // 
            // ColumnObservation
            // 
            this.ColumnObservation.HeaderText = "Observaciones";
            this.ColumnObservation.Name = "ColumnObservation";
            this.ColumnObservation.Width = 262;
            // 
            // GeneralRingUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.dataGridViewGeneralSound);
            this.Controls.Add(this.groupBoxGeneralSoundExtension);
            this.Name = "GeneralRingUserControl";
            this.Size = new System.Drawing.Size(869, 162);
            this.groupBoxGeneralSoundExtension.ResumeLayout(false);
            this.groupBoxGeneralSoundExtension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGeneralSound)).EndInit();
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
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnTone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExtension;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCall;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnObservation;
    }
}
