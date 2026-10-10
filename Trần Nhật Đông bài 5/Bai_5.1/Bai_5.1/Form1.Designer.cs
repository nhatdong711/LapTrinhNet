namespace Bai_5._1
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            lblGender = new Label();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();
            chkTerms = new CheckBox();
            btnRegister = new Button();
            btnReset = new Button();
            epCheck = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)epCheck).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(226, 20);
            label1.Name = "label1";
            label1.Size = new Size(247, 31);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(123, 87);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(107, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên đăng nhập";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(295, 84);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(184, 27);
            txtUsername.TabIndex = 2;
            txtUsername.TextChanged += textBox1_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(123, 133);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(295, 133);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(184, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(123, 183);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(134, 20);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Xác nhận mật khẩu";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(295, 183);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(183, 27);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Location = new Point(123, 233);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(74, 20);
            lblBirthDate.TabIndex = 7;
            lblBirthDate.Text = "Ngày sinh";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(295, 233);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(219, 27);
            dtpBirthDate.TabIndex = 8;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(123, 285);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(65, 20);
            lblGender.TabIndex = 9;
            lblGender.Text = "Giới tính";
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(295, 285);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(62, 24);
            rdoMale.TabIndex = 10;
            rdoMale.TabStop = true;
            rdoMale.Text = "Nam";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(406, 285);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(50, 24);
            rdoFemale.TabIndex = 11;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Nữ";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // chkTerms
            // 
            chkTerms.AutoSize = true;
            chkTerms.Location = new Point(226, 326);
            chkTerms.Name = "chkTerms";
            chkTerms.Size = new Size(253, 24);
            chkTerms.TabIndex = 12;
            chkTerms.Text = "Tôi đồng ý với điều khoản dịch vụ";
            chkTerms.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            btnRegister.AllowDrop = true;
            btnRegister.Location = new Point(176, 369);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Đăng Ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnReset
            // 
            btnReset.AllowDrop = true;
            btnReset.Location = new Point(340, 369);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 14;
            btnReset.Text = "Làm Mới";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // epCheck
            // 
            epCheck.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 450);
            Controls.Add(btnReset);
            Controls.Add(btnRegister);
            Controls.Add(chkTerms);
            Controls.Add(rdoFemale);
            Controls.Add(rdoMale);
            Controls.Add(lblGender);
            Controls.Add(dtpBirthDate);
            Controls.Add(lblBirthDate);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)epCheck).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Label lblBirthDate;
        private DateTimePicker dtpBirthDate;
        private Label lblGender;
        private RadioButton rdoMale;
        private RadioButton rdoFemale;
        private CheckBox chkTerms;
        private Button btnRegister;
        private Button btnReset;
        private ErrorProvider epCheck;
    }
}
