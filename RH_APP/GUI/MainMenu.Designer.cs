namespace RH_APP.GUI
{
    partial class MainMenu
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
            this.createConnectionBbutton = new System.Windows.Forms.Button();
            this.displayDataButton = new System.Windows.Forms.Button();
            this.createUserButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createConnectionBbutton
            // 
            this.createConnectionBbutton.Location = new System.Drawing.Point(12, 123);
            this.createConnectionBbutton.Name = "createConnectionBbutton";
            this.createConnectionBbutton.Size = new System.Drawing.Size(111, 23);
            this.createConnectionBbutton.TabIndex = 0;
            this.createConnectionBbutton.Text = "Connect to a client";
            this.createConnectionBbutton.UseVisualStyleBackColor = true;
            this.createConnectionBbutton.Click += new System.EventHandler(this.createConnectionBbutton_Click);
            // 
            // displayDataButton
            // 
            this.displayDataButton.Location = new System.Drawing.Point(129, 152);
            this.displayDataButton.Name = "displayDataButton";
            this.displayDataButton.Size = new System.Drawing.Size(111, 23);
            this.displayDataButton.TabIndex = 1;
            this.displayDataButton.Text = "Display data";
            this.displayDataButton.UseVisualStyleBackColor = true;
            this.displayDataButton.Click += new System.EventHandler(this.displayDataButton_Click);
            // 
            // createUserButton
            // 
            this.createUserButton.Location = new System.Drawing.Point(12, 152);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(111, 23);
            this.createUserButton.TabIndex = 2;
            this.createUserButton.Text = "Create a new user";
            this.createUserButton.UseVisualStyleBackColor = true;
            this.createUserButton.Click += new System.EventHandler(this.createUserButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(9, 89);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(93, 13);
            this.welcomeLabel.TabIndex = 3;
            this.welcomeLabel.Text = "Welcom to sparta!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 42);
            this.label2.TabIndex = 8;
            this.label2.Text = "De Baronie";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Medisch Centrum";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 187);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.createUserButton);
            this.Controls.Add(this.displayDataButton);
            this.Controls.Add(this.createConnectionBbutton);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createConnectionBbutton;
        private System.Windows.Forms.Button displayDataButton;
        private System.Windows.Forms.Button createUserButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}