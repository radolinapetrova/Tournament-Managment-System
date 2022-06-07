namespace SportsTournamentManagmentSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbGames = new System.Windows.Forms.ListBox();
            this.lbTournaments = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnScheduled = new System.Windows.Forms.RadioButton();
            this.rbtnCamceled = new System.Windows.Forms.RadioButton();
            this.rbtnClosed = new System.Windows.Forms.RadioButton();
            this.rbtnOpen = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.btmSaveResult = new System.Windows.Forms.Button();
            this.tbResultPlayerTwo = new System.Windows.Forms.TextBox();
            this.tbResultPlayerOne = new System.Windows.Forms.TextBox();
            this.lblPlayerTwo = new System.Windows.Forms.Label();
            this.lblPlayerOne = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGenerateSchedule = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelTournament = new System.Windows.Forms.Button();
            this.btnGetTournamentByTitle = new System.Windows.Forms.Button();
            this.btnFilterById = new System.Windows.Forms.Button();
            this.tbTournamentTitle = new System.Windows.Forms.TextBox();
            this.tbTournamentId = new System.Windows.Forms.TextBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbScheduled = new System.Windows.Forms.RadioButton();
            this.rbCanceled = new System.Windows.Forms.RadioButton();
            this.rbClosed = new System.Windows.Forms.RadioButton();
            this.rbOpen = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDeleteTournament = new System.Windows.Forms.Button();
            this.lbEditTournaments = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSportType = new System.Windows.Forms.ComboBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numMinPlayers = new System.Windows.Forms.NumericUpDown();
            this.cmbTournamentSystem = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditTournament = new System.Windows.Forms.Button();
            this.numMaxPlayers = new System.Windows.Forms.NumericUpDown();
            this.btnCreateTournament = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbResults.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // lbGames
            // 
            this.lbGames.FormattingEnabled = true;
            this.lbGames.ItemHeight = 20;
            this.lbGames.Location = new System.Drawing.Point(49, 300);
            this.lbGames.Name = "lbGames";
            this.lbGames.Size = new System.Drawing.Size(739, 244);
            this.lbGames.TabIndex = 0;
            this.lbGames.SelectedIndexChanged += new System.EventHandler(this.lbGames_SelectedIndexChanged);
            // 
            // lbTournaments
            // 
            this.lbTournaments.FormattingEnabled = true;
            this.lbTournaments.ItemHeight = 20;
            this.lbTournaments.Location = new System.Drawing.Point(269, 37);
            this.lbTournaments.Name = "lbTournaments";
            this.lbTournaments.Size = new System.Drawing.Size(285, 244);
            this.lbTournaments.TabIndex = 2;
            this.lbTournaments.SelectedIndexChanged += new System.EventHandler(this.lbTournaments_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1203, 787);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rbtnAll);
            this.tabPage1.Controls.Add(this.rbtnScheduled);
            this.tabPage1.Controls.Add(this.rbtnCamceled);
            this.tabPage1.Controls.Add(this.rbtnClosed);
            this.tabPage1.Controls.Add(this.rbtnOpen);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.gbResults);
            this.tabPage1.Controls.Add(this.btnGenerateSchedule);
            this.tabPage1.Controls.Add(this.lbGames);
            this.tabPage1.Controls.Add(this.lbTournaments);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1195, 754);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tournament results management";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Location = new System.Drawing.Point(71, 257);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(48, 24);
            this.rbtnAll.TabIndex = 41;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnAll_CheckedChanged);
            // 
            // rbtnScheduled
            // 
            this.rbtnScheduled.AutoSize = true;
            this.rbtnScheduled.Location = new System.Drawing.Point(71, 211);
            this.rbtnScheduled.Name = "rbtnScheduled";
            this.rbtnScheduled.Size = new System.Drawing.Size(99, 24);
            this.rbtnScheduled.TabIndex = 40;
            this.rbtnScheduled.Text = "Scheduled";
            this.rbtnScheduled.UseVisualStyleBackColor = true;
            this.rbtnScheduled.CheckedChanged += new System.EventHandler(this.rbtnScheduled_CheckedChanged);
            // 
            // rbtnCamceled
            // 
            this.rbtnCamceled.AutoSize = true;
            this.rbtnCamceled.Location = new System.Drawing.Point(71, 161);
            this.rbtnCamceled.Name = "rbtnCamceled";
            this.rbtnCamceled.Size = new System.Drawing.Size(91, 24);
            this.rbtnCamceled.TabIndex = 39;
            this.rbtnCamceled.Text = "Canceled";
            this.rbtnCamceled.UseVisualStyleBackColor = true;
            this.rbtnCamceled.CheckedChanged += new System.EventHandler(this.rbtnCamceled_CheckedChanged);
            // 
            // rbtnClosed
            // 
            this.rbtnClosed.AutoSize = true;
            this.rbtnClosed.Location = new System.Drawing.Point(71, 110);
            this.rbtnClosed.Name = "rbtnClosed";
            this.rbtnClosed.Size = new System.Drawing.Size(173, 24);
            this.rbtnClosed.TabIndex = 38;
            this.rbtnClosed.Text = "Closed for registering";
            this.rbtnClosed.UseVisualStyleBackColor = true;
            this.rbtnClosed.CheckedChanged += new System.EventHandler(this.rbtnClosed_CheckedChanged);
            // 
            // rbtnOpen
            // 
            this.rbtnOpen.AutoSize = true;
            this.rbtnOpen.Location = new System.Drawing.Point(71, 63);
            this.rbtnOpen.Name = "rbtnOpen";
            this.rbtnOpen.Size = new System.Drawing.Size(164, 24);
            this.rbtnOpen.TabIndex = 37;
            this.rbtnOpen.Text = "Open for registering";
            this.rbtnOpen.UseVisualStyleBackColor = true;
            this.rbtnOpen.CheckedChanged += new System.EventHandler(this.rbtnOpen_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(71, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 20);
            this.label13.TabIndex = 36;
            this.label13.Text = "Filters:";
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.btmSaveResult);
            this.gbResults.Controls.Add(this.tbResultPlayerTwo);
            this.gbResults.Controls.Add(this.tbResultPlayerOne);
            this.gbResults.Controls.Add(this.lblPlayerTwo);
            this.gbResults.Controls.Add(this.lblPlayerOne);
            this.gbResults.Controls.Add(this.label11);
            this.gbResults.Controls.Add(this.label10);
            this.gbResults.Location = new System.Drawing.Point(886, 300);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(303, 244);
            this.gbResults.TabIndex = 5;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Game results";
            // 
            // btmSaveResult
            // 
            this.btmSaveResult.Location = new System.Drawing.Point(75, 189);
            this.btmSaveResult.Name = "btmSaveResult";
            this.btmSaveResult.Size = new System.Drawing.Size(134, 35);
            this.btmSaveResult.TabIndex = 6;
            this.btmSaveResult.Text = "Save results";
            this.btmSaveResult.UseVisualStyleBackColor = true;
            this.btmSaveResult.Click += new System.EventHandler(this.btmSaveResult_Click);
            // 
            // tbResultPlayerTwo
            // 
            this.tbResultPlayerTwo.Location = new System.Drawing.Point(175, 138);
            this.tbResultPlayerTwo.Name = "tbResultPlayerTwo";
            this.tbResultPlayerTwo.Size = new System.Drawing.Size(80, 27);
            this.tbResultPlayerTwo.TabIndex = 5;
            // 
            // tbResultPlayerOne
            // 
            this.tbResultPlayerOne.Location = new System.Drawing.Point(175, 48);
            this.tbResultPlayerOne.Name = "tbResultPlayerOne";
            this.tbResultPlayerOne.Size = new System.Drawing.Size(80, 27);
            this.tbResultPlayerOne.TabIndex = 4;
            // 
            // lblPlayerTwo
            // 
            this.lblPlayerTwo.AutoSize = true;
            this.lblPlayerTwo.Location = new System.Drawing.Point(20, 156);
            this.lblPlayerTwo.Name = "lblPlayerTwo";
            this.lblPlayerTwo.Size = new System.Drawing.Size(13, 20);
            this.lblPlayerTwo.TabIndex = 3;
            this.lblPlayerTwo.Text = "!";
            // 
            // lblPlayerOne
            // 
            this.lblPlayerOne.AutoSize = true;
            this.lblPlayerOne.Location = new System.Drawing.Point(20, 69);
            this.lblPlayerOne.Name = "lblPlayerOne";
            this.lblPlayerOne.Size = new System.Drawing.Size(13, 20);
            this.lblPlayerOne.TabIndex = 2;
            this.lblPlayerOne.Text = "!";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "Player 2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Player 1:";
            // 
            // btnGenerateSchedule
            // 
            this.btnGenerateSchedule.Location = new System.Drawing.Point(582, 96);
            this.btnGenerateSchedule.Name = "btnGenerateSchedule";
            this.btnGenerateSchedule.Size = new System.Drawing.Size(206, 129);
            this.btnGenerateSchedule.TabIndex = 4;
            this.btnGenerateSchedule.Text = "Generate schedule";
            this.btnGenerateSchedule.UseVisualStyleBackColor = true;
            this.btnGenerateSchedule.Click += new System.EventHandler(this.btnGenerateSchedule_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1195, 754);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tournament management";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelTournament);
            this.groupBox2.Controls.Add(this.btnGetTournamentByTitle);
            this.groupBox2.Controls.Add(this.btnFilterById);
            this.groupBox2.Controls.Add(this.tbTournamentTitle);
            this.groupBox2.Controls.Add(this.tbTournamentId);
            this.groupBox2.Controls.Add(this.rbAll);
            this.groupBox2.Controls.Add(this.rbScheduled);
            this.groupBox2.Controls.Add(this.rbCanceled);
            this.groupBox2.Controls.Add(this.rbClosed);
            this.groupBox2.Controls.Add(this.rbOpen);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnDeleteTournament);
            this.groupBox2.Controls.Add(this.lbEditTournaments);
            this.groupBox2.Location = new System.Drawing.Point(547, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 692);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit tournament information";
            // 
            // btnCancelTournament
            // 
            this.btnCancelTournament.Location = new System.Drawing.Point(38, 496);
            this.btnCancelTournament.Name = "btnCancelTournament";
            this.btnCancelTournament.Size = new System.Drawing.Size(385, 55);
            this.btnCancelTournament.TabIndex = 40;
            this.btnCancelTournament.Text = "Cancel tournament";
            this.btnCancelTournament.UseVisualStyleBackColor = true;
            this.btnCancelTournament.Click += new System.EventHandler(this.btnCancelTournament_Click);
            // 
            // btnGetTournamentByTitle
            // 
            this.btnGetTournamentByTitle.Location = new System.Drawing.Point(209, 86);
            this.btnGetTournamentByTitle.Name = "btnGetTournamentByTitle";
            this.btnGetTournamentByTitle.Size = new System.Drawing.Size(200, 29);
            this.btnGetTournamentByTitle.TabIndex = 39;
            this.btnGetTournamentByTitle.Text = "Get tournament by title";
            this.btnGetTournamentByTitle.UseVisualStyleBackColor = true;
            this.btnGetTournamentByTitle.Click += new System.EventHandler(this.btnGetTournamentByTitle_Click);
            // 
            // btnFilterById
            // 
            this.btnFilterById.Location = new System.Drawing.Point(209, 45);
            this.btnFilterById.Name = "btnFilterById";
            this.btnFilterById.Size = new System.Drawing.Size(200, 29);
            this.btnFilterById.TabIndex = 38;
            this.btnFilterById.Text = "Get tournament by ID";
            this.btnFilterById.UseVisualStyleBackColor = true;
            this.btnFilterById.Click += new System.EventHandler(this.btnFilterById_Click);
            // 
            // tbTournamentTitle
            // 
            this.tbTournamentTitle.Location = new System.Drawing.Point(44, 87);
            this.tbTournamentTitle.Name = "tbTournamentTitle";
            this.tbTournamentTitle.Size = new System.Drawing.Size(125, 27);
            this.tbTournamentTitle.TabIndex = 37;
            // 
            // tbTournamentId
            // 
            this.tbTournamentId.Location = new System.Drawing.Point(44, 46);
            this.tbTournamentId.Name = "tbTournamentId";
            this.tbTournamentId.Size = new System.Drawing.Size(125, 27);
            this.tbTournamentId.TabIndex = 36;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(459, 390);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(48, 24);
            this.rbAll.TabIndex = 35;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbScheduled
            // 
            this.rbScheduled.AutoSize = true;
            this.rbScheduled.Location = new System.Drawing.Point(459, 344);
            this.rbScheduled.Name = "rbScheduled";
            this.rbScheduled.Size = new System.Drawing.Size(99, 24);
            this.rbScheduled.TabIndex = 34;
            this.rbScheduled.Text = "Scheduled";
            this.rbScheduled.UseVisualStyleBackColor = true;
            this.rbScheduled.CheckedChanged += new System.EventHandler(this.rbScheduled_CheckedChanged);
            // 
            // rbCanceled
            // 
            this.rbCanceled.AutoSize = true;
            this.rbCanceled.Location = new System.Drawing.Point(459, 294);
            this.rbCanceled.Name = "rbCanceled";
            this.rbCanceled.Size = new System.Drawing.Size(91, 24);
            this.rbCanceled.TabIndex = 33;
            this.rbCanceled.Text = "Canceled";
            this.rbCanceled.UseVisualStyleBackColor = true;
            this.rbCanceled.CheckedChanged += new System.EventHandler(this.rbCanceled_CheckedChanged);
            // 
            // rbClosed
            // 
            this.rbClosed.AutoSize = true;
            this.rbClosed.Location = new System.Drawing.Point(459, 243);
            this.rbClosed.Name = "rbClosed";
            this.rbClosed.Size = new System.Drawing.Size(173, 24);
            this.rbClosed.TabIndex = 32;
            this.rbClosed.Text = "Closed for registering";
            this.rbClosed.UseVisualStyleBackColor = true;
            this.rbClosed.CheckedChanged += new System.EventHandler(this.rbClosed_CheckedChanged);
            // 
            // rbOpen
            // 
            this.rbOpen.AutoSize = true;
            this.rbOpen.Location = new System.Drawing.Point(459, 196);
            this.rbOpen.Name = "rbOpen";
            this.rbOpen.Size = new System.Drawing.Size(164, 24);
            this.rbOpen.TabIndex = 31;
            this.rbOpen.Text = "Open for registering";
            this.rbOpen.UseVisualStyleBackColor = true;
            this.rbOpen.CheckedChanged += new System.EventHandler(this.rbOpen_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(459, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Filters:";
            // 
            // btnDeleteTournament
            // 
            this.btnDeleteTournament.Location = new System.Drawing.Point(38, 583);
            this.btnDeleteTournament.Name = "btnDeleteTournament";
            this.btnDeleteTournament.Size = new System.Drawing.Size(385, 55);
            this.btnDeleteTournament.TabIndex = 25;
            this.btnDeleteTournament.Text = "Delete tournament";
            this.btnDeleteTournament.UseVisualStyleBackColor = true;
            this.btnDeleteTournament.Click += new System.EventHandler(this.btnDeleteTournament_Click);
            // 
            // lbEditTournaments
            // 
            this.lbEditTournaments.FormattingEnabled = true;
            this.lbEditTournaments.ItemHeight = 20;
            this.lbEditTournaments.Location = new System.Drawing.Point(29, 132);
            this.lbEditTournaments.Name = "lbEditTournaments";
            this.lbEditTournaments.Size = new System.Drawing.Size(421, 324);
            this.lbEditTournaments.TabIndex = 0;
            this.lbEditTournaments.SelectedIndexChanged += new System.EventHandler(this.lbEditTournaments_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSportType);
            this.groupBox1.Controls.Add(this.tbTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rtbDescription);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numMinPlayers);
            this.groupBox1.Controls.Add(this.cmbTournamentSystem);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnEditTournament);
            this.groupBox1.Controls.Add(this.numMaxPlayers);
            this.groupBox1.Controls.Add(this.btnCreateTournament);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbLocation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 692);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create new tournament";
            // 
            // cmbSportType
            // 
            this.cmbSportType.FormattingEnabled = true;
            this.cmbSportType.Location = new System.Drawing.Point(165, 347);
            this.cmbSportType.Name = "cmbSportType";
            this.cmbSportType.Size = new System.Drawing.Size(251, 28);
            this.cmbSportType.TabIndex = 26;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(163, 41);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(253, 27);
            this.tbTitle.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Title: ";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(163, 87);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(253, 45);
            this.rtbDescription.TabIndex = 19;
            this.rtbDescription.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 393);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tournament system: ";
            // 
            // numMinPlayers
            // 
            this.numMinPlayers.Location = new System.Drawing.Point(163, 245);
            this.numMinPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMinPlayers.Name = "numMinPlayers";
            this.numMinPlayers.Size = new System.Drawing.Size(253, 27);
            this.numMinPlayers.TabIndex = 23;
            this.numMinPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // cmbTournamentSystem
            // 
            this.cmbTournamentSystem.FormattingEnabled = true;
            this.cmbTournamentSystem.Location = new System.Drawing.Point(163, 390);
            this.cmbTournamentSystem.Name = "cmbTournamentSystem";
            this.cmbTournamentSystem.Size = new System.Drawing.Size(253, 28);
            this.cmbTournamentSystem.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 349);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Sport type:";
            // 
            // btnEditTournament
            // 
            this.btnEditTournament.Location = new System.Drawing.Point(48, 583);
            this.btnEditTournament.Name = "btnEditTournament";
            this.btnEditTournament.Size = new System.Drawing.Size(385, 55);
            this.btnEditTournament.TabIndex = 24;
            this.btnEditTournament.Text = "Edit tournament";
            this.btnEditTournament.UseVisualStyleBackColor = true;
            this.btnEditTournament.Click += new System.EventHandler(this.btnEditTournament_Click);
            // 
            // numMaxPlayers
            // 
            this.numMaxPlayers.Location = new System.Drawing.Point(163, 297);
            this.numMaxPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMaxPlayers.Name = "numMaxPlayers";
            this.numMaxPlayers.Size = new System.Drawing.Size(253, 27);
            this.numMaxPlayers.TabIndex = 22;
            this.numMaxPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnCreateTournament
            // 
            this.btnCreateTournament.Location = new System.Drawing.Point(48, 496);
            this.btnCreateTournament.Name = "btnCreateTournament";
            this.btnCreateTournament.Size = new System.Drawing.Size(385, 55);
            this.btnCreateTournament.TabIndex = 16;
            this.btnCreateTournament.Text = "Create tournament";
            this.btnCreateTournament.UseVisualStyleBackColor = true;
            this.btnCreateTournament.Click += new System.EventHandler(this.btnCreateTournament_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 444);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(163, 441);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(253, 27);
            this.tbLocation.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Start date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "End date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Minimum players:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Maximum players:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(163, 148);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(253, 27);
            this.dtpStartDate.TabIndex = 12;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(163, 199);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(253, 27);
            this.dtpEndDate.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 1055);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbResults.ResumeLayout(false);
            this.gbResults.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbGames;
        private ListBox lbTournaments;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnGenerateSchedule;
        private GroupBox gbResults;
        private Button btmSaveResult;
        private TextBox tbResultPlayerTwo;
        private TextBox tbResultPlayerOne;
        private Label lblPlayerTwo;
        private Label lblPlayerOne;
        private Label label11;
        private Label label10;
        private TabPage tabPage2;
        private RadioButton rbAll;
        private RadioButton rbScheduled;
        private RadioButton rbCanceled;
        private GroupBox groupBox2;
        private Button btnDeleteTournament;
        private Button btnEditTournament;
        private ListBox lbEditTournaments;
        private RadioButton rbClosed;
        private RadioButton rbOpen;
        private Label label12;
        private GroupBox groupBox1;
        private TextBox tbTitle;
        private Label label1;
        private RichTextBox rtbDescription;
        private Label label9;
        private NumericUpDown numMinPlayers;
        private ComboBox cmbTournamentSystem;
        private Label label8;
        private NumericUpDown numMaxPlayers;
        private Button btnCreateTournament;
        private Label label7;
        private Label label2;
        private TextBox tbLocation;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private RadioButton rbtnAll;
        private RadioButton rbtnScheduled;
        private RadioButton rbtnCamceled;
        private RadioButton rbtnClosed;
        private RadioButton rbtnOpen;
        private Label label13;
        private Button btnGetTournamentByTitle;
        private Button btnFilterById;
        private TextBox tbTournamentTitle;
        private TextBox tbTournamentId;
        private ComboBox cmbSportType;
        private Button btnCancelTournament;
        private System.Windows.Forms.Timer statusTimer;
    }
}