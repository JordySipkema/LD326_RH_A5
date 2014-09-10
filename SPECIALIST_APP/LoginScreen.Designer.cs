namespace SQL_Tutorial
{
    partial class LoginScreen
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
            this._usernameBox = new System.Windows.Forms.TextBox();
            this._passwordBox = new System.Windows.Forms.TextBox();
            this._loginButton = new System.Windows.Forms.Button();
            this._usernameLabel = new System.Windows.Forms.Label();
            this._passwordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _usernameBox
            // 
            this._usernameBox.Location = new System.Drawing.Point(108, 38);
            this._usernameBox.Name = "_usernameBox";
            this._usernameBox.Size = new System.Drawing.Size(127, 20);
            this._usernameBox.TabIndex = 0;
            // 
            // _passwordBox
            // 
            this._passwordBox.Location = new System.Drawing.Point(108, 81);
            this._passwordBox.Name = "_passwordBox";
            this._passwordBox.Size = new System.Drawing.Size(127, 20);
            this._passwordBox.TabIndex = 1;
            this._passwordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._passwordBox_KeyPress);
            // 
            // _loginButton
            // 
            this._loginButton.Location = new System.Drawing.Point(98, 145);
            this._loginButton.Name = "_loginButton";
            this._loginButton.Size = new System.Drawing.Size(75, 23);
            this._loginButton.TabIndex = 2;
            this._loginButton.Text = "Login";
            this._loginButton.UseVisualStyleBackColor = true;
            this._loginButton.Click += new System.EventHandler(this._loginButton_Click);
            // 
            // _usernameLabel
            // 
            this._usernameLabel.AutoSize = true;
            this._usernameLabel.Location = new System.Drawing.Point(47, 41);
            this._usernameLabel.Name = "_usernameLabel";
            this._usernameLabel.Size = new System.Drawing.Size(55, 13);
            this._usernameLabel.TabIndex = 3;
            this._usernameLabel.Text = "Username";
            // 
            // _passwordLabel
            // 
            this._passwordLabel.AutoSize = true;
            this._passwordLabel.Location = new System.Drawing.Point(49, 84);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(53, 13);
            this._passwordLabel.TabIndex = 4;
            this._passwordLabel.Text = "Password";
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 213);
            this.Controls.Add(this._passwordLabel);
            this.Controls.Add(this._usernameLabel);
            this.Controls.Add(this._loginButton);
            this.Controls.Add(this._passwordBox);
            this.Controls.Add(this._usernameBox);
            this.Name = "LoginScreen";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginScreen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _usernameBox;
        private System.Windows.Forms.TextBox _passwordBox;
        private System.Windows.Forms.Button _loginButton;
        private System.Windows.Forms.Label _usernameLabel;
        private System.Windows.Forms.Label _passwordLabel;
    }
}