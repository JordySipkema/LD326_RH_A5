namespace SQL_Tutorial.GUI
{
    partial class CreateScreen
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
            this._createButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._nameBox = new System.Windows.Forms.TextBox();
            this._surnameBox = new System.Windows.Forms.TextBox();
            this._nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._genderBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clientRadioButton = new System.Windows.Forms.RadioButton();
            this.specialistRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Usernamebox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.dateOfBirthPicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _createButton
            // 
            this._createButton.Location = new System.Drawing.Point(203, 239);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(75, 23);
            this._createButton.TabIndex = 0;
            this._createButton.Text = "Create";
            this._createButton.UseVisualStyleBackColor = true;
            this._createButton.Click += new System.EventHandler(this._createButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(12, 239);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _nameBox
            // 
            this._nameBox.Location = new System.Drawing.Point(78, 60);
            this._nameBox.Name = "_nameBox";
            this._nameBox.Size = new System.Drawing.Size(200, 20);
            this._nameBox.TabIndex = 2;
            this._nameBox.Leave += new System.EventHandler(this._nameBox_Leave);
            // 
            // _surnameBox
            // 
            this._surnameBox.Location = new System.Drawing.Point(78, 86);
            this._surnameBox.Name = "_surnameBox";
            this._surnameBox.Size = new System.Drawing.Size(200, 20);
            this._surnameBox.TabIndex = 3;
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(12, 60);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(35, 13);
            this._nameLabel.TabIndex = 5;
            this._nameLabel.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gender";
            // 
            // _genderBox
            // 
            this._genderBox.FormattingEnabled = true;
            this._genderBox.Items.AddRange(new object[] {
            "M",
            "F"});
            this._genderBox.Location = new System.Drawing.Point(78, 137);
            this._genderBox.Name = "_genderBox";
            this._genderBox.Size = new System.Drawing.Size(44, 21);
            this._genderBox.TabIndex = 8;
            this._genderBox.SelectedIndexChanged += new System.EventHandler(this._genderBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "Create user";
            // 
            // clientRadioButton
            // 
            this.clientRadioButton.AutoSize = true;
            this.clientRadioButton.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.clientRadioButton.Checked = true;
            this.clientRadioButton.Location = new System.Drawing.Point(76, 164);
            this.clientRadioButton.Name = "clientRadioButton";
            this.clientRadioButton.Size = new System.Drawing.Size(51, 17);
            this.clientRadioButton.TabIndex = 11;
            this.clientRadioButton.TabStop = true;
            this.clientRadioButton.Text = "Client";
            this.clientRadioButton.UseVisualStyleBackColor = true;
            this.clientRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // specialistRadioButton
            // 
            this.specialistRadioButton.AutoSize = true;
            this.specialistRadioButton.Location = new System.Drawing.Point(133, 164);
            this.specialistRadioButton.Name = "specialistRadioButton";
            this.specialistRadioButton.Size = new System.Drawing.Size(70, 17);
            this.specialistRadioButton.TabIndex = 12;
            this.specialistRadioButton.Text = "Specialist";
            this.specialistRadioButton.UseVisualStyleBackColor = true;
            this.specialistRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Password";
            // 
            // Usernamebox
            // 
            this.Usernamebox.Location = new System.Drawing.Point(76, 187);
            this.Usernamebox.Name = "Usernamebox";
            this.Usernamebox.Size = new System.Drawing.Size(202, 20);
            this.Usernamebox.TabIndex = 15;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(76, 213);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(202, 20);
            this.passwordBox.TabIndex = 16;
            // 
            // dateOfBirthPicker
            // 
            this.dateOfBirthPicker.Location = new System.Drawing.Point(78, 111);
            this.dateOfBirthPicker.Name = "dateOfBirthPicker";
            this.dateOfBirthPicker.Size = new System.Drawing.Size(200, 20);
            this.dateOfBirthPicker.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Date of birth";
            // 
            // CreateScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 272);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateOfBirthPicker);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.Usernamebox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.specialistRadioButton);
            this.Controls.Add(this.clientRadioButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._genderBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._surnameBox);
            this.Controls.Add(this._nameBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._createButton);
            this.Name = "CreateScreen";
            this.Text = "Create user";
            this.Load += new System.EventHandler(this.CreateScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _createButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.TextBox _nameBox;
        private System.Windows.Forms.TextBox _surnameBox;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _genderBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton clientRadioButton;
        private System.Windows.Forms.RadioButton specialistRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Usernamebox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.DateTimePicker dateOfBirthPicker;
        private System.Windows.Forms.Label label6;
    }
}