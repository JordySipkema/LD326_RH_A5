namespace RH_APP.GUI
{
    partial class CreateConnectionScreen
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
            this._clientList = new System.Windows.Forms.ListBox();
            this._connectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _clientList
            // 
            this._clientList.FormattingEnabled = true;
            this._clientList.Location = new System.Drawing.Point(12, 68);
            this._clientList.Name = "_clientList";
            this._clientList.Size = new System.Drawing.Size(312, 212);
            this._clientList.TabIndex = 0;
            this._clientList.SelectedIndexChanged += new System.EventHandler(this._clientList_SelectedIndexChanged);
            // 
            // _connectButton
            // 
            this._connectButton.Location = new System.Drawing.Point(211, 310);
            this._connectButton.Name = "_connectButton";
            this._connectButton.Size = new System.Drawing.Size(113, 49);
            this._connectButton.TabIndex = 1;
            this._connectButton.Text = "Connect";
            this._connectButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select connection";
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(12, 310);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(113, 49);
            this._cancelButton.TabIndex = 3;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // CreateConnectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 371);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._connectButton);
            this.Controls.Add(this._clientList);
            this.Name = "CreateConnectionScreen";
            this.Text = "Create Connection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateConnectionScreen_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _clientList;
        private System.Windows.Forms.Button _connectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _cancelButton;
    }
}