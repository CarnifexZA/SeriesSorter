namespace SeriesSortCleanup
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSourceBrowse = new System.Windows.Forms.Button();
            this.btnDestBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRarRenameFilename = new System.Windows.Forms.TextBox();
            this.btnRenameToRAR = new System.Windows.Forms.Button();
            this.txtTargetRarDir = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRenameToPAR2 = new System.Windows.Forms.Button();
            this.btnBrowseRarTargetDir = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt7ZipSrcDir = new System.Windows.Forms.TextBox();
            this.btnBrowse7Zip = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTargetExtract = new System.Windows.Forms.TextBox();
            this.btnBrowseTargetExtract = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnWinRarExtract = new System.Windows.Forms.Button();
            this.txtWinrarSrcDir = new System.Windows.Forms.TextBox();
            this.btnBrowseWinrar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRenameTargetDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRenameSize = new System.Windows.Forms.TextBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnTargetBrowse = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCheckSource = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheckDestination = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCheckDir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCheckDestBrowse = new System.Windows.Forms.Button();
            this.txtSizeMB = new System.Windows.Forms.TextBox();
            this.btnCheckSourceBrowse = new System.Windows.Forms.Button();
            this.btnCheckExport = new System.Windows.Forms.Button();
            this.btn7ZipExtract = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSourceBrowse
            // 
            this.btnSourceBrowse.Location = new System.Drawing.Point(294, 28);
            this.btnSourceBrowse.Name = "btnSourceBrowse";
            this.btnSourceBrowse.Size = new System.Drawing.Size(26, 24);
            this.btnSourceBrowse.TabIndex = 0;
            this.btnSourceBrowse.Text = "...";
            this.btnSourceBrowse.UseVisualStyleBackColor = true;
            this.btnSourceBrowse.Click += new System.EventHandler(this.btnSourceBrowse_Click);
            // 
            // btnDestBrowse
            // 
            this.btnDestBrowse.Location = new System.Drawing.Point(294, 58);
            this.btnDestBrowse.Name = "btnDestBrowse";
            this.btnDestBrowse.Size = new System.Drawing.Size(26, 24);
            this.btnDestBrowse.TabIndex = 1;
            this.btnDestBrowse.Text = "...";
            this.btnDestBrowse.UseVisualStyleBackColor = true;
            this.btnDestBrowse.Click += new System.EventHandler(this.btnDestBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source Dir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination Dir";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(94, 31);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(194, 20);
            this.txtSource.TabIndex = 4;
            this.txtSource.Text = "D:\\TempTests\\SortRequired";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(94, 61);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(194, 20);
            this.txtDestination.TabIndex = 5;
            this.txtDestination.Text = "D:\\TempTests\\Sorted";
            // 
            // btnSort
            // 
            this.btnSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.Location = new System.Drawing.Point(326, 28);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(69, 54);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // txtFeedback
            // 
            this.txtFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeedback.Location = new System.Drawing.Point(438, 12);
            this.txtFeedback.Multiline = true;
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFeedback.Size = new System.Drawing.Size(846, 665);
            this.txtFeedback.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(3, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1266, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(625, 30);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(22, 18);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "-/-";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblProgress);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(12, 683);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1272, 51);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(9, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(423, 659);
            this.panel2.TabIndex = 12;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtRarRenameFilename);
            this.groupBox5.Controls.Add(this.btnRenameToRAR);
            this.groupBox5.Controls.Add(this.txtTargetRarDir);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.btnRenameToPAR2);
            this.groupBox5.Controls.Add(this.btnBrowseRarTargetDir);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox5.Location = new System.Drawing.Point(9, 511);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(405, 99);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rename To RAR && PAR2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "New Filename";
            // 
            // txtRarRenameFilename
            // 
            this.txtRarRenameFilename.Location = new System.Drawing.Point(85, 27);
            this.txtRarRenameFilename.Name = "txtRarRenameFilename";
            this.txtRarRenameFilename.Size = new System.Drawing.Size(200, 20);
            this.txtRarRenameFilename.TabIndex = 23;
            // 
            // btnRenameToRAR
            // 
            this.btnRenameToRAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenameToRAR.Location = new System.Drawing.Point(323, 20);
            this.btnRenameToRAR.Name = "btnRenameToRAR";
            this.btnRenameToRAR.Size = new System.Drawing.Size(69, 24);
            this.btnRenameToRAR.TabIndex = 22;
            this.btnRenameToRAR.Text = "RAR";
            this.btnRenameToRAR.UseVisualStyleBackColor = true;
            this.btnRenameToRAR.Click += new System.EventHandler(this.btnRenameToRAR_Click);
            // 
            // txtTargetRarDir
            // 
            this.txtTargetRarDir.Location = new System.Drawing.Point(85, 53);
            this.txtTargetRarDir.Name = "txtTargetRarDir";
            this.txtTargetRarDir.Size = new System.Drawing.Size(200, 20);
            this.txtTargetRarDir.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Target Dir";
            // 
            // btnRenameToPAR2
            // 
            this.btnRenameToPAR2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenameToPAR2.Location = new System.Drawing.Point(323, 50);
            this.btnRenameToPAR2.Name = "btnRenameToPAR2";
            this.btnRenameToPAR2.Size = new System.Drawing.Size(69, 24);
            this.btnRenameToPAR2.TabIndex = 21;
            this.btnRenameToPAR2.Text = "PAR2";
            this.btnRenameToPAR2.UseVisualStyleBackColor = true;
            this.btnRenameToPAR2.Click += new System.EventHandler(this.btnRenameToPAR2_Click);
            // 
            // btnBrowseRarTargetDir
            // 
            this.btnBrowseRarTargetDir.Location = new System.Drawing.Point(291, 50);
            this.btnBrowseRarTargetDir.Name = "btnBrowseRarTargetDir";
            this.btnBrowseRarTargetDir.Size = new System.Drawing.Size(26, 24);
            this.btnBrowseRarTargetDir.TabIndex = 18;
            this.btnBrowseRarTargetDir.Text = "...";
            this.btnBrowseRarTargetDir.UseVisualStyleBackColor = true;
            this.btnBrowseRarTargetDir.Click += new System.EventHandler(this.btnBrowseRarTargetDir_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn7ZipExtract);
            this.groupBox4.Controls.Add(this.txt7ZipSrcDir);
            this.groupBox4.Controls.Add(this.btnBrowse7Zip);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtTargetExtract);
            this.groupBox4.Controls.Add(this.btnBrowseTargetExtract);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.btnWinRarExtract);
            this.groupBox4.Controls.Add(this.txtWinrarSrcDir);
            this.groupBox4.Controls.Add(this.btnBrowseWinrar);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(9, 371);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 134);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Extract Directories";
            // 
            // txt7ZipSrcDir
            // 
            this.txt7ZipSrcDir.Location = new System.Drawing.Point(85, 60);
            this.txt7ZipSrcDir.Name = "txt7ZipSrcDir";
            this.txt7ZipSrcDir.Size = new System.Drawing.Size(200, 20);
            this.txt7ZipSrcDir.TabIndex = 36;
            // 
            // btnBrowse7Zip
            // 
            this.btnBrowse7Zip.Location = new System.Drawing.Point(291, 57);
            this.btnBrowse7Zip.Name = "btnBrowse7Zip";
            this.btnBrowse7Zip.Size = new System.Drawing.Size(26, 24);
            this.btnBrowse7Zip.TabIndex = 34;
            this.btnBrowse7Zip.Text = "...";
            this.btnBrowse7Zip.UseVisualStyleBackColor = true;
            this.btnBrowse7Zip.Click += new System.EventHandler(this.btnBrowse7Zip_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "7-Zip Dir";
            // 
            // txtTargetExtract
            // 
            this.txtTargetExtract.Location = new System.Drawing.Point(85, 94);
            this.txtTargetExtract.Name = "txtTargetExtract";
            this.txtTargetExtract.Size = new System.Drawing.Size(200, 20);
            this.txtTargetExtract.TabIndex = 33;
            // 
            // btnBrowseTargetExtract
            // 
            this.btnBrowseTargetExtract.Location = new System.Drawing.Point(291, 91);
            this.btnBrowseTargetExtract.Name = "btnBrowseTargetExtract";
            this.btnBrowseTargetExtract.Size = new System.Drawing.Size(26, 24);
            this.btnBrowseTargetExtract.TabIndex = 31;
            this.btnBrowseTargetExtract.Text = "...";
            this.btnBrowseTargetExtract.UseVisualStyleBackColor = true;
            this.btnBrowseTargetExtract.Click += new System.EventHandler(this.btnBrowseTargetExtract_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Target Dir";
            // 
            // btnWinRarExtract
            // 
            this.btnWinRarExtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWinRarExtract.Location = new System.Drawing.Point(323, 24);
            this.btnWinRarExtract.Name = "btnWinRarExtract";
            this.btnWinRarExtract.Size = new System.Drawing.Size(69, 42);
            this.btnWinRarExtract.TabIndex = 30;
            this.btnWinRarExtract.Text = "Extract WinRAR";
            this.btnWinRarExtract.UseVisualStyleBackColor = true;
            this.btnWinRarExtract.Click += new System.EventHandler(this.btnWinRarExtract_Click);
            // 
            // txtWinrarSrcDir
            // 
            this.txtWinrarSrcDir.Location = new System.Drawing.Point(85, 27);
            this.txtWinrarSrcDir.Name = "txtWinrarSrcDir";
            this.txtWinrarSrcDir.Size = new System.Drawing.Size(200, 20);
            this.txtWinrarSrcDir.TabIndex = 28;
            // 
            // btnBrowseWinrar
            // 
            this.btnBrowseWinrar.Location = new System.Drawing.Point(291, 24);
            this.btnBrowseWinrar.Name = "btnBrowseWinrar";
            this.btnBrowseWinrar.Size = new System.Drawing.Size(26, 24);
            this.btnBrowseWinrar.TabIndex = 26;
            this.btnBrowseWinrar.Text = "...";
            this.btnBrowseWinrar.UseVisualStyleBackColor = true;
            this.btnBrowseWinrar.Click += new System.EventHandler(this.btnBrowseWinrar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Winrar Dir";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRenameTargetDir);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtRenameSize);
            this.groupBox3.Controls.Add(this.btnRename);
            this.groupBox3.Controls.Add(this.btnTargetBrowse);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(9, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 99);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rename Directory Files";
            // 
            // txtRenameTargetDir
            // 
            this.txtRenameTargetDir.Location = new System.Drawing.Point(85, 53);
            this.txtRenameTargetDir.Name = "txtRenameTargetDir";
            this.txtRenameTargetDir.Size = new System.Drawing.Size(200, 20);
            this.txtRenameTargetDir.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Size MB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Target Dir";
            // 
            // txtRenameSize
            // 
            this.txtRenameSize.Location = new System.Drawing.Point(85, 25);
            this.txtRenameSize.Name = "txtRenameSize";
            this.txtRenameSize.Size = new System.Drawing.Size(48, 20);
            this.txtRenameSize.TabIndex = 24;
            // 
            // btnRename
            // 
            this.btnRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRename.Location = new System.Drawing.Point(323, 50);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(69, 24);
            this.btnRename.TabIndex = 21;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnTargetBrowse
            // 
            this.btnTargetBrowse.Location = new System.Drawing.Point(291, 50);
            this.btnTargetBrowse.Name = "btnTargetBrowse";
            this.btnTargetBrowse.Size = new System.Drawing.Size(26, 24);
            this.btnTargetBrowse.TabIndex = 18;
            this.btnTargetBrowse.Text = "...";
            this.btnTargetBrowse.UseVisualStyleBackColor = true;
            this.btnTargetBrowse.Click += new System.EventHandler(this.btnTargetBrowse_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSource);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDestination);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSort);
            this.groupBox2.Controls.Add(this.btnDestBrowse);
            this.groupBox2.Controls.Add(this.btnSourceBrowse);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(6, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 100);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sort Directories";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCheckSource);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCheckDestination);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCheckDir);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnCheckDestBrowse);
            this.groupBox1.Controls.Add(this.txtSizeMB);
            this.groupBox1.Controls.Add(this.btnCheckSourceBrowse);
            this.groupBox1.Controls.Add(this.btnCheckExport);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 113);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check && Export Directories";
            // 
            // txtCheckSource
            // 
            this.txtCheckSource.Location = new System.Drawing.Point(88, 50);
            this.txtCheckSource.Name = "txtCheckSource";
            this.txtCheckSource.Size = new System.Drawing.Size(200, 20);
            this.txtCheckSource.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Destination Dir";
            // 
            // txtCheckDestination
            // 
            this.txtCheckDestination.Location = new System.Drawing.Point(88, 79);
            this.txtCheckDestination.Name = "txtCheckDestination";
            this.txtCheckDestination.Size = new System.Drawing.Size(200, 20);
            this.txtCheckDestination.TabIndex = 14;
            this.txtCheckDestination.Text = "D:\\TempTests\\Sorted";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Source Dir";
            // 
            // btnCheckDir
            // 
            this.btnCheckDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckDir.Location = new System.Drawing.Point(326, 47);
            this.btnCheckDir.Name = "btnCheckDir";
            this.btnCheckDir.Size = new System.Drawing.Size(69, 23);
            this.btnCheckDir.TabIndex = 15;
            this.btnCheckDir.Text = "Check";
            this.btnCheckDir.UseVisualStyleBackColor = true;
            this.btnCheckDir.Click += new System.EventHandler(this.btnCheckDir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Size MB";
            // 
            // btnCheckDestBrowse
            // 
            this.btnCheckDestBrowse.Location = new System.Drawing.Point(294, 77);
            this.btnCheckDestBrowse.Name = "btnCheckDestBrowse";
            this.btnCheckDestBrowse.Size = new System.Drawing.Size(26, 23);
            this.btnCheckDestBrowse.TabIndex = 10;
            this.btnCheckDestBrowse.Text = "...";
            this.btnCheckDestBrowse.UseVisualStyleBackColor = true;
            this.btnCheckDestBrowse.Click += new System.EventHandler(this.btnCheckDestBrowse_Click);
            // 
            // txtSizeMB
            // 
            this.txtSizeMB.Location = new System.Drawing.Point(88, 18);
            this.txtSizeMB.Name = "txtSizeMB";
            this.txtSizeMB.Size = new System.Drawing.Size(48, 20);
            this.txtSizeMB.TabIndex = 13;
            // 
            // btnCheckSourceBrowse
            // 
            this.btnCheckSourceBrowse.Location = new System.Drawing.Point(294, 48);
            this.btnCheckSourceBrowse.Name = "btnCheckSourceBrowse";
            this.btnCheckSourceBrowse.Size = new System.Drawing.Size(26, 23);
            this.btnCheckSourceBrowse.TabIndex = 9;
            this.btnCheckSourceBrowse.Text = "...";
            this.btnCheckSourceBrowse.UseVisualStyleBackColor = true;
            this.btnCheckSourceBrowse.Click += new System.EventHandler(this.btnCheckSourceBrowse_Click);
            // 
            // btnCheckExport
            // 
            this.btnCheckExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckExport.Location = new System.Drawing.Point(326, 77);
            this.btnCheckExport.Name = "btnCheckExport";
            this.btnCheckExport.Size = new System.Drawing.Size(69, 23);
            this.btnCheckExport.TabIndex = 16;
            this.btnCheckExport.Text = "Export";
            this.btnCheckExport.UseVisualStyleBackColor = true;
            this.btnCheckExport.Click += new System.EventHandler(this.btnCheckExport_Click);
            // 
            // btn7ZipExtract
            // 
            this.btn7ZipExtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7ZipExtract.Location = new System.Drawing.Point(323, 72);
            this.btn7ZipExtract.Name = "btn7ZipExtract";
            this.btn7ZipExtract.Size = new System.Drawing.Size(69, 42);
            this.btn7ZipExtract.TabIndex = 37;
            this.btn7ZipExtract.Text = "Extract 7-Zip";
            this.btn7ZipExtract.UseVisualStyleBackColor = true;
            this.btn7ZipExtract.Click += new System.EventHandler(this.btn7ZipExtract_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 741);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Series Manager";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSourceBrowse;
        private System.Windows.Forms.Button btnDestBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCheckSource;
        private System.Windows.Forms.Button btnCheckSourceBrowse;
        private System.Windows.Forms.Button btnCheckDestBrowse;
        private System.Windows.Forms.Button btnCheckDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCheckDestination;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSizeMB;
        private System.Windows.Forms.Button btnCheckExport;
        private System.Windows.Forms.TextBox txtRenameTargetDir;
        private System.Windows.Forms.Button btnTargetBrowse;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRenameSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWinrarSrcDir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBrowseWinrar;
        private System.Windows.Forms.Button btnWinRarExtract;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTargetExtract;
        private System.Windows.Forms.Button btnBrowseTargetExtract;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnRenameToRAR;
        private System.Windows.Forms.TextBox txtTargetRarDir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRenameToPAR2;
        private System.Windows.Forms.Button btnBrowseRarTargetDir;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRarRenameFilename;
        private System.Windows.Forms.TextBox txt7ZipSrcDir;
        private System.Windows.Forms.Button btnBrowse7Zip;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn7ZipExtract;
    }
}

