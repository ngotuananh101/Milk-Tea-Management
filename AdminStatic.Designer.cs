
namespace MilkTeaManagement
{
    partial class AdminStatic
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
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbbEmployeeId = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbFemale1 = new System.Windows.Forms.RadioButton();
            this.rdbMale1 = new System.Windows.Forms.RadioButton();
            this.txtEUserId = new System.Windows.Forms.TextBox();
            this.txtEAddress = new System.Windows.Forms.TextBox();
            this.txtEPhone = new System.Windows.Forms.TextBox();
            this.txtEEmail = new System.Windows.Forms.TextBox();
            this.txtEDob = new System.Windows.Forms.TextBox();
            this.txtEName = new System.Windows.Forms.TextBox();
            this.txtEId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbFemale2 = new System.Windows.Forms.RadioButton();
            this.rdbMale2 = new System.Windows.Forms.RadioButton();
            this.txtMUserId = new System.Windows.Forms.TextBox();
            this.txtMAddress = new System.Windows.Forms.TextBox();
            this.txtMPhone = new System.Windows.Forms.TextBox();
            this.txtMEmail = new System.Windows.Forms.TextBox();
            this.txtMDob = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtMId = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(12, 172);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowTemplate.Height = 25;
            this.dgvOrder.Size = new System.Drawing.Size(800, 688);
            this.dgvOrder.TabIndex = 0;
            this.dgvOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(166, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sales and Revenue";
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.Location = new System.Drawing.Point(630, 968);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(182, 35);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export ";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cbbEmployeeId);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dpTo);
            this.groupBox1.Controls.Add(this.dpFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 117);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(354, 81);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 25);
            this.label21.TabIndex = 10;
            this.label21.Text = "Or";
            // 
            // cbbEmployeeId
            // 
            this.cbbEmployeeId.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbbEmployeeId.FormattingEnabled = true;
            this.cbbEmployeeId.Location = new System.Drawing.Point(403, 78);
            this.cbbEmployeeId.Name = "cbbEmployeeId";
            this.cbbEmployeeId.Size = new System.Drawing.Size(262, 33);
            this.cbbEmployeeId.TabIndex = 9;
            this.cbbEmployeeId.SelectedIndexChanged += new System.EventHandler(this.cbbEmployeeId_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(126, 78);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 33);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cashier ID:";
            // 
            // dpTo
            // 
            this.dpTo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dpTo.Location = new System.Drawing.Point(441, 25);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(313, 33);
            this.dpTo.TabIndex = 6;
            this.dpTo.ValueChanged += new System.EventHandler(this.dpTo_ValueChanged);
            // 
            // dpFrom
            // 
            this.dpFrom.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dpFrom.Location = new System.Drawing.Point(78, 25);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(309, 33);
            this.dpFrom.TabIndex = 5;
            this.dpFrom.ValueChanged += new System.EventHandler(this.dpFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(403, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "To";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(868, 70);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.RowTemplate.Height = 25;
            this.dgvOrderDetails.Size = new System.Drawing.Size(800, 443);
            this.dgvOrderDetails.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbFemale1);
            this.groupBox2.Controls.Add(this.rdbMale1);
            this.groupBox2.Controls.Add(this.txtEUserId);
            this.groupBox2.Controls.Add(this.txtEAddress);
            this.groupBox2.Controls.Add(this.txtEPhone);
            this.groupBox2.Controls.Add(this.txtEEmail);
            this.groupBox2.Controls.Add(this.txtEDob);
            this.groupBox2.Controls.Add(this.txtEName);
            this.groupBox2.Controls.Add(this.txtEId);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(868, 539);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 464);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cashier Detail";
            // 
            // rdbFemale1
            // 
            this.rdbFemale1.AutoSize = true;
            this.rdbFemale1.Enabled = false;
            this.rdbFemale1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbFemale1.Location = new System.Drawing.Point(211, 299);
            this.rdbFemale1.Name = "rdbFemale1";
            this.rdbFemale1.Size = new System.Drawing.Size(78, 25);
            this.rdbFemale1.TabIndex = 19;
            this.rdbFemale1.TabStop = true;
            this.rdbFemale1.Text = "Female";
            this.rdbFemale1.UseVisualStyleBackColor = true;
            // 
            // rdbMale1
            // 
            this.rdbMale1.AutoSize = true;
            this.rdbMale1.Enabled = false;
            this.rdbMale1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbMale1.Location = new System.Drawing.Point(143, 299);
            this.rdbMale1.Name = "rdbMale1";
            this.rdbMale1.Size = new System.Drawing.Size(62, 25);
            this.rdbMale1.TabIndex = 18;
            this.rdbMale1.TabStop = true;
            this.rdbMale1.Text = "Male";
            this.rdbMale1.UseVisualStyleBackColor = true;
            // 
            // txtEUserId
            // 
            this.txtEUserId.Enabled = false;
            this.txtEUserId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEUserId.Location = new System.Drawing.Point(143, 339);
            this.txtEUserId.Name = "txtEUserId";
            this.txtEUserId.Size = new System.Drawing.Size(245, 29);
            this.txtEUserId.TabIndex = 17;
            // 
            // txtEAddress
            // 
            this.txtEAddress.Enabled = false;
            this.txtEAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEAddress.Location = new System.Drawing.Point(143, 249);
            this.txtEAddress.Name = "txtEAddress";
            this.txtEAddress.Size = new System.Drawing.Size(245, 29);
            this.txtEAddress.TabIndex = 16;
            // 
            // txtEPhone
            // 
            this.txtEPhone.Enabled = false;
            this.txtEPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEPhone.Location = new System.Drawing.Point(143, 204);
            this.txtEPhone.Name = "txtEPhone";
            this.txtEPhone.Size = new System.Drawing.Size(245, 29);
            this.txtEPhone.TabIndex = 15;
            // 
            // txtEEmail
            // 
            this.txtEEmail.Enabled = false;
            this.txtEEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEEmail.Location = new System.Drawing.Point(143, 158);
            this.txtEEmail.Name = "txtEEmail";
            this.txtEEmail.Size = new System.Drawing.Size(245, 29);
            this.txtEEmail.TabIndex = 13;
            // 
            // txtEDob
            // 
            this.txtEDob.Enabled = false;
            this.txtEDob.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEDob.Location = new System.Drawing.Point(143, 113);
            this.txtEDob.Name = "txtEDob";
            this.txtEDob.Size = new System.Drawing.Size(245, 29);
            this.txtEDob.TabIndex = 12;
            // 
            // txtEName
            // 
            this.txtEName.Enabled = false;
            this.txtEName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEName.Location = new System.Drawing.Point(143, 69);
            this.txtEName.Name = "txtEName";
            this.txtEName.Size = new System.Drawing.Size(245, 29);
            this.txtEName.TabIndex = 11;
            // 
            // txtEId
            // 
            this.txtEId.Enabled = false;
            this.txtEId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEId.Location = new System.Drawing.Point(143, 22);
            this.txtEId.Name = "txtEId";
            this.txtEId.Size = new System.Drawing.Size(245, 29);
            this.txtEId.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(6, 347);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 21);
            this.label14.TabIndex = 9;
            this.label14.Text = "User ID:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(7, 251);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 21);
            this.label13.TabIndex = 8;
            this.label13.Text = "Address:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(6, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 21);
            this.label12.TabIndex = 7;
            this.label12.Text = "Gender:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(7, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 21);
            this.label11.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(6, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 21);
            this.label10.TabIndex = 5;
            this.label10.Text = "Phone:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(6, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "Email:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(6, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Date of birth:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Employee Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Employee ID :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(1167, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(187, 37);
            this.label15.TabIndex = 7;
            this.label15.Text = "Order Details";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbFemale2);
            this.groupBox3.Controls.Add(this.rdbMale2);
            this.groupBox3.Controls.Add(this.txtMUserId);
            this.groupBox3.Controls.Add(this.txtMAddress);
            this.groupBox3.Controls.Add(this.txtMPhone);
            this.groupBox3.Controls.Add(this.txtMEmail);
            this.groupBox3.Controls.Add(this.txtMDob);
            this.groupBox3.Controls.Add(this.txtMName);
            this.groupBox3.Controls.Add(this.txtMId);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Location = new System.Drawing.Point(1268, 539);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 464);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manager Details";
            // 
            // rdbFemale2
            // 
            this.rdbFemale2.AutoSize = true;
            this.rdbFemale2.Enabled = false;
            this.rdbFemale2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbFemale2.Location = new System.Drawing.Point(209, 299);
            this.rdbFemale2.Name = "rdbFemale2";
            this.rdbFemale2.Size = new System.Drawing.Size(78, 25);
            this.rdbFemale2.TabIndex = 19;
            this.rdbFemale2.TabStop = true;
            this.rdbFemale2.Text = "Female";
            this.rdbFemale2.UseVisualStyleBackColor = true;
            // 
            // rdbMale2
            // 
            this.rdbMale2.AutoSize = true;
            this.rdbMale2.Enabled = false;
            this.rdbMale2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdbMale2.Location = new System.Drawing.Point(141, 299);
            this.rdbMale2.Name = "rdbMale2";
            this.rdbMale2.Size = new System.Drawing.Size(62, 25);
            this.rdbMale2.TabIndex = 18;
            this.rdbMale2.TabStop = true;
            this.rdbMale2.Text = "Male";
            this.rdbMale2.UseVisualStyleBackColor = true;
            // 
            // txtMUserId
            // 
            this.txtMUserId.Enabled = false;
            this.txtMUserId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMUserId.Location = new System.Drawing.Point(141, 339);
            this.txtMUserId.Name = "txtMUserId";
            this.txtMUserId.Size = new System.Drawing.Size(253, 29);
            this.txtMUserId.TabIndex = 17;
            // 
            // txtMAddress
            // 
            this.txtMAddress.Enabled = false;
            this.txtMAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMAddress.Location = new System.Drawing.Point(141, 249);
            this.txtMAddress.Name = "txtMAddress";
            this.txtMAddress.Size = new System.Drawing.Size(253, 29);
            this.txtMAddress.TabIndex = 16;
            // 
            // txtMPhone
            // 
            this.txtMPhone.Enabled = false;
            this.txtMPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMPhone.Location = new System.Drawing.Point(141, 204);
            this.txtMPhone.Name = "txtMPhone";
            this.txtMPhone.Size = new System.Drawing.Size(253, 29);
            this.txtMPhone.TabIndex = 15;
            // 
            // txtMEmail
            // 
            this.txtMEmail.Enabled = false;
            this.txtMEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMEmail.Location = new System.Drawing.Point(141, 158);
            this.txtMEmail.Name = "txtMEmail";
            this.txtMEmail.Size = new System.Drawing.Size(253, 29);
            this.txtMEmail.TabIndex = 13;
            // 
            // txtMDob
            // 
            this.txtMDob.Enabled = false;
            this.txtMDob.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMDob.Location = new System.Drawing.Point(141, 113);
            this.txtMDob.Name = "txtMDob";
            this.txtMDob.Size = new System.Drawing.Size(253, 29);
            this.txtMDob.TabIndex = 12;
            // 
            // txtMName
            // 
            this.txtMName.Enabled = false;
            this.txtMName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMName.Location = new System.Drawing.Point(141, 72);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(253, 29);
            this.txtMName.TabIndex = 11;
            // 
            // txtMId
            // 
            this.txtMId.Enabled = false;
            this.txtMId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMId.Location = new System.Drawing.Point(141, 28);
            this.txtMId.Name = "txtMId";
            this.txtMId.Size = new System.Drawing.Size(253, 29);
            this.txtMId.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(10, 342);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 21);
            this.label16.TabIndex = 9;
            this.label16.Text = "User ID:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(10, 251);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 21);
            this.label17.TabIndex = 8;
            this.label17.Text = "Address:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(8, 303);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 21);
            this.label18.TabIndex = 7;
            this.label18.Text = "Gender:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 204);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 15);
            this.label19.TabIndex = 6;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(10, 204);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 21);
            this.label20.TabIndex = 5;
            this.label20.Text = "Phone:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(10, 158);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 21);
            this.label22.TabIndex = 3;
            this.label22.Text = "Email:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(10, 116);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 21);
            this.label23.TabIndex = 2;
            this.label23.Text = "Date of birth:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(10, 72);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 21);
            this.label24.TabIndex = 1;
            this.label24.Text = "Manager Name :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(10, 28);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(98, 21);
            this.label25.TabIndex = 0;
            this.label25.Text = "Manager ID :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(7, 886);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(219, 25);
            this.lblTotal.TabIndex = 21;
            this.lblTotal.Text = "Total Revenue By Date :";
            // 
            // AdminStatic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1680, 1015);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvOrderDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminStatic";
            this.Text = "Statistic";
            this.Load += new System.EventHandler(this.Statistic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdbFemale1;
        private System.Windows.Forms.RadioButton rdbMale1;
        private System.Windows.Forms.TextBox txtEUserId;
        private System.Windows.Forms.TextBox txtEAddress;
        private System.Windows.Forms.TextBox txtEPhone;
        private System.Windows.Forms.TextBox txtEEmail;
        private System.Windows.Forms.TextBox txtEDob;
        private System.Windows.Forms.TextBox txtEName;
        private System.Windows.Forms.TextBox txtEId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbFemale2;
        private System.Windows.Forms.RadioButton rdbMale2;
        private System.Windows.Forms.TextBox txtMUserId;
        private System.Windows.Forms.TextBox txtMAddress;
        private System.Windows.Forms.TextBox txtMPhone;
        private System.Windows.Forms.TextBox txtMEmail;
        private System.Windows.Forms.TextBox txtMDob;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtMId;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbbEmployeeId;
    }
}