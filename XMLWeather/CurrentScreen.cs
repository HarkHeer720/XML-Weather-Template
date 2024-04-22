using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            if (Convert.ToDouble(Form1.days[0].imgCondition) > 200 && Convert.ToDouble(Form1.days[0].imgCondition) < 300)
            {
                imageLabel.Image = Properties.Resources.thunderstorm;
                this.BackColor = Color.DarkGray;
            }
            else if (Convert.ToDouble(Form1.days[0].imgCondition) > 300 && Convert.ToDouble(Form1.days[0].imgCondition) < 600)
            {
                imageLabel.Image = Properties.Resources.rainy;
                this.BackColor = Color.Gray;
            }
            else if (Convert.ToDouble(Form1.days[0].imgCondition) > 600 && Convert.ToDouble(Form1.days[0].imgCondition) < 700)
            {
                imageLabel.Image = Properties.Resources.snow;
                this.BackColor = Color.White;
            }
            else if (Convert.ToDouble(Form1.days[0].imgCondition) == 800)
            {
                imageLabel.Image = Properties.Resources.sunny;
                this.BackColor = Color.Goldenrod;
            }
            else if (Convert.ToDouble(Form1.days[0].imgCondition) > 800 && Convert.ToDouble(Form1.days[0].imgCondition) < 803)
            {
                imageLabel.Image = Properties.Resources.partiallyCloudy;
                this.BackColor = Color.LightGray;
            }
            else if (Convert.ToDouble(Form1.days[0].imgCondition) > 802)
            {
                imageLabel.Image = Properties.Resources.cloudy;
                this.BackColor = Color.LightGray;
            }

            cityOutput.Text = Form1.days[0].location;
            dateOutput.Text = Form1.days[0].date;
            double current = Math.Round(Convert.ToDouble(Form1.days[0].currentTemp));
            double max = Math.Round(Convert.ToDouble(Form1.days[0].tempHigh));
            double min = Math.Round(Convert.ToDouble(Form1.days[0].tempLow));
            currentOutput.Text = current.ToString("0°C");
            maxOutput.Text = max.ToString("0°C");
            minOutput.Text = min.ToString("0°C");
            humidityOutput.Text = Form1.days[0].humidity + "%";
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void searchLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            SearchScreen ss = new SearchScreen();
            f.Controls.Add(ss);
        }
    }
}