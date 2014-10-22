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
            this._choiceBox1.ItemHeight = 16;
            this._choiceBox1.Location = new System.Drawing.Point(4, 46);
            this._choiceBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._choiceBox1.Name = "_choiceBox1";
            this._choiceBox1.Size = new System.Drawing.Size(159, 116);
            this._choiceBox1.TabIndex = 3;
            this._choiceBox1.SelectedIndexChanged += new System.EventHandler(this._choiceBox1_SelectedIndexChanged);
            // 
            // _choiceBox2
            // 
            this._choiceBox2.FormattingEnabled = true;
            this._choiceBox2.ItemHeight = 16;
            this._choiceBox2.Location = new System.Drawing.Point(11, 204);
            this._choiceBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._choiceBox2.Name = "_choiceBox2";
            this._choiceBox2.Size = new System.Drawing.Size(159, 116);
            this._choiceBox2.TabIndex = 4;
            this._choiceBox2.SelectedIndexChanged += new System.EventHandler(this._choiceBox2_SelectedIndexChanged);
            // 
            // _graph
            // 
            chartArea1.Name = "ChartArea1";
            this._graph.ChartAreas.Add(chartArea1);
            this._graph.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this._graph.Legends.Add(legend1);
            this._graph.Location = new System.Drawing.Point(204, 4);
            this._graph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._graph.Name = "_graph";
            this._graph.Size = new System.Drawing.Size(1300, 621);
            this._graph.TabIndex = 5;
            this._graph.Text = "RESULT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Value 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 166);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Value 2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._graph, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1363, 741);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._choiceBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._choiceBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 621);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._printButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 633);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 104);
            this.panel2.TabIndex = 1;
            // 
            // _printButton
            // 
            this._printButton.Location = new System.Drawing.Point(32, 22);
            this._printButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._printButton.Name = "_printButton";
            this._printButton.Size = new System.Drawing.Size(132, 57);
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
            this.panel3.Location = new System.Drawing.Point(204, 633);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1300, 104);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "Zoom in/out";
            // 
            // _scrollBar
            // 
            this._scrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._scrollBar.Location = new System.Drawing.Point(0, 48);
            this._scrollBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._scrollBar.Maximum = 100;
            this._scrollBar.Name = "_scrollBar";
            this._scrollBar.Size = new System.Drawing.Size(1300, 56);
            this._scrollBar.TabIndex = 2;
            this._scrollBar.Scroll += new System.EventHandler(this._scrollBar_Scroll);
            this._scrollBar.ValueChanged += new System.EventHandler(this._scrollBar_ValueChanged);
            // 
            // GraphResultUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 741);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GraphResultUI";
            this.Text = "Results";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphResultUI_FormClosed);
            this.Load += new System.EventHandler(this.GraphResultUI_Load);
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