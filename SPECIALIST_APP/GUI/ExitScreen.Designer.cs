namespace Application_Specialist.GUI
{
    partial class ExitScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this._noButton = new System.Windows.Forms.Button();
            this._yesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Are you sure you want to exit?";
            // 
            // _noButton
            // 
            this._noButton.Location = new System.Drawing.Point(71, 72);
            this._noButton.Name = "_noButton";
            this._noButton.Size = new System.Drawing.Size(75, 23);
            this._noButton.TabIndex = 1;
            this._noButton.Text = "No";
            this._noButton.UseVisualStyleBackColor = true;
            this._noButton.Click += new System.EventHandler(this._noButton_Click);
            // 
            // _yesButton
            // 
            this._yesButton.Location = new System.Drawing.Point(212, 72);
            this._yesButton.Name = "_yesButton";
            this._yesButton.Size = new System.Drawing.Size(75, 23);
            this._yesButton.TabIndex = 2;
            this._yesButton.Text = "Yes";
            this._yesButton.UseVisualStyleBackColor = true;
            this._yesButton.Click += new System.EventHandler(this._yesButton_Click);
            // 
            // ExitScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 121);
            this.Controls.Add(this._yesButton);
            this.Controls.Add(this._noButton);
            this.Controls.Add(this.label1);
            this.Name = "ExitScreen";
            this.Text = "Alert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _noButton;
        private System.Windows.Forms.Button _yesButton;
    }
}