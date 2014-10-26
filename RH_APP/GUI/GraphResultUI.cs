using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Mallaca;

namespace RH_APP.GUI
{
    public partial class GraphResultUI : Form
    {
        private List<Measurement> result = new List<Measurement>();
        private bool finishedinit = false;
        enum Choice 
        { 
            RPM = 1, 
            SPEED = 2, 
            DISTANCE = 3, 
            ACT_POWER = 4,
            ENERGY = 5,
            PULSE = 6 
        };

        private Choice _choice1;
        private Choice _choice2;


        public GraphResultUI(List<Measurement> origin)
        {
            InitializeComponent();
            result = origin;
            Array values = typeof(Choice).GetEnumValues();
            CheckboxChanges(this, EventArgs.Empty);

            CheckboxChanges(this, EventArgs.Empty);
        }

        public void CheckboxChanges(Object sender, EventArgs e)
        {
            _graph.ChartAreas[0].CursorX.AutoScroll = true;
            _graph.Series.Clear();
            _graph.DataSource = result;

            //if (actualPowerCheckbox.Checked)
            //    configureGraphDataNEW(Choice.ACT_POWER, Color.DarkBlue);
            //if (DistanceCheckBox.Checked)
            //    configureGraphDataNEW(Choice.DISTANCE, Color.DarkRed);
            //if (energyCheckBox.Checked)
            //    configureGraphDataNEW(Choice.ENERGY, Color.LimeGreen);
            //if (pulseCheckBox.Checked)
            //    configureGraphDataNEW(Choice.PULSE, Color.OrangeRed);
            //if (rmpCheckbox.Checked)
            //    configureGraphDataNEW(Choice.RPM, Color.RoyalBlue);
            //if (speedCheckBox.Checked)
            //    configureGraphDataNEW(Choice.SPEED, Color.DarkViolet);


            if (actualPowerCheckbox.Checked)
                configureGraphData(Choice.ACT_POWER, Color.DarkBlue, 2);
            if (DistanceCheckBox.Checked)
                configureGraphData(Choice.DISTANCE, Color.DarkRed, 2);
            if (energyCheckBox.Checked)
                configureGraphData(Choice.ENERGY, Color.LimeGreen, 2);
            if (pulseCheckBox.Checked)
                configureGraphData(Choice.PULSE, Color.OrangeRed, 2);
            if (rmpCheckbox.Checked)
                configureGraphData(Choice.RPM, Color.RoyalBlue, 2);
            if (speedCheckBox.Checked)
                configureGraphData(Choice.SPEED, Color.DarkViolet, 2);

            foreach (Series ser in _graph.Series)
            {
                ser.IsValueShownAsLabel = showDatapointRadionbutton.Checked;
                ser.MarkerStyle = showDatapointRadionbutton.Checked ? MarkerStyle.Square : MarkerStyle.None;
                ser.BorderWidth = 1;
            }
            
        }

        private void configureGraphDataNEW(Choice choice, Color c)
        {
            Series seriesLines;
            

            switch (choice)
            {
                case Choice.RPM:
                    seriesLines = _graph.Series.Add("RPM");
                    seriesLines.YValueMembers = "RPM";
                    break;
                case Choice.SPEED:
                    seriesLines = _graph.Series.Add("SPEED");
                    seriesLines.YValueMembers = "SPEED";
                    break;
                case Choice.DISTANCE:
                    seriesLines = _graph.Series.Add("DISTANCE");
                    seriesLines.YValueMembers = "DISTANCE";
                    break;
                case Choice.ACT_POWER:
                    seriesLines = _graph.Series.Add("ACT_POWER");
                    seriesLines.YValueMembers = "ACT_POWER";
                    break;
                case Choice.ENERGY:
                    seriesLines = _graph.Series.Add("ENERGY");
                    seriesLines.YValueMembers = "ENERGY";
                    break;
                case Choice.PULSE:
                    seriesLines = _graph.Series.Add("PULSE");
                    seriesLines.YValueMembers = "PULSE";
                    break;
                default:
                    seriesLines = _graph.Series.Add("Unknown");
                    seriesLines.YValueMembers = "DATE";
                    break;
            }
            
            seriesLines.XValueMember = "DATE";
            
            seriesLines.IsValueShownAsLabel = true;
            int i = _graph.ChartAreas.Count - 1;
            _graph.ChartAreas[i].AxisX.LabelStyle.Format = "HH:mm:ss";
            _graph.ChartAreas[i].AxisX.IsMarginVisible = true;
            //_graph.ChartAreas[i].AxisX.LabelStyle.Interval = 1;

            seriesLines.XValueType = ChartValueType.Time;
            
            seriesLines.Color = c;
            seriesLines.ChartType = SeriesChartType.Line;
        }



        private void configureGraphData(Choice _choice2, Color c, int width)
        {

            Series choice;
            object obj;

            switch (_choice2)
            {
                case Choice.RPM:
                    choice = _graph.Series.Add("RPM");
                    break;
                case Choice.SPEED:
                    choice = _graph.Series.Add("SPEED");
                    break;
                case Choice.DISTANCE:
                    choice = _graph.Series.Add("DISTANCE");
                    break;
                case Choice.ACT_POWER:
                    choice = _graph.Series.Add("ACT_POWER");
                    break;
                case Choice.ENERGY:
                    choice = _graph.Series.Add("ENERGY");
                    break;
                case Choice.PULSE:
                    choice = _graph.Series.Add("PULSE");
                    break;
                default:
                    choice = _graph.Series.Add("Unknown");
                    break;
            }

            int series = _graph.Series.Count - 1;
            choice.ChartType = SeriesChartType.Line;
            _graph.Series[series].Color = c;
            _graph.Series[series].BorderWidth = width;

            foreach (Measurement m in result)
            {
                switch (_choice2)
                {
                    case Choice.RPM:
                        obj = m.RPM;
                        break;
                    case Choice.SPEED:
                        obj = m.SPEED / 10.0;
                        break;
                    case Choice.DISTANCE:
                        obj = m.DISTANCE;
                        break;
                    case Choice.ACT_POWER:
                        obj = m.ACT_POWER;
                        break;
                    case Choice.ENERGY:
                        obj = m.ENERGY;
                        break;
                    case Choice.PULSE:
                        obj = m.PULSE;
                        break;
                    default:
                        obj = 0;
                        break;
                }

                string time;

                if (cycletimeRadiobutton.Checked)
                    time = m.TIME;
                else if (realtimeRadioButton.Checked)
                    time = m.DATE.ToLongTimeString();
                else
                    time = m.currentAndCycleTime;
                
                
                _graph.Series[series].Points.AddXY(time, obj);

            }
        }

        private void _scrollBar_Scroll(object sender, EventArgs e)
        {
            int scale = _scrollBar.Maximum - _scrollBar.Value;
            _graph.ChartAreas[0].AxisX.ScaleView.Size = scale;
        }

        private void _scrollBar_ValueChanged(object sender, EventArgs e)
        {
            _graph.ChartAreas[0].AxisX.ScaleView.Position = _scrollBar.Value;
        }


        private void _printButton_Click(object sender, EventArgs e)
        {
            _graph.Printing.Print(true);
        }

        private void GraphResultUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult dialog = dialog = MessageBox.Show("Are you sure you want to close the results?", "Alert", MessageBoxButtons.YesNo);
            //if (dialog == DialogResult.Yes)
            //{
            //    this.Dispose();
            //}
        }

        private void GraphResultUI_Load(object sender, EventArgs e)
        {

        }

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        void graph_MouseMove(object sender, MouseEventArgs e)
        {
            //var pos = e.Location;
            //if (prevPosition.HasValue && pos == prevPosition.Value)
            //    return;
            //tooltip.RemoveAll();
            //prevPosition = pos;
            //var results = _graph.HitTest(pos.X, pos.Y, false,
            //                                ChartElementType.DataPoint);
            //foreach (var result in results)
            //{
            //    if (result.ChartElementType == ChartElementType.DataPoint)
            //    {
            //        var prop = result.Object as DataPoint;
            //        if (prop != null)
            //        {
            //            var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
            //            var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
            //            Console.WriteLine("Now at " + pointXPixel + ":" + pointYPixel + ".");
            //            // check if the cursor is really close to the point (2 pixels around the point)
            //            //if (Math.Abs(pos.X - pointXPixel) < 2 &&
            //            //    Math.Abs(pos.Y - pointYPixel) < 2)
            //            //{
            //            //    Console.WriteLine("Found a position. Creating tooltip.");
            //            //    tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this._graph,
            //            //                    pos.X, pos.Y - 15);
            //            //}
            //            //else
            //            //{
            //                tooltip.Show(" Y=" + prop.YValues[0], this._graph,
            //                pos.X, pos.Y - 15);
            //            //}
            //        }
            //    }
            //}
        }
    }
}
