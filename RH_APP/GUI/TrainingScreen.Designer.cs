namespace RH_APP.GUI
{
    partial class TrainingScreen
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.startTrainingButton = new System.Windows.Forms.Button();
            this._graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataRPM = new System.Windows.Forms.Label();
            this.dataSPEED = new System.Windows.Forms.Label();
            this.dataDISTANCE = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataTIME = new System.Windows.Forms.Label();
            this.dataPOWERPCT = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataPOWER = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataENERGY = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataPULSE = new System.Windows.Forms.Label();
            this.setPowerLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this._chatLogBox = new System.Windows.Forms.TextBox();
            this._textBox = new System.Windows.Forms.TextBox();
            this._sendButton = new System.Windows.Forms.Button();
            this.broadcastCheckbox = new System.Windows.Forms.CheckBox();
            this._quitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.startTrainingButton, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this._graph, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataRPM, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataSPEED, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataDISTANCE, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataTIME, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataPOWERPCT, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataPOWER, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataENERGY, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataPULSE, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.setPowerLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this._chatLogBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this._textBox, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this._sendButton, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.broadcastCheckbox, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this._quitButton, 2, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 661);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // startTrainingButton
            // 
            this.startTrainingButton.Location = new System.Drawing.Point(154, 234);
            this.startTrainingButton.Name = "startTrainingButton";
            this.startTrainingButton.Size = new System.Drawing.Size(122, 27);
            this.startTrainingButton.TabIndex = 39;
            this.startTrainingButton.Text = "Start Training";
            this.startTrainingButton.UseVisualStyleBackColor = true;
            this.startTrainingButton.Click += new System.EventHandler(this.startTraining);
            // 
            // _graph
            // 
            chartArea1.Name = "ChartArea1";
            this._graph.ChartAreas.Add(chartArea1);
            this.tableLayoutPanel1.SetColumnSpan(this._graph, 5);
            this._graph.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this._graph.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            legend1.Name = "Legend1";
            this._graph.Legends.Add(legend1);
            this._graph.Location = new System.Drawing.Point(3, 333);
            this._graph.Name = "_graph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "SPEED";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "PULSE";
            this._graph.Series.Add(series1);
            this._graph.Series.Add(series2);
            this._graph.Size = new System.Drawing.Size(1002, 325);
            this._graph.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "RPM";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "SPEED";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "DISTANCE";
            // 
            // dataRPM
            // 
            this.dataRPM.AutoSize = true;
            this.dataRPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataRPM.Location = new System.Drawing.Point(3, 33);
            this.dataRPM.Name = "dataRPM";
            this.dataRPM.Size = new System.Drawing.Size(40, 29);
            this.dataRPM.TabIndex = 19;
            this.dataRPM.Text = "---";
            this.dataRPM.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataSPEED
            // 
            this.dataSPEED.AutoSize = true;
            this.dataSPEED.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSPEED.Location = new System.Drawing.Point(154, 33);
            this.dataSPEED.Name = "dataSPEED";
            this.dataSPEED.Size = new System.Drawing.Size(56, 29);
            this.dataSPEED.TabIndex = 20;
            this.dataSPEED.Text = "---.-";
            this.dataSPEED.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataDISTANCE
            // 
            this.dataDISTANCE.AutoSize = true;
            this.dataDISTANCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDISTANCE.Location = new System.Drawing.Point(305, 33);
            this.dataDISTANCE.Name = "dataDISTANCE";
            this.dataDISTANCE.Size = new System.Drawing.Size(56, 29);
            this.dataDISTANCE.TabIndex = 21;
            this.dataDISTANCE.Text = "--.--";
            this.dataDISTANCE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "TIME";
            // 
            // dataTIME
            // 
            this.dataTIME.AutoSize = true;
            this.dataTIME.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTIME.Location = new System.Drawing.Point(154, 99);
            this.dataTIME.Name = "dataTIME";
            this.dataTIME.Size = new System.Drawing.Size(63, 31);
            this.dataTIME.TabIndex = 23;
            this.dataTIME.Text = "--:--";
            this.dataTIME.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataPOWERPCT
            // 
            this.dataPOWERPCT.AutoSize = true;
            this.dataPOWERPCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPOWERPCT.Location = new System.Drawing.Point(3, 99);
            this.dataPOWERPCT.Name = "dataPOWERPCT";
            this.dataPOWERPCT.Size = new System.Drawing.Size(45, 29);
            this.dataPOWERPCT.TabIndex = 27;
            this.dataPOWERPCT.Text = "-%";
            this.dataPOWERPCT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "POWER";
            // 
            // dataPOWER
            // 
            this.dataPOWER.AutoSize = true;
            this.dataPOWER.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPOWER.Location = new System.Drawing.Point(3, 165);
            this.dataPOWER.Name = "dataPOWER";
            this.dataPOWER.Size = new System.Drawing.Size(40, 29);
            this.dataPOWER.TabIndex = 29;
            this.dataPOWER.Text = "---";
            this.dataPOWER.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(154, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "ENERGY";
            // 
            // dataENERGY
            // 
            this.dataENERGY.AutoSize = true;
            this.dataENERGY.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataENERGY.Location = new System.Drawing.Point(154, 165);
            this.dataENERGY.Name = "dataENERGY";
            this.dataENERGY.Size = new System.Drawing.Size(49, 29);
            this.dataENERGY.TabIndex = 31;
            this.dataENERGY.Text = "----";
            this.dataENERGY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(305, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "PULSE";
            // 
            // dataPULSE
            // 
            this.dataPULSE.AutoSize = true;
            this.dataPULSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPULSE.Location = new System.Drawing.Point(305, 165);
            this.dataPULSE.Name = "dataPULSE";
            this.dataPULSE.Size = new System.Drawing.Size(30, 29);
            this.dataPULSE.TabIndex = 33;
            this.dataPULSE.Text = "P";
            this.dataPULSE.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // setPowerLabel
            // 
            this.setPowerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.setPowerLabel.AutoSize = true;
            this.setPowerLabel.Location = new System.Drawing.Point(3, 208);
            this.setPowerLabel.Name = "setPowerLabel";
            this.setPowerLabel.Size = new System.Drawing.Size(72, 13);
            this.setPowerLabel.TabIndex = 36;
            this.setPowerLabel.Text = "SET POWER";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(3, 234);
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
            this.numericUpDown1.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown1.TabIndex = 37;
            this.numericUpDown1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown1.Click += new System.EventHandler(this.numericUpDown1_Click);
            // 
            // _chatLogBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._chatLogBox, 2);
            this._chatLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chatLogBox.Location = new System.Drawing.Point(456, 3);
            this._chatLogBox.Multiline = true;
            this._chatLogBox.Name = "_chatLogBox";
            this._chatLogBox.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this._chatLogBox, 8);
            this._chatLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._chatLogBox.Size = new System.Drawing.Size(549, 258);
            this._chatLogBox.TabIndex = 38;
            // 
            // _textBox
            // 
            this._textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBox.Location = new System.Drawing.Point(456, 267);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(397, 20);
            this._textBox.TabIndex = 39;
            // 
            // _sendButton
            // 
            this._sendButton.Location = new System.Drawing.Point(859, 267);
            this._sendButton.Name = "_sendButton";
            this._sendButton.Size = new System.Drawing.Size(77, 21);
            this._sendButton.TabIndex = 40;
            this._sendButton.Text = "Send";
            this._sendButton.UseVisualStyleBackColor = true;
            this._sendButton.Click += new System.EventHandler(this._sendButton_Click);
            // 
            // broadcastCheckbox
            // 
            this.broadcastCheckbox.AutoSize = true;
            this.broadcastCheckbox.Location = new System.Drawing.Point(859, 300);
            this.broadcastCheckbox.Name = "broadcastCheckbox";
            this.broadcastCheckbox.Size = new System.Drawing.Size(74, 17);
            this.broadcastCheckbox.TabIndex = 41;
            this.broadcastCheckbox.Text = "Broadcast";
            this.broadcastCheckbox.UseVisualStyleBackColor = true;
            // 
            // _quitButton
            // 
            this._quitButton.Location = new System.Drawing.Point(305, 234);
            this._quitButton.Name = "_quitButton";
            this._quitButton.Size = new System.Drawing.Size(122, 27);
            this._quitButton.TabIndex = 43;
            this._quitButton.Text = "Stop Training";
            this._quitButton.UseVisualStyleBackColor = true;
            this._quitButton.Click += new System.EventHandler(this._quitButton_Click);
            // 
            // TrainingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TrainingScreen";
            this.Text = "TrainingScreen";
            this.Load += new System.EventHandler(this.TrainingScreen_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dataRPM;
        private System.Windows.Forms.Label dataSPEED;
        private System.Windows.Forms.Label dataDISTANCE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label dataTIME;
        private System.Windows.Forms.Label dataPOWERPCT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label dataPOWER;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label dataENERGY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label dataPULSE;
        private System.Windows.Forms.Label setPowerLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox _chatLogBox;
        private System.Windows.Forms.TextBox _textBox;
        private System.Windows.Forms.Button _sendButton;
        private System.Windows.Forms.CheckBox broadcastCheckbox;
        private System.Windows.Forms.DataVisualization.Charting.Chart _graph;
        private System.Windows.Forms.Button startTrainingButton;
        private System.Windows.Forms.Button _quitButton;
    }
}