namespace RH_APP.GUI
{
    partial class GraphResultUI
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
            this._graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bothRadioButton = new System.Windows.Forms.RadioButton();
            this.realtimeRadioButton = new System.Windows.Forms.RadioButton();
            this.cycletimeRadiobutton = new System.Windows.Forms.RadioButton();
            this.pulseCheckBox = new System.Windows.Forms.CheckBox();
            this.energyCheckBox = new System.Windows.Forms.CheckBox();
            this.actualPowerCheckbox = new System.Windows.Forms.CheckBox();
            this.DistanceCheckBox = new System.Windows.Forms.CheckBox();
            this.speedCheckBox = new System.Windows.Forms.CheckBox();
            this.rmpCheckbox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._printButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this._scrollBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.showDatapointRadionbutton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this._graph)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scrollBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _graph
            // 
            this._graph.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this._graph.ChartAreas.Add(chartArea1);
            this._graph.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this._graph.Legends.Add(legend1);
            this._graph.Location = new System.Drawing.Point(153, 3);
            this._graph.Name = "_graph";
            this._graph.Size = new System.Drawing.Size(1052, 505);
            this._graph.TabIndex = 5;
            this._graph.Text = "RESULT";
            this._graph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graph_MouseMove);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._graph, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1208, 602);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._printButton);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pulseCheckBox);
            this.panel1.Controls.Add(this.energyCheckBox);
            this.panel1.Controls.Add(this.actualPowerCheckbox);
            this.panel1.Controls.Add(this.DistanceCheckBox);
            this.panel1.Controls.Add(this.speedCheckBox);
            this.panel1.Controls.Add(this.rmpCheckbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 505);
            this.panel1.TabIndex = 0;
            // 
            // bothRadioButton
            // 
            this.bothRadioButton.AutoSize = true;
            this.bothRadioButton.Location = new System.Drawing.Point(12, 66);
            this.bothRadioButton.Name = "bothRadioButton";
            this.bothRadioButton.Size = new System.Drawing.Size(47, 17);
            this.bothRadioButton.TabIndex = 8;
            this.bothRadioButton.Text = "Both";
            this.bothRadioButton.UseVisualStyleBackColor = true;
            this.bothRadioButton.CheckedChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // realtimeRadioButton
            // 
            this.realtimeRadioButton.AutoSize = true;
            this.realtimeRadioButton.Location = new System.Drawing.Point(12, 43);
            this.realtimeRadioButton.Name = "realtimeRadioButton";
            this.realtimeRadioButton.Size = new System.Drawing.Size(69, 17);
            this.realtimeRadioButton.TabIndex = 7;
            this.realtimeRadioButton.Text = "Real time";
            this.realtimeRadioButton.UseVisualStyleBackColor = true;
            this.realtimeRadioButton.CheckedChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // cycletimeRadiobutton
            // 
            this.cycletimeRadiobutton.AutoSize = true;
            this.cycletimeRadiobutton.Checked = true;
            this.cycletimeRadiobutton.Location = new System.Drawing.Point(12, 20);
            this.cycletimeRadiobutton.Name = "cycletimeRadiobutton";
            this.cycletimeRadiobutton.Size = new System.Drawing.Size(73, 17);
            this.cycletimeRadiobutton.TabIndex = 6;
            this.cycletimeRadiobutton.TabStop = true;
            this.cycletimeRadiobutton.Text = "Cycle time";
            this.cycletimeRadiobutton.UseVisualStyleBackColor = true;
            this.cycletimeRadiobutton.CheckedChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // pulseCheckBox
            // 
            this.pulseCheckBox.AutoSize = true;
            this.pulseCheckBox.Location = new System.Drawing.Point(10, 125);
            this.pulseCheckBox.Name = "pulseCheckBox";
            this.pulseCheckBox.Size = new System.Drawing.Size(78, 17);
            this.pulseCheckBox.TabIndex = 5;
            this.pulseCheckBox.Text = "Heart Rate";
            this.pulseCheckBox.UseVisualStyleBackColor = true;
            this.pulseCheckBox.CheckStateChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // energyCheckBox
            // 
            this.energyCheckBox.AutoSize = true;
            this.energyCheckBox.Location = new System.Drawing.Point(10, 102);
            this.energyCheckBox.Name = "energyCheckBox";
            this.energyCheckBox.Size = new System.Drawing.Size(59, 17);
            this.energyCheckBox.TabIndex = 4;
            this.energyCheckBox.Text = "Energy";
            this.energyCheckBox.UseVisualStyleBackColor = true;
            this.energyCheckBox.CheckStateChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // actualPowerCheckbox
            // 
            this.actualPowerCheckbox.AutoSize = true;
            this.actualPowerCheckbox.Location = new System.Drawing.Point(10, 79);
            this.actualPowerCheckbox.Name = "actualPowerCheckbox";
            this.actualPowerCheckbox.Size = new System.Drawing.Size(118, 17);
            this.actualPowerCheckbox.TabIndex = 3;
            this.actualPowerCheckbox.Text = "Actual brake power";
            this.actualPowerCheckbox.UseVisualStyleBackColor = true;
            this.actualPowerCheckbox.CheckStateChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // DistanceCheckBox
            // 
            this.DistanceCheckBox.AutoSize = true;
            this.DistanceCheckBox.Checked = true;
            this.DistanceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DistanceCheckBox.Location = new System.Drawing.Point(10, 56);
            this.DistanceCheckBox.Name = "DistanceCheckBox";
            this.DistanceCheckBox.Size = new System.Drawing.Size(68, 17);
            this.DistanceCheckBox.TabIndex = 2;
            this.DistanceCheckBox.Text = "Distance";
            this.DistanceCheckBox.UseVisualStyleBackColor = true;
            this.DistanceCheckBox.CheckStateChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // speedCheckBox
            // 
            this.speedCheckBox.AutoSize = true;
            this.speedCheckBox.Checked = true;
            this.speedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.speedCheckBox.Location = new System.Drawing.Point(10, 33);
            this.speedCheckBox.Name = "speedCheckBox";
            this.speedCheckBox.Size = new System.Drawing.Size(57, 17);
            this.speedCheckBox.TabIndex = 1;
            this.speedCheckBox.Text = "Speed";
            this.speedCheckBox.UseVisualStyleBackColor = true;
            this.speedCheckBox.CheckStateChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // rmpCheckbox
            // 
            this.rmpCheckbox.AutoSize = true;
            this.rmpCheckbox.Location = new System.Drawing.Point(10, 10);
            this.rmpCheckbox.Name = "rmpCheckbox";
            this.rmpCheckbox.Size = new System.Drawing.Size(123, 17);
            this.rmpCheckbox.TabIndex = 0;
            this.rmpCheckbox.Text = "Rotations per minute";
            this.rmpCheckbox.UseVisualStyleBackColor = true;
            this.rmpCheckbox.CheckStateChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 514);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 85);
            this.panel2.TabIndex = 1;
            // 
            // _printButton
            // 
            this._printButton.Location = new System.Drawing.Point(9, 478);
            this._printButton.Name = "_printButton";
            this._printButton.Size = new System.Drawing.Size(123, 24);
            this._printButton.TabIndex = 11;
            this._printButton.Text = "Print";
            this._printButton.UseVisualStyleBackColor = true;
            this._printButton.Click += new System.EventHandler(this._printButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this._scrollBar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(153, 514);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1052, 85);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Zoom in/out";
            // 
            // _scrollBar
            // 
            this._scrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._scrollBar.Location = new System.Drawing.Point(0, 40);
            this._scrollBar.Maximum = 100;
            this._scrollBar.Name = "_scrollBar";
            this._scrollBar.Size = new System.Drawing.Size(1052, 45);
            this._scrollBar.TabIndex = 2;
            this._scrollBar.Scroll += new System.EventHandler(this._scrollBar_Scroll);
            this._scrollBar.ValueChanged += new System.EventHandler(this._scrollBar_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bothRadioButton);
            this.groupBox1.Controls.Add(this.cycletimeRadiobutton);
            this.groupBox1.Controls.Add(this.realtimeRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(10, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time label";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.showDatapointRadionbutton);
            this.groupBox2.Location = new System.Drawing.Point(10, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 66);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data points";
            // 
            // showDatapointRadionbutton
            // 
            this.showDatapointRadionbutton.AutoSize = true;
            this.showDatapointRadionbutton.Location = new System.Drawing.Point(12, 19);
            this.showDatapointRadionbutton.Name = "showDatapointRadionbutton";
            this.showDatapointRadionbutton.Size = new System.Drawing.Size(52, 17);
            this.showDatapointRadionbutton.TabIndex = 0;
            this.showDatapointRadionbutton.Text = "Show";
            this.showDatapointRadionbutton.UseVisualStyleBackColor = true;
            this.showDatapointRadionbutton.CheckedChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 42);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Hide";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.CheckboxChanges);
            // 
            // GraphResultUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 602);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GraphResultUI";
            this.Text = "Results";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphResultUI_FormClosed);
            this.Load += new System.EventHandler(this.GraphResultUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this._graph)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scrollBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart _graph;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _printButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar _scrollBar;
        private System.Windows.Forms.CheckBox pulseCheckBox;
        private System.Windows.Forms.CheckBox energyCheckBox;
        private System.Windows.Forms.CheckBox actualPowerCheckbox;
        private System.Windows.Forms.CheckBox DistanceCheckBox;
        private System.Windows.Forms.CheckBox speedCheckBox;
        private System.Windows.Forms.CheckBox rmpCheckbox;
        private System.Windows.Forms.RadioButton bothRadioButton;
        private System.Windows.Forms.RadioButton realtimeRadioButton;
        private System.Windows.Forms.RadioButton cycletimeRadiobutton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton showDatapointRadionbutton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
