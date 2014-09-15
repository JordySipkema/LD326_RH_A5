namespace RH_APP.GUI
{
    partial class chooseYourBikeUI
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
            this.TXTBikeButton = new System.Windows.Forms.Button();
            this.randomizeButton = new System.Windows.Forms.Button();
            this.comButton = new System.Windows.Forms.Button();
            this.writeToFileCheckbox = new System.Windows.Forms.CheckBox();
            this.comPortTextbox = new System.Windows.Forms.TextBox();
            this.readFromTextbox = new System.Windows.Forms.TextBox();
            this.writeLocationTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TXTBikeButton
            // 
            this.TXTBikeButton.Location = new System.Drawing.Point(12, 11);
            this.TXTBikeButton.Name = "TXTBikeButton";
            this.TXTBikeButton.Size = new System.Drawing.Size(113, 23);
            this.TXTBikeButton.TabIndex = 0;
            this.TXTBikeButton.Text = "Read from file";
            this.TXTBikeButton.UseVisualStyleBackColor = true;
            this.TXTBikeButton.Click += new System.EventHandler(this.TXTBikeButton_Click);
            // 
            // randomizeButton
            // 
            this.randomizeButton.Location = new System.Drawing.Point(12, 40);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(113, 23);
            this.randomizeButton.TabIndex = 1;
            this.randomizeButton.Text = "Randomize";
            this.randomizeButton.UseVisualStyleBackColor = true;
            this.randomizeButton.Click += new System.EventHandler(this.randomizeButton_Click);
            // 
            // comButton
            // 
            this.comButton.Location = new System.Drawing.Point(12, 69);
            this.comButton.Name = "comButton";
            this.comButton.Size = new System.Drawing.Size(113, 23);
            this.comButton.TabIndex = 2;
            this.comButton.Text = "Read from COM";
            this.comButton.UseVisualStyleBackColor = true;
            this.comButton.Click += new System.EventHandler(this.comButton_Click);
            // 
            // writeToFileCheckbox
            // 
            this.writeToFileCheckbox.AutoSize = true;
            this.writeToFileCheckbox.Location = new System.Drawing.Point(12, 100);
            this.writeToFileCheckbox.Name = "writeToFileCheckbox";
            this.writeToFileCheckbox.Size = new System.Drawing.Size(103, 17);
            this.writeToFileCheckbox.TabIndex = 3;
            this.writeToFileCheckbox.Text = "Write data to file";
            this.writeToFileCheckbox.UseVisualStyleBackColor = true;
            // 
            // comPortTextbox
            // 
            this.comPortTextbox.Location = new System.Drawing.Point(134, 71);
            this.comPortTextbox.Name = "comPortTextbox";
            this.comPortTextbox.Size = new System.Drawing.Size(100, 20);
            this.comPortTextbox.TabIndex = 4;
            this.comPortTextbox.Text = "COM3";
            // 
            // readFromTextbox
            // 
            this.readFromTextbox.Location = new System.Drawing.Point(131, 13);
            this.readFromTextbox.Name = "readFromTextbox";
            this.readFromTextbox.Size = new System.Drawing.Size(356, 20);
            this.readFromTextbox.TabIndex = 6;
            // 
            // writeLocationTextbox
            // 
            this.writeLocationTextbox.Location = new System.Drawing.Point(134, 98);
            this.writeLocationTextbox.Name = "writeLocationTextbox";
            this.writeLocationTextbox.Size = new System.Drawing.Size(353, 20);
            this.writeLocationTextbox.TabIndex = 7;
            // 
            // chooseYourBikeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 126);
            this.Controls.Add(this.writeLocationTextbox);
            this.Controls.Add(this.readFromTextbox);
            this.Controls.Add(this.comPortTextbox);
            this.Controls.Add(this.writeToFileCheckbox);
            this.Controls.Add(this.comButton);
            this.Controls.Add(this.randomizeButton);
            this.Controls.Add(this.TXTBikeButton);
            this.Name = "chooseYourBikeUI";
            this.Text = "Selection screen";
            this.Load += new System.EventHandler(this.chooseYourBikeUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TXTBikeButton;
        private System.Windows.Forms.Button randomizeButton;
        private System.Windows.Forms.Button comButton;
        private System.Windows.Forms.CheckBox writeToFileCheckbox;
        private System.Windows.Forms.TextBox comPortTextbox;
        private System.Windows.Forms.TextBox readFromTextbox;
        private System.Windows.Forms.TextBox writeLocationTextbox;
    }
}