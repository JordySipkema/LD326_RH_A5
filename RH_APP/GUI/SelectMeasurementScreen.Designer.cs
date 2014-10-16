namespace RH_APP.GUI
{
    partial class SelectMeasurementScreen
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
            this.components = new System.ComponentModel.Container();
            this.usersCombobox = new System.Windows.Forms.ComboBox();
            this.datecombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this._displayButton = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // usersCombobox
            // 
            this.usersCombobox.FormattingEnabled = true;
            this.usersCombobox.Location = new System.Drawing.Point(12, 38);
            this.usersCombobox.Name = "usersCombobox";
            this.usersCombobox.Size = new System.Drawing.Size(175, 21);
            this.usersCombobox.TabIndex = 0;
            this.usersCombobox.SelectedIndexChanged += new System.EventHandler(this.usersCombobox_SelectedIndexChanged);
            // 
            // datecombobox
            // 
            this.datecombobox.FormattingEnabled = true;
            this.datecombobox.Location = new System.Drawing.Point(193, 38);
            this.datecombobox.Name = "datecombobox";
            this.datecombobox.Size = new System.Drawing.Size(169, 21);
            this.datecombobox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date";
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(12, 66);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(110, 24);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _displayButton
            // 
            this._displayButton.Location = new System.Drawing.Point(252, 65);
            this._displayButton.Name = "_displayButton";
            this._displayButton.Size = new System.Drawing.Size(110, 24);
            this._displayButton.TabIndex = 5;
            this._displayButton.Text = "Display";
            this._displayButton.UseVisualStyleBackColor = true;
            this._displayButton.Click += new System.EventHandler(this._displayButton_Click);
            // 
            // SelectMeasurementScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 102);
            this.Controls.Add(this._displayButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datecombobox);
            this.Controls.Add(this.usersCombobox);
            this.Name = "SelectMeasurementScreen";
            this.Text = "Select a training session";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox usersCombobox;
        private System.Windows.Forms.ComboBox datecombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _displayButton;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}