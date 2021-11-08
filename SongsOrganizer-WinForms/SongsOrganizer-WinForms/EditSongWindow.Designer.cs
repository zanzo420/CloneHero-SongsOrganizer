namespace zCHSongManager
{
    partial class EditSongWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.albumPictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.revertBtn = new System.Windows.Forms.Button();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblArtist = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.albumTextBox = new System.Windows.Forms.TextBox();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.genreTextBox = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.lblCharter = new System.Windows.Forms.Label();
            this.charterTextBox = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEasy = new System.Windows.Forms.CheckBox();
            this.chkMedium = new System.Windows.Forms.CheckBox();
            this.chkHard = new System.Windows.Forms.CheckBox();
            this.chkExpert = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.chkPro = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.38281F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.61719F));
            this.tableLayoutPanel1.Controls.Add(this.albumPictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.90141F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.09859F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 322);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // albumPictureBox
            // 
            this.albumPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.albumPictureBox.Location = new System.Drawing.Point(3, 3);
            this.albumPictureBox.Name = "albumPictureBox";
            this.albumPictureBox.Size = new System.Drawing.Size(211, 184);
            this.albumPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.albumPictureBox.TabIndex = 0;
            this.albumPictureBox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.Controls.Add(this.revertBtn);
            this.flowLayoutPanel1.Controls.Add(this.acceptBtn);
            this.flowLayoutPanel1.Controls.Add(this.cancelBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(232, 193);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(265, 28);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // revertBtn
            // 
            this.revertBtn.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revertBtn.Location = new System.Drawing.Point(3, 3);
            this.revertBtn.Name = "revertBtn";
            this.revertBtn.Size = new System.Drawing.Size(96, 23);
            this.revertBtn.TabIndex = 0;
            this.revertBtn.Text = "Revert changes";
            this.revertBtn.UseVisualStyleBackColor = true;
            this.revertBtn.Click += new System.EventHandler(this.revertBtn_Click);
            // 
            // acceptBtn
            // 
            this.acceptBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptBtn.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptBtn.Location = new System.Drawing.Point(105, 3);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 1;
            this.acceptBtn.Text = "Accept";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(186, 3);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.Controls.Add(this.lblArtist);
            this.flowLayoutPanel2.Controls.Add(this.nameTextBox);
            this.flowLayoutPanel2.Controls.Add(this.lblName);
            this.flowLayoutPanel2.Controls.Add(this.albumTextBox);
            this.flowLayoutPanel2.Controls.Add(this.lblAlbum);
            this.flowLayoutPanel2.Controls.Add(this.artistTextBox);
            this.flowLayoutPanel2.Controls.Add(this.lblGenre);
            this.flowLayoutPanel2.Controls.Add(this.genreTextBox);
            this.flowLayoutPanel2.Controls.Add(this.lblYear);
            this.flowLayoutPanel2.Controls.Add(this.yearTextBox);
            this.flowLayoutPanel2.Controls.Add(this.lblCharter);
            this.flowLayoutPanel2.Controls.Add(this.charterTextBox);
            this.flowLayoutPanel2.Controls.Add(this.lblLength);
            this.flowLayoutPanel2.Controls.Add(this.lengthTextBox);
            this.flowLayoutPanel2.Controls.Add(this.directoryLabel);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(225, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(279, 181);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.Location = new System.Drawing.Point(3, 0);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(39, 14);
            this.lblArtist.TabIndex = 9;
            this.lblArtist.Text = "Artist: ";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(48, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(224, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 14);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name:";
            // 
            // albumTextBox
            // 
            this.albumTextBox.Location = new System.Drawing.Point(52, 29);
            this.albumTextBox.Name = "albumTextBox";
            this.albumTextBox.Size = new System.Drawing.Size(220, 20);
            this.albumTextBox.TabIndex = 1;
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlbum.Location = new System.Drawing.Point(3, 52);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(45, 14);
            this.lblAlbum.TabIndex = 10;
            this.lblAlbum.Text = "Album:";
            // 
            // artistTextBox
            // 
            this.artistTextBox.Location = new System.Drawing.Point(54, 55);
            this.artistTextBox.Name = "artistTextBox";
            this.artistTextBox.Size = new System.Drawing.Size(218, 20);
            this.artistTextBox.TabIndex = 4;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenre.Location = new System.Drawing.Point(3, 78);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(44, 14);
            this.lblGenre.TabIndex = 11;
            this.lblGenre.Text = "Genre:";
            // 
            // genreTextBox
            // 
            this.genreTextBox.Location = new System.Drawing.Point(53, 81);
            this.genreTextBox.Name = "genreTextBox";
            this.genreTextBox.Size = new System.Drawing.Size(131, 20);
            this.genreTextBox.TabIndex = 2;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(190, 78);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(35, 14);
            this.lblYear.TabIndex = 12;
            this.lblYear.Text = "Year:";
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(231, 81);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(41, 20);
            this.yearTextBox.TabIndex = 6;
            // 
            // lblCharter
            // 
            this.lblCharter.AutoSize = true;
            this.lblCharter.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharter.Location = new System.Drawing.Point(3, 104);
            this.lblCharter.Name = "lblCharter";
            this.lblCharter.Size = new System.Drawing.Size(51, 14);
            this.lblCharter.TabIndex = 13;
            this.lblCharter.Text = "Charter:";
            // 
            // charterTextBox
            // 
            this.charterTextBox.Location = new System.Drawing.Point(60, 107);
            this.charterTextBox.Name = "charterTextBox";
            this.charterTextBox.Size = new System.Drawing.Size(96, 20);
            this.charterTextBox.TabIndex = 5;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(162, 104);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(48, 14);
            this.lblLength.TabIndex = 14;
            this.lblLength.Text = "Length:";
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(216, 107);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(56, 20);
            this.lengthTextBox.TabIndex = 7;
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryLabel.Location = new System.Drawing.Point(3, 130);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(88, 14);
            this.directoryLabel.TabIndex = 0;
            this.directoryLabel.Text = "directoryLabel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPro);
            this.groupBox1.Controls.Add(this.cmbDifficulty);
            this.groupBox1.Controls.Add(this.chkEasy);
            this.groupBox1.Controls.Add(this.chkMedium);
            this.groupBox1.Controls.Add(this.chkHard);
            this.groupBox1.Controls.Add(this.chkExpert);
            this.groupBox1.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Difficulties:";
            this.groupBox1.Visible = false;
            // 
            // chkEasy
            // 
            this.chkEasy.AutoSize = true;
            this.chkEasy.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEasy.Location = new System.Drawing.Point(128, 64);
            this.chkEasy.Name = "chkEasy";
            this.chkEasy.Size = new System.Drawing.Size(51, 18);
            this.chkEasy.TabIndex = 3;
            this.chkEasy.Text = "&Easy";
            this.chkEasy.UseVisualStyleBackColor = true;
            // 
            // chkMedium
            // 
            this.chkMedium.AutoSize = true;
            this.chkMedium.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMedium.Location = new System.Drawing.Point(128, 48);
            this.chkMedium.Name = "chkMedium";
            this.chkMedium.Size = new System.Drawing.Size(72, 18);
            this.chkMedium.TabIndex = 2;
            this.chkMedium.Text = "&Medium";
            this.chkMedium.UseVisualStyleBackColor = true;
            // 
            // chkHard
            // 
            this.chkHard.AutoSize = true;
            this.chkHard.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHard.Location = new System.Drawing.Point(128, 32);
            this.chkHard.Name = "chkHard";
            this.chkHard.Size = new System.Drawing.Size(54, 18);
            this.chkHard.TabIndex = 1;
            this.chkHard.Text = "&Hard";
            this.chkHard.UseVisualStyleBackColor = true;
            // 
            // chkExpert
            // 
            this.chkExpert.AutoSize = true;
            this.chkExpert.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExpert.Location = new System.Drawing.Point(128, 16);
            this.chkExpert.Name = "chkExpert";
            this.chkExpert.Size = new System.Drawing.Size(62, 18);
            this.chkExpert.TabIndex = 0;
            this.chkExpert.Text = "E&xpert";
            this.chkExpert.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.groupBox1);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 193);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(211, 88);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDifficulty.FormattingEnabled = true;
            this.cmbDifficulty.Items.AddRange(new object[] {
            "Guitar",
            "Bass",
            "Drums",
            "Vocals",
            "Keys",
            "Coop Guitar",
            "Rhythm Guitar",
            "Pro Guitar",
            "Pro Bass",
            "Pro Drums",
            "Pro Keys",
            "Vocals Harm.",
            "GHLive Guitar",
            "GHLive Bass"});
            this.cmbDifficulty.Location = new System.Drawing.Point(8, 16);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(120, 25);
            this.cmbDifficulty.TabIndex = 4;
            // 
            // chkPro
            // 
            this.chkPro.AutoSize = true;
            this.chkPro.Enabled = false;
            this.chkPro.Font = new System.Drawing.Font("ROCKBAND GAME FONT V2", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPro.Location = new System.Drawing.Point(8, 48);
            this.chkPro.Name = "chkPro";
            this.chkPro.Size = new System.Drawing.Size(51, 18);
            this.chkPro.TabIndex = 5;
            this.chkPro.Text = "Pro?";
            this.chkPro.UseVisualStyleBackColor = true;
            // 
            // EditSongWindow
            // 
            this.AcceptButton = this.acceptBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(512, 322);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditSongWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[zH4x™][zCHSongManager] Edit Song...";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.albumPictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox albumPictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button revertBtn;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.TextBox albumTextBox;
        private System.Windows.Forms.TextBox genreTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox artistTextBox;
        private System.Windows.Forms.TextBox charterTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblCharter;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEasy;
        private System.Windows.Forms.CheckBox chkMedium;
        private System.Windows.Forms.CheckBox chkHard;
        private System.Windows.Forms.CheckBox chkExpert;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.CheckBox chkPro;
    }
}