using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mallaca;

namespace RH_APP.GUI
{
    public partial class GraphResultUI : Form
    {
        private List<Measurement> result = new List<Measurement>();

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

            foreach (Choice choiceValue in values)
            {
                _choiceBox1.Items.Add(choiceValue);
                _choiceBox2.Items.Add(choiceValue);
            }

            _choiceBox1.SetSelected(1, true);
            _choiceBox2.SetSelected(2, true);

            updateGraph();
        }

        public void updateGraph()
        {


            //_graph.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //_graph.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            _graph.ChartAreas[0].CursorX.AutoScroll = true;
        //    _graph.ChartAreas[0].CursorY.AutoScroll = true;

            _graph.Series.Clear();



            switch (_choice1)
            {
                case Choice.RPM:
                    var choice1 = _graph.Series.Add("RPM");
                    choice1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[0].Points.AddXY(m.TIME, m.RPM);
                    }
                    break;
                case Choice.SPEED:
                    var choice2 = _graph.Series.Add("SPEED");
                    choice2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[0].Points.AddXY(m.TIME, m.SPEED / 10.0);
                    }
                    break;
                case Choice.DISTANCE:
                    var choice3 = _graph.Series.Add("DISTANCE");
                    choice3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[0].Points.AddXY(m.TIME, m.DISTANCE);
                    }
                    break;
                case Choice.ACT_POWER:
                    var choice4 = _graph.Series.Add("ACT_POWER");
                    choice4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[0].Points.AddXY(m.TIME, m.ACT_POWER);
                    }
                    break;
                case Choice.ENERGY:
                    var choice5 = _graph.Series.Add("ENERGY");
                    choice5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[0].Points.AddXY(m.TIME, m.ENERGY);
                    }
                    break;
                case Choice.PULSE:
                    var choice6 = _graph.Series.Add("PULSE");
                    choice6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[0].Points.AddXY(m.TIME, m.PULSE);
                    }
                    break;
            }

            switch (_choice2)
            {
                case Choice.RPM:
                    var choice1 = _graph.Series.Add("RPM");
                    choice1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[1].Points.AddXY(m.TIME, m.RPM);
                    }
                    break;
                case Choice.SPEED:
                    var choice2 = _graph.Series.Add("SPEED");
                    choice2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[1].Points.AddXY(m.TIME, m.SPEED / 10.0);
                    }
                    break;
                case Choice.DISTANCE:
                    var choice3 = _graph.Series.Add("DISTANCE");
                    choice3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[1].Points.AddXY(m.TIME, m.DISTANCE);
                    }
                    break;
                case Choice.ACT_POWER:
                    var choice4 = _graph.Series.Add("ACT_POWER");
                    choice4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[1].Points.AddXY(m.TIME, m.ACT_POWER);
                    }
                    break;
                case Choice.ENERGY:
                    var choice5 = _graph.Series.Add("ENERGY");
                    choice5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[1].Points.AddXY(m.TIME, m.ENERGY);
                    }
                    break;
                case Choice.PULSE:
                    var choice6 = _graph.Series.Add("PULSE");
                    choice6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    foreach (Measurement m in result)
                    {
                        _graph.Series[1].Points.AddXY(m.TIME, m.PULSE);
                    }
                    break;
            }

            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
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

        private void _choiceBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_choiceBox1.SelectedItem == null)
                return;
            _choice1 = (Choice)_choiceBox1.SelectedItem;
            if (checkIfSame())
                return;
            updateGraph();
        }

        private void _choiceBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _choice2 = (Choice)_choiceBox2.SelectedItem;
            if (checkIfSame())
                return;
            updateGraph();
        }

        private bool checkIfSame()
        {
            if (_choice1 == _choice2)
            {
                MessageBox.Show("Cannot select the same values!");
                _choiceBox1.SetSelected((int)_choice1 - 1, false);
                Choice newChoice = _choice1 == Choice.SPEED ? Choice.RPM : Choice.SPEED;
                int index = (int)newChoice;
                _choiceBox1.SetSelected(index - 1, true);
                return true;
            }
            return false;
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = dialog = MessageBox.Show("Are you sure you want to quit?", "Alert", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void _printButton_Click(object sender, EventArgs e)
        {
            _graph.Printing.Print(true);
        }
    }
}
