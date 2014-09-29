namespace Application_Specialist.GUI
{
    partial class SelectClientScreen
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
            this._connectButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // _connectButton
            // 
            this._connectButton.Location = new System.Drawing.Point(197, 226);
            this._connectButton.Name = "_connectButton";
            this._connectButton.Size = new System.Drawing.Size(75, 23);
            this._connectButton.TabIndex = 0;
            this._connectButton.Text = "Connect";
            this._connectButton.UseVisualStyleBackColor = true;
            // 
            // _exitButton
            // 
            this._exitButton.Location = new System.Drawing.Point(116, 226);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(75, 23);
            this._exitButton.TabIndex = 1;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select connection";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(61, 62);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 3;
            // 
            // SelectClientScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._connectButton);
            this.Name = "SelectClientScreen";
            this.Text = "Select connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _connectButton;
        private System.Windows.Forms.Button _exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}