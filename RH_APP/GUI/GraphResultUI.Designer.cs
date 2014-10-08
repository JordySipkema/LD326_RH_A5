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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this._graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this._graph)).BeginInit();
            this.SuspendLayout();
            // 
            // _graph
            // 
            chartArea1.Name = "ChartArea1";
            this._graph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this._graph.Legends.Add(legend1);
            this._graph.Location = new System.Drawing.Point(150, 12);
            this._graph.Name = "_graph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "SPEED";
            this._graph.Series.Add(series1);
            this._graph.Size = new System.Drawing.Size(874, 505);
            this._graph.TabIndex = 0;
            // 
            // GraphResultUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 529);
            this.Controls.Add(this._graph);
            this.Name = "GraphResultUI";
            this.Text = "Results";
            ((System.ComponentModel.ISupportInitialize)(this._graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart _graph;
    }
}