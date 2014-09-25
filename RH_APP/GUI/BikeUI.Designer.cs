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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataRPM = new System.Windows.Forms.Label();
            this.measurementBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.measurementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "RPM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "SPEED";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "DISTANCE";
            // 
            // dataRPM
            // 
            this.dataRPM.AutoSize = true;
            this.dataRPM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "RPM", true));
            this.dataRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataRPM.Location = new System.Drawing.Point(75, 58);
            this.dataRPM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataRPM.Name = "dataRPM";
            this.dataRPM.Size = new System.Drawing.Size(62, 46);
            this.dataRPM.TabIndex = 3;
            this.dataRPM.Text = "---";
            this.dataRPM.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // measurementBindingSource
            // 
            this.measurementBindingSource.DataSource = typeof(Mallaca.Measurement);
            // 
            // dataSPEED
            // 
            this.dataSPEED.AutoSize = true;
            this.dataSPEED.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "SPEED", true));
            this.dataSPEED.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSPEED.Location = new System.Drawing.Point(259, 58);
            this.dataSPEED.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataSPEED.Name = "dataSPEED";
            this.dataSPEED.Size = new System.Drawing.Size(88, 46);
            this.dataSPEED.TabIndex = 4;
            this.dataSPEED.Text = "---.-";
            this.dataSPEED.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataDISTANCE
            // 
            this.dataDISTANCE.AutoSize = true;
            this.dataDISTANCE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "DISTANCE", true));
            this.dataDISTANCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDISTANCE.Location = new System.Drawing.Point(419, 58);
            this.dataDISTANCE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataDISTANCE.Name = "dataDISTANCE";
            this.dataDISTANCE.Size = new System.Drawing.Size(88, 46);
            this.dataDISTANCE.TabIndex = 5;
            this.dataDISTANCE.Text = "--.--";
            this.dataDISTANCE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 119);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "TIME";
            // 
            // dataTIME
            // 
            this.dataTIME.AutoSize = true;
            this.dataTIME.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "TIME", true));
            this.dataTIME.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTIME.Location = new System.Drawing.Point(223, 135);
            this.dataTIME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataTIME.Name = "dataTIME";
            this.dataTIME.Size = new System.Drawing.Size(132, 69);
            this.dataTIME.TabIndex = 7;
            this.dataTIME.Text = "--:--";
            this.dataTIME.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 202);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "POWER";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(231, 202);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "ENERGY";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(423, 202);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "PULSE";
            // 
            // dataPOWERPCT
            // 
            this.dataPOWERPCT.AutoSize = true;
            this.dataPOWERPCT.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "POWERPCT", true));
            this.dataPOWERPCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPOWERPCT.Location = new System.Drawing.Point(76, 171);
            this.dataPOWERPCT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataPOWERPCT.Name = "dataPOWERPCT";
            this.dataPOWERPCT.Size = new System.Drawing.Size(54, 36);
            this.dataPOWERPCT.TabIndex = 11;
            this.dataPOWERPCT.Text = "-%";
            this.dataPOWERPCT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataPOWER
            // 
            this.dataPOWER.AutoSize = true;
            this.dataPOWER.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "POWER", true));
            this.dataPOWER.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPOWER.Location = new System.Drawing.Point(75, 218);
            this.dataPOWER.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataPOWER.Name = "dataPOWER";
            this.dataPOWER.Size = new System.Drawing.Size(62, 46);
            this.dataPOWER.TabIndex = 12;
            this.dataPOWER.Text = "---";
            this.dataPOWER.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataENERGY
            // 
            this.dataENERGY.AutoSize = true;
            this.dataENERGY.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.measurementBindingSource, "ENERGY", true));
            this.dataENERGY.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataENERGY.Location = new System.Drawing.Point(267, 218);
            this.dataENERGY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataENERGY.Name = "dataENERGY";
            this.dataENERGY.Size = new System.Drawing.Size(76, 46);
            this.dataENERGY.TabIndex = 13;
            this.dataENERGY.Text = "----";
            this.dataENERGY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataPULSE
            // 
            this.dataPULSE.AutoSize = true;
            this.dataPULSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPULSE.Location = new System.Drawing.Point(480, 218);
            this.dataPULSE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dataPULSE.Name = "dataPULSE";
            this.dataPULSE.Size = new System.Drawing.Size(48, 46);
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
            this.numericUpDown1.Location = new System.Drawing.Point(52, 302);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // RH_BIKE_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 379);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RH_BIKE_GUI";
            this.Text = "Remote Healthcare - Bike Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RH_BIKE_GUI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.measurementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
    }
}

