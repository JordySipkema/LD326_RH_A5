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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this._scrollBar = new System.Windows.Forms.TrackBar();
            this._choiceBox1 = new System.Windows.Forms.ListBox();
            this._choiceBox2 = new System.Windows.Forms.ListBox();
            this._graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._printButton = new System.Windows.Forms.Button();
            this._closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._scrollBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._graph)).BeginInit();
            this.SuspendLayout();
            // 
            // _scrollBar
            // 
            this._scrollBar.Location = new System.Drawing.Point(150, 472);
            this._scrollBar.Name = "_scrollBar";
            this._scrollBar.Size = new System.Drawing.Size(874, 45);
            this._scrollBar.TabIndex = 2;
            this._scrollBar.Scroll += new System.EventHandler(this._scrollBar_Scroll);
            this._scrollBar.ValueChanged += new System.EventHandler(this._scrollBar_ValueChanged);
            // 
            // _choiceBox1
            // 
            this._choiceBox1.FormattingEnabled = true;
            this._choiceBox1.Location = new System.Drawing.Point(24, 41);
            this._choiceBox1.Name = "_choiceBox1";
            this._choiceBox1.Size = new System.Drawing.Size(120, 95);
            this._choiceBox1.TabIndex = 3;
            this._choiceBox1.SelectedIndexChanged += new System.EventHandler(this._choiceBox1_SelectedIndexChanged);
            // 
            // _choiceBox2
            // 
            this._choiceBox2.FormattingEnabled = true;
            this._choiceBox2.Location = new System.Drawing.Point(24, 210);
            this._choiceBox2.Name = "_choiceBox2";
            this._choiceBox2.Size = new System.Drawing.Size(120, 95);
            this._choiceBox2.TabIndex = 4;
            this._choiceBox2.SelectedIndexChanged += new System.EventHandler(this._choiceBox2_SelectedIndexChanged);
            // 
            // _graph
            // 
            chartArea2.Name = "ChartArea1";
            this._graph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this._graph.Legends.Add(legend2);
            this._graph.Location = new System.Drawing.Point(160, 12);
            this._graph.Name = "_graph";
            this._graph.Size = new System.Drawing.Size(851, 433);
            this._graph.TabIndex = 5;
            this._graph.Text = "RESULT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Value 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Value 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Zoom in/out";
            // 
            // _printButton
            // 
            this._printButton.Location = new System.Drawing.Point(24, 342);
            this._printButton.Name = "_printButton";
            this._printButton.Size = new System.Drawing.Size(120, 38);
            this._printButton.TabIndex = 11;
            this._printButton.Text = "Print";
            this._printButton.UseVisualStyleBackColor = true;
            this._printButton.Click += new System.EventHandler(this._printButton_Click);
            // 
            // _closeButton
            // 
            this._closeButton.Location = new System.Drawing.Point(24, 396);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(120, 38);
            this._closeButton.TabIndex = 12;
            this._closeButton.Text = "Close";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
            // 
            // GraphResultUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 529);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._printButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._graph);
            this.Controls.Add(this._choiceBox2);
            this.Controls.Add(this._choiceBox1);
            this.Controls.Add(this._scrollBar);
            this.Name = "GraphResultUI";
            this.Text = "Results";
            ((System.ComponentModel.ISupportInitialize)(this._scrollBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar _scrollBar;
        private System.Windows.Forms.ListBox _choiceBox1;
        private System.Windows.Forms.ListBox _choiceBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart _graph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _printButton;
        private System.Windows.Forms.Button _closeButton;
    }
}