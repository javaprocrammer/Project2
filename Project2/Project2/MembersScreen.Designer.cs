namespace Project2
{
    partial class MembersScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MembersScreen));
            this.btnExit = new System.Windows.Forms.Button();
            this.tabMembers = new System.Windows.Forms.TabControl();
            this.tabMemMovies = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtRentDelete = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboViewList = new System.Windows.Forms.ComboBox();
            this.btnMView = new System.Windows.Forms.Button();
            this.btnMClear = new System.Windows.Forms.Button();
            this.btnMSave = new System.Windows.Forms.Button();
            this.txtRentalSave = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRatedSearch = new System.Windows.Forms.TextBox();
            this.txtGenreSearch = new System.Windows.Forms.TextBox();
            this.btnMRatedMovies = new System.Windows.Forms.Button();
            this.btnMGenreMovies = new System.Windows.Forms.Button();
            this.btnMAvailMovies = new System.Windows.Forms.Button();
            this.gridviewMemMovies = new System.Windows.Forms.DataGridView();
            this.tabMemAccount = new System.Windows.Forms.TabPage();
            this.btnMemClear = new System.Windows.Forms.Button();
            this.txtMemId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMZip = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMState = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMLname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMemUpdate = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtPlay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabMembers.SuspendLayout();
            this.tabMemMovies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewMemMovies)).BeginInit();
            this.tabMemAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(400, 566);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(190, 38);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit Meramec Movies\r\n";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabMembers
            // 
            this.tabMembers.Controls.Add(this.tabMemMovies);
            this.tabMembers.Controls.Add(this.tabMemAccount);
            this.tabMembers.Location = new System.Drawing.Point(23, 12);
            this.tabMembers.Name = "tabMembers";
            this.tabMembers.SelectedIndex = 0;
            this.tabMembers.Size = new System.Drawing.Size(944, 535);
            this.tabMembers.TabIndex = 1;
            // 
            // tabMemMovies
            // 
            this.tabMemMovies.BackColor = System.Drawing.Color.NavajoWhite;
            this.tabMemMovies.Controls.Add(this.btnPlay);
            this.tabMemMovies.Controls.Add(this.txtPlay);
            this.tabMemMovies.Controls.Add(this.label13);
            this.tabMemMovies.Controls.Add(this.btnDelete);
            this.tabMemMovies.Controls.Add(this.txtRentDelete);
            this.tabMemMovies.Controls.Add(this.label12);
            this.tabMemMovies.Controls.Add(this.label11);
            this.tabMemMovies.Controls.Add(this.cboViewList);
            this.tabMemMovies.Controls.Add(this.btnMView);
            this.tabMemMovies.Controls.Add(this.btnMClear);
            this.tabMemMovies.Controls.Add(this.btnMSave);
            this.tabMemMovies.Controls.Add(this.txtRentalSave);
            this.tabMemMovies.Controls.Add(this.label9);
            this.tabMemMovies.Controls.Add(this.txtRatedSearch);
            this.tabMemMovies.Controls.Add(this.txtGenreSearch);
            this.tabMemMovies.Controls.Add(this.btnMRatedMovies);
            this.tabMemMovies.Controls.Add(this.btnMGenreMovies);
            this.tabMemMovies.Controls.Add(this.btnMAvailMovies);
            this.tabMemMovies.Controls.Add(this.gridviewMemMovies);
            this.tabMemMovies.Location = new System.Drawing.Point(4, 25);
            this.tabMemMovies.Name = "tabMemMovies";
            this.tabMemMovies.Padding = new System.Windows.Forms.Padding(3);
            this.tabMemMovies.Size = new System.Drawing.Size(936, 506);
            this.tabMemMovies.TabIndex = 0;
            this.tabMemMovies.Text = "Select Movies";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.BurlyWood;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(841, 455);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtRentDelete
            // 
            this.txtRentDelete.Location = new System.Drawing.Point(711, 460);
            this.txtRentDelete.Name = "txtRentDelete";
            this.txtRentDelete.Size = new System.Drawing.Size(76, 22);
            this.txtRentDelete.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(706, 398);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(220, 51);
            this.label12.TabIndex = 13;
            this.label12.Text = "To delete movies from your watch\r\nlist enter the movie number and \r\npress \"Delete" +
    "\"";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(323, 414);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 34);
            this.label11.TabIndex = 12;
            this.label11.Text = "To view movies saved to your \r\nwatch list press \"View\"";
            // 
            // cboViewList
            // 
            this.cboViewList.FormattingEnabled = true;
            this.cboViewList.Location = new System.Drawing.Point(413, 459);
            this.cboViewList.Name = "cboViewList";
            this.cboViewList.Size = new System.Drawing.Size(253, 24);
            this.cboViewList.TabIndex = 11;
            // 
            // btnMView
            // 
            this.btnMView.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMView.Location = new System.Drawing.Point(326, 456);
            this.btnMView.Name = "btnMView";
            this.btnMView.Size = new System.Drawing.Size(75, 29);
            this.btnMView.TabIndex = 10;
            this.btnMView.Text = "View";
            this.btnMView.UseVisualStyleBackColor = false;
            this.btnMView.Click += new System.EventHandler(this.btnMView_Click);
            // 
            // btnMClear
            // 
            this.btnMClear.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMClear.Location = new System.Drawing.Point(768, 194);
            this.btnMClear.Name = "btnMClear";
            this.btnMClear.Size = new System.Drawing.Size(148, 49);
            this.btnMClear.TabIndex = 9;
            this.btnMClear.Text = "Clear Movie List\r\nand View List\r\n";
            this.btnMClear.UseVisualStyleBackColor = false;
            this.btnMClear.Click += new System.EventHandler(this.btnMClear_Click);
            // 
            // btnMSave
            // 
            this.btnMSave.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMSave.Location = new System.Drawing.Point(164, 456);
            this.btnMSave.Name = "btnMSave";
            this.btnMSave.Size = new System.Drawing.Size(75, 29);
            this.btnMSave.TabIndex = 8;
            this.btnMSave.Text = "Save";
            this.btnMSave.UseVisualStyleBackColor = false;
            this.btnMSave.Click += new System.EventHandler(this.btnMSave_Click);
            // 
            // txtRentalSave
            // 
            this.txtRentalSave.Location = new System.Drawing.Point(16, 459);
            this.txtRentalSave.Name = "txtRentalSave";
            this.txtRentalSave.Size = new System.Drawing.Size(84, 22);
            this.txtRentalSave.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 414);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(226, 34);
            this.label9.TabIndex = 6;
            this.label9.Text = "Enter in movie number of title \r\nyou want to rent then press \"Save\"";
            // 
            // txtRatedSearch
            // 
            this.txtRatedSearch.Location = new System.Drawing.Point(518, 249);
            this.txtRatedSearch.Name = "txtRatedSearch";
            this.txtRatedSearch.Size = new System.Drawing.Size(148, 22);
            this.txtRatedSearch.TabIndex = 5;
            // 
            // txtGenreSearch
            // 
            this.txtGenreSearch.Location = new System.Drawing.Point(268, 249);
            this.txtGenreSearch.Name = "txtGenreSearch";
            this.txtGenreSearch.Size = new System.Drawing.Size(148, 22);
            this.txtGenreSearch.TabIndex = 4;
            // 
            // btnMRatedMovies
            // 
            this.btnMRatedMovies.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMRatedMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMRatedMovies.Location = new System.Drawing.Point(518, 194);
            this.btnMRatedMovies.Name = "btnMRatedMovies";
            this.btnMRatedMovies.Size = new System.Drawing.Size(148, 49);
            this.btnMRatedMovies.TabIndex = 3;
            this.btnMRatedMovies.Text = "Show Movies Rated:";
            this.btnMRatedMovies.UseVisualStyleBackColor = false;
            this.btnMRatedMovies.Click += new System.EventHandler(this.btnMRatedMovies_Click);
            // 
            // btnMGenreMovies
            // 
            this.btnMGenreMovies.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMGenreMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMGenreMovies.Location = new System.Drawing.Point(268, 194);
            this.btnMGenreMovies.Name = "btnMGenreMovies";
            this.btnMGenreMovies.Size = new System.Drawing.Size(148, 49);
            this.btnMGenreMovies.TabIndex = 2;
            this.btnMGenreMovies.Text = "Show Movies of Genre:";
            this.btnMGenreMovies.UseVisualStyleBackColor = false;
            this.btnMGenreMovies.Click += new System.EventHandler(this.btnMGenreMovies_Click);
            // 
            // btnMAvailMovies
            // 
            this.btnMAvailMovies.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMAvailMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMAvailMovies.Location = new System.Drawing.Point(18, 194);
            this.btnMAvailMovies.Name = "btnMAvailMovies";
            this.btnMAvailMovies.Size = new System.Drawing.Size(148, 49);
            this.btnMAvailMovies.TabIndex = 1;
            this.btnMAvailMovies.Text = "Show All Movies";
            this.btnMAvailMovies.UseVisualStyleBackColor = false;
            this.btnMAvailMovies.Click += new System.EventHandler(this.btnMAvailMovies_Click);
            // 
            // gridviewMemMovies
            // 
            this.gridviewMemMovies.AllowUserToAddRows = false;
            this.gridviewMemMovies.AllowUserToDeleteRows = false;
            this.gridviewMemMovies.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridviewMemMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewMemMovies.Location = new System.Drawing.Point(16, 9);
            this.gridviewMemMovies.Name = "gridviewMemMovies";
            this.gridviewMemMovies.ReadOnly = true;
            this.gridviewMemMovies.RowTemplate.Height = 24;
            this.gridviewMemMovies.Size = new System.Drawing.Size(904, 179);
            this.gridviewMemMovies.TabIndex = 0;
            // 
            // tabMemAccount
            // 
            this.tabMemAccount.BackColor = System.Drawing.Color.NavajoWhite;
            this.tabMemAccount.Controls.Add(this.btnMemClear);
            this.tabMemAccount.Controls.Add(this.txtMemId);
            this.tabMemAccount.Controls.Add(this.label10);
            this.tabMemAccount.Controls.Add(this.txtMPass);
            this.tabMemAccount.Controls.Add(this.label8);
            this.tabMemAccount.Controls.Add(this.txtMPhone);
            this.tabMemAccount.Controls.Add(this.label7);
            this.tabMemAccount.Controls.Add(this.txtMZip);
            this.tabMemAccount.Controls.Add(this.label6);
            this.tabMemAccount.Controls.Add(this.txtMState);
            this.tabMemAccount.Controls.Add(this.label5);
            this.tabMemAccount.Controls.Add(this.txtMCity);
            this.tabMemAccount.Controls.Add(this.label4);
            this.tabMemAccount.Controls.Add(this.txtMAddress);
            this.tabMemAccount.Controls.Add(this.label3);
            this.tabMemAccount.Controls.Add(this.txtMLname);
            this.tabMemAccount.Controls.Add(this.label2);
            this.tabMemAccount.Controls.Add(this.txtMFname);
            this.tabMemAccount.Controls.Add(this.label1);
            this.tabMemAccount.Controls.Add(this.btnMemUpdate);
            this.tabMemAccount.Location = new System.Drawing.Point(4, 25);
            this.tabMemAccount.Name = "tabMemAccount";
            this.tabMemAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabMemAccount.Size = new System.Drawing.Size(936, 506);
            this.tabMemAccount.TabIndex = 1;
            this.tabMemAccount.Text = "Manage Account";
            // 
            // btnMemClear
            // 
            this.btnMemClear.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMemClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemClear.Location = new System.Drawing.Point(499, 427);
            this.btnMemClear.Name = "btnMemClear";
            this.btnMemClear.Size = new System.Drawing.Size(116, 57);
            this.btnMemClear.TabIndex = 19;
            this.btnMemClear.Text = "Clear Fields";
            this.btnMemClear.UseVisualStyleBackColor = false;
            this.btnMemClear.Click += new System.EventHandler(this.btnMemClear_Click);
            // 
            // txtMemId
            // 
            this.txtMemId.Location = new System.Drawing.Point(544, 316);
            this.txtMemId.Name = "txtMemId";
            this.txtMemId.ReadOnly = true;
            this.txtMemId.Size = new System.Drawing.Size(35, 22);
            this.txtMemId.TabIndex = 18;
            this.txtMemId.TextChanged += new System.EventHandler(this.txtMemId_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(358, 318);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "Member ID Number:";
            // 
            // txtMPass
            // 
            this.txtMPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMPass.Location = new System.Drawing.Point(665, 225);
            this.txtMPass.Name = "txtMPass";
            this.txtMPass.Size = new System.Drawing.Size(133, 22);
            this.txtMPass.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(539, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Password:";
            // 
            // txtMPhone
            // 
            this.txtMPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMPhone.Location = new System.Drawing.Point(665, 183);
            this.txtMPhone.Name = "txtMPhone";
            this.txtMPhone.Size = new System.Drawing.Size(133, 22);
            this.txtMPhone.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(536, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Phone Number:";
            // 
            // txtMZip
            // 
            this.txtMZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMZip.Location = new System.Drawing.Point(665, 134);
            this.txtMZip.Name = "txtMZip";
            this.txtMZip.Size = new System.Drawing.Size(133, 22);
            this.txtMZip.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(536, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Zipcode:";
            // 
            // txtMState
            // 
            this.txtMState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMState.Location = new System.Drawing.Point(665, 86);
            this.txtMState.Name = "txtMState";
            this.txtMState.Size = new System.Drawing.Size(39, 22);
            this.txtMState.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(536, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "State:";
            // 
            // txtMCity
            // 
            this.txtMCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMCity.Location = new System.Drawing.Point(194, 225);
            this.txtMCity.Name = "txtMCity";
            this.txtMCity.Size = new System.Drawing.Size(133, 22);
            this.txtMCity.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "City:";
            // 
            // txtMAddress
            // 
            this.txtMAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAddress.Location = new System.Drawing.Point(194, 183);
            this.txtMAddress.Name = "txtMAddress";
            this.txtMAddress.Size = new System.Drawing.Size(133, 22);
            this.txtMAddress.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address:";
            // 
            // txtMLname
            // 
            this.txtMLname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMLname.Location = new System.Drawing.Point(194, 134);
            this.txtMLname.Name = "txtMLname";
            this.txtMLname.Size = new System.Drawing.Size(133, 22);
            this.txtMLname.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name:";
            // 
            // txtMFname
            // 
            this.txtMFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMFname.Location = new System.Drawing.Point(194, 86);
            this.txtMFname.Name = "txtMFname";
            this.txtMFname.Size = new System.Drawing.Size(133, 22);
            this.txtMFname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            // 
            // btnMemUpdate
            // 
            this.btnMemUpdate.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMemUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemUpdate.Location = new System.Drawing.Point(321, 427);
            this.btnMemUpdate.Name = "btnMemUpdate";
            this.btnMemUpdate.Size = new System.Drawing.Size(116, 57);
            this.btnMemUpdate.TabIndex = 0;
            this.btnMemUpdate.Text = "Update Account Info.";
            this.btnMemUpdate.UseVisualStyleBackColor = false;
            this.btnMemUpdate.Click += new System.EventHandler(this.btnMemUpdate_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.BurlyWood;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(164, 345);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 29);
            this.btnPlay.TabIndex = 18;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // txtPlay
            // 
            this.txtPlay.Location = new System.Drawing.Point(16, 348);
            this.txtPlay.Name = "txtPlay";
            this.txtPlay.Size = new System.Drawing.Size(84, 22);
            this.txtPlay.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(13, 303);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(214, 34);
            this.label13.TabIndex = 16;
            this.label13.Text = "Enter in a movie number to \r\nwatch its trailer then press \"Play\"";
            // 
            // MembersScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.ClientSize = new System.Drawing.Size(991, 616);
            this.Controls.Add(this.tabMembers);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MembersScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MembersScreen";
            this.Load += new System.EventHandler(this.MembersScreen_Load);
            this.tabMembers.ResumeLayout(false);
            this.tabMemMovies.ResumeLayout(false);
            this.tabMemMovies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewMemMovies)).EndInit();
            this.tabMemAccount.ResumeLayout(false);
            this.tabMemAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabControl tabMembers;
        private System.Windows.Forms.TabPage tabMemMovies;
        private System.Windows.Forms.TabPage tabMemAccount;
        private System.Windows.Forms.Button btnMemUpdate;
        private System.Windows.Forms.TextBox txtMPass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMZip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMLname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMFname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMAvailMovies;
        private System.Windows.Forms.DataGridView gridviewMemMovies;
        private System.Windows.Forms.Button btnMClear;
        private System.Windows.Forms.Button btnMSave;
        private System.Windows.Forms.TextBox txtRentalSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRatedSearch;
        private System.Windows.Forms.TextBox txtGenreSearch;
        private System.Windows.Forms.Button btnMRatedMovies;
        private System.Windows.Forms.Button btnMGenreMovies;
        private System.Windows.Forms.TextBox txtMemId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboViewList;
        private System.Windows.Forms.Button btnMView;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtRentDelete;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnMemClear;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TextBox txtPlay;
        private System.Windows.Forms.Label label13;
    }
}