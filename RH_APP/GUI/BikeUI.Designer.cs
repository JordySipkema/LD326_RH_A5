namespace RH_APP.GUI
{
    partial class RH_BIKE_GUI
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataRPM = new System.Windows.Forms.Label();
            this.dataSPEED = new System.Windows.Forms.Label();
            this.dataDISTANCE = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataTIME = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataPOWERPCT = new System.Windows.Forms.Label();
            this.dataPOWER = new System.Windows.Forms.Label();
            this.dataENERGY = new System.Windows.Forms.Label();
            this.dataPULSE = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this._chatLogBox = new System.Windows.Forms.TextBox();
            this._textBox = new System.Windows.Forms.TextBox();
            this._sendButton = new System.Windows.Forms.Button();
            this.measurementBindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RPM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SPEED";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DISTANCE";
            // 
            // dataRPM
            // 
            this.dataRPM.AutoSize = true;
            this.dataRPM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "RPM", true));
            this.dataRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataRPM.Location = new System.Drawing.Point(56, 47);
            this.dataRPM.Name = "dataRPM";
            this.dataRPM.Size = new System.Drawing.Size(50, 37);
            this.dataRPM.TabIndex = 3;
            this.dataRPM.Text = "---";
            this.dataRPM.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataSPEED
            // 
            this.dataSPEED.AutoSize = true;
            this.dataSPEED.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "SPEED", true));
            this.dataSPEED.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSPEED.Location = new System.Drawing.Point(194, 47);
            this.dataSPEED.Name = "dataSPEED";
            this.dataSPEED.Size = new System.Drawing.Size(71, 37);
            this.dataSPEED.TabIndex = 4;
            this.dataSPEED.Text = "---.-";
            this.dataSPEED.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataDISTANCE
            // 
            this.dataDISTANCE.AutoSize = true;
            this.dataDISTANCE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "DISTANCE", true));
            this.dataDISTANCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDISTANCE.Location = new System.Drawing.Point(314, 47);
            this.dataDISTANCE.Name = "dataDISTANCE";
            this.dataDISTANCE.Size = new System.Drawing.Size(71, 37);
            this.dataDISTANCE.TabIndex = 5;
            this.dataDISTANCE.Text = "--.--";
            this.dataDISTANCE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "TIME";
            // 
            // dataTIME
            // 
            this.dataTIME.AutoSize = true;
            this.dataTIME.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "TIME", true));
            this.dataTIME.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTIME.Location = new System.Drawing.Point(167, 110);
            this.dataTIME.Name = "dataTIME";
            this.dataTIME.Size = new System.Drawing.Size(106, 55);
            this.dataTIME.TabIndex = 7;
            this.dataTIME.Text = "--:--";
            this.dataTIME.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "POWER";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(173, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "ENERGY";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(317, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "PULSE";
            // 
            // dataPOWERPCT
            // 
            this.dataPOWERPCT.AutoSize = true;
            this.dataPOWERPCT.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "POWERPCT", true));
            this.dataPOWERPCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPOWERPCT.Location = new System.Drawing.Point(58, 131);
            this.dataPOWERPCT.Name = "dataPOWERPCT";
            this.dataPOWERPCT.Size = new System.Drawing.Size(45, 29);
            this.dataPOWERPCT.TabIndex = 11;
            this.dataPOWERPCT.Text = "-%";
            this.dataPOWERPCT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataPOWER
            // 
            this.dataPOWER.AutoSize = true;
            this.dataPOWER.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "POWER", true));
            this.dataPOWER.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPOWER.Location = new System.Drawing.Point(56, 177);
            this.dataPOWER.Name = "dataPOWER";
            this.dataPOWER.Size = new System.Drawing.Size(50, 37);
            this.dataPOWER.TabIndex = 12;
            this.dataPOWER.Text = "---";
            this.dataPOWER.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataENERGY
            // 
            this.dataENERGY.AutoSize = true;
            this.dataENERGY.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "ENERGY", true));
            this.dataENERGY.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataENERGY.Location = new System.Drawing.Point(200, 177);
            this.dataENERGY.Name = "dataENERGY";
            this.dataENERGY.Size = new System.Drawing.Size(61, 37);
            this.dataENERGY.TabIndex = 13;
            this.dataENERGY.Text = "----";
            this.dataENERGY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataPULSE
            // 
            this.dataPULSE.AutoSize = true;
            this.dataPULSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPULSE.Location = new System.Drawing.Point(360, 177);
            this.dataPULSE.Name = "dataPULSE";
            this.dataPULSE.Size = new System.Drawing.Size(39, 37);
            this.dataPULSE.TabIndex = 14;
            this.dataPULSE.Text = "P";
            this.dataPULSE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(39, 245);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // _chatLogBox
            // 
            this._chatLogBox.Location = new System.Drawing.Point(478, 12);
            this._chatLogBox.Multiline = true;
            this._chatLogBox.Name = "_chatLogBox";
            this._chatLogBox.ReadOnly = true;
            this._chatLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._chatLogBox.Size = new System.Drawing.Size(414, 291);
            this._chatLogBox.TabIndex = 16;
            // 
            // _textBox
            // 
            this._textBox.Location = new System.Drawing.Point(479, 310);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(330, 20);
            this._textBox.TabIndex = 17;
            this._textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBox_KeyPress);
            // 
            // _sendButton
            // 
            this._sendButton.Location = new System.Drawing.Point(815, 309);
            this._sendButton.Name = "_sendButton";
            this._sendButton.Size = new System.Drawing.Size(77, 21);
            this._sendButton.TabIndex = 18;
            this._sendButton.Text = "Send";
            this._sendButton.UseVisualStyleBackColor = true;
            this._sendButton.Click += new System.EventHandler(this._sendButton_Click);
            // 
            // measurementBindingSource
            // 
            this.measurementBindingSource.DataSource = typeof(Mallaca.Measurement);
            // 
            // RH_BIKE_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 347);
            this.Controls.Add(this._sendButton);
            this.Controls.Add(this._textBox);
            this.Controls.Add(this._chatLogBox);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dataPULSE);
            this.Controls.Add(this.dataENERGY);
            this.Controls.Add(this.dataPOWER);
            this.Controls.Add(this.dataPOWERPCT);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataTIME);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataDISTANCE);
            this.Controls.Add(this.dataSPEED);
            this.Controls.Add(this.dataRPM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RH_BIKE_GUI";
            this.Text = "Remote Healthcare - Client Edition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RH_BIKE_GUI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dataRPM;
        private System.Windows.Forms.Label dataSPEED;
        private System.Windows.Forms.Label dataDISTANCE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label dataTIME;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label dataPOWERPCT;
        private System.Windows.Forms.Label dataPOWER;
        private System.Windows.Forms.Label dataENERGY;
        private System.Windows.Forms.Label dataPULSE;
        private System.Windows.Forms.BindingSource measurementBindingSource;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox _chatLogBox;
        private System.Windows.Forms.TextBox _textBox;
        private System.Windows.Forms.Button _sendButton;
    }
}

