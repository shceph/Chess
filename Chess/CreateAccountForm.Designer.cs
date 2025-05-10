﻿namespace Chess
{
    partial class CreateAccountForm
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
            buttonCreateAccount = new Button();
            textBoxPassword = new TextBox();
            labelPassword = new Label();
            textBoxUsername = new TextBox();
            labelUsername = new Label();
            labelConfirm = new Label();
            textBoxConfirm = new TextBox();
            SuspendLayout();
            // 
            // buttonCreateAccount
            // 
            buttonCreateAccount.Font = new Font("Cascadia Mono", 9F);
            buttonCreateAccount.Location = new Point(98, 324);
            buttonCreateAccount.Name = "buttonCreateAccount";
            buttonCreateAccount.Size = new Size(127, 29);
            buttonCreateAccount.TabIndex = 10;
            buttonCreateAccount.Text = "Create";
            buttonCreateAccount.UseVisualStyleBackColor = true;
            buttonCreateAccount.Click += ButtonCreateAccount_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPassword.Location = new Point(11, 147);
            textBoxPassword.MaxLength = 20;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(297, 25);
            textBoxPassword.TabIndex = 9;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPassword.Location = new Point(11, 109);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(198, 20);
            labelPassword.TabIndex = 8;
            labelPassword.Text = "Insert your password:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxUsername.Location = new Point(11, 45);
            textBoxUsername.MaxLength = 20;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(297, 25);
            textBoxUsername.TabIndex = 7;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUsername.Location = new Point(11, 9);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(198, 20);
            labelUsername.TabIndex = 6;
            labelUsername.Text = "Insert your username:";
            // 
            // labelConfirm
            // 
            labelConfirm.AutoSize = true;
            labelConfirm.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelConfirm.Location = new Point(11, 219);
            labelConfirm.Name = "labelConfirm";
            labelConfirm.Size = new Size(198, 20);
            labelConfirm.TabIndex = 8;
            labelConfirm.Text = "Confirm the password:";
            // 
            // textBoxConfirm
            // 
            textBoxConfirm.Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxConfirm.Location = new Point(11, 256);
            textBoxConfirm.MaxLength = 20;
            textBoxConfirm.Name = "textBoxConfirm";
            textBoxConfirm.PasswordChar = '*';
            textBoxConfirm.Size = new Size(297, 25);
            textBoxConfirm.TabIndex = 9;
            textBoxConfirm.UseSystemPasswordChar = true;
            // 
            // CreateAccountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 368);
            Controls.Add(buttonCreateAccount);
            Controls.Add(textBoxConfirm);
            Controls.Add(labelConfirm);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(labelUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CreateAccountForm";
            Text = "Create account";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCreateAccount;
        private TextBox textBoxPassword;
        private Label labelPassword;
        private TextBox textBoxUsername;
        private Label labelUsername;
        private Label labelConfirm;
        private TextBox textBoxConfirm;
    }
}