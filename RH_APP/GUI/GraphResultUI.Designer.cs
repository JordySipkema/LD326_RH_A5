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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this._choiceBox1 = new System.Windows.Forms.ListBox();
            this._choiceBox2 = new System.Windows.Forms.ListBox();
            this._graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._printButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this._scrollBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this._graph)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scrollBar)).BeginInit();
            this.SuspendLayout();
            // 
            // _choiceBox1
            // 
            this._choiceBox1.FormattingEnabled = true;
            this._choiceBox1.Location = new System.Drawing.Point(3, 37);
            this._choiceBox1.Name = "_choiceBox1";
            this._choiceBox1.Size = new System.Drawing.Size(120, 95);
            this._choiceBox1.TabIndex = 3;
            this._choiceBox1.SelectedIndexChanged += new System.EventHandler(this._choiceBox1_SelectedIndexChanged);
            // 
            // _choiceBox2
            // 
            this._choiceBox2.FormattingEnabled = true;
            this._choiceBox2.Location = new System.Drawing.Point(8, 166);
            this._choiceBox2.Name = "_choiceBox2";
            this._choiceBox2.Size = new System.Drawing.Size(120, 95);
            this._choiceBox2.TabIndex = 4;
            this._choiceBox2.SelectedIndexChanged += new System.EventHandler(this._choiceBox2_SelectedIndexChanged);
            // 
            // _graph
            // 
            chartArea3.Name = "ChartArea1";
            this._graph.ChartAreas.Add(chartArea3);
            this._graph.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this._graph.Legends.Add(legend3);
            this._graph.Location = new System.Drawing.Point(153, 3);
            this._graph.Name = "_graph";
            this._graph.Size = new System.Drawing.Size(975, 505);
            this._graph.TabIndex = 5;
            this._graph.Text = "RESULT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Value 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Value 2";
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1022, 602);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._choiceBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._choiceBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 505);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._printButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 514);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(144, 85);
            this.panel2.TabIndex = 1;
            // 
            // _printButton
            // 
            this._printButton.Location = new System.Drawing.Point(24, 18);
            this._printButton.Name = "_printButton";
            this._printButton.Size = new System.Drawing.Size(99, 46);
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
            this.panel3.Size = new System.Drawing.Size(975, 85);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 18);
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
            this._scrollBar.Size = new System.Drawing.Size(975, 45);
            this._scrollBar.TabIndex = 2;
            this._scrollBar.Scroll += new System.EventHandler(this._scrollBar_Scroll);
            this._scrollBar.ValueChanged += new System.EventHandler(this._scrollBar_ValueChanged);
            // 
            // GraphResultUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 602);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GraphResultUI";
            this.Text = "Results";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphResultUI_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this._graph)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scrollBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _choiceBox1;
        private System.Windows.Forms.ListBox _choiceBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart _graph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _printButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar _scrollBar;
    }
}