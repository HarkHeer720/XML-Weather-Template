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
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();

            Form1.conditionLabels[0] = image1;
            Form1.conditionLabels[1] = image2;
            Form1.conditionLabels[2] = image3;
            Form1.conditionLabels[3] = image4;

            displayForecast();
        }

        public void displayForecast()
        {
            date1.Text = Form1.days[1].date;
            double max = Math.Round(Convert.ToDouble(Form1.days[1].tempHigh));
            double min = Math.Round(Convert.ToDouble(Form1.days[1].tempLow));
            max1.Text = max.ToString("0°C");
            min1.Text = min.ToString("0°C");

            date2.Text = Form1.days[2].date;
            max = Math.Round(Convert.ToDouble(Form1.days[2].tempHigh));
            min = Math.Round(Convert.ToDouble(Form1.days[2].tempLow));
            max2.Text = max.ToString("0°C");
            min2.Text = min.ToString("0°C");

            date3.Text = Form1.days[3].date;
            max = Math.Round(Convert.ToDouble(Form1.days[3].tempHigh));
            min = Math.Round(Convert.ToDouble(Form1.days[3].tempLow));
            max3.Text = max.ToString("0°C");
            min3.Text = min.ToString("0°C");

            date4.Text = Form1.days[4].date;
            max = Math.Round(Convert.ToDouble(Form1.days[4].tempHigh));
            min = Math.Round(Convert.ToDouble(Form1.days[4].tempLow));
            max4.Text = max.ToString("0°C");
            min4.Text = min.ToString("0°C");

            for (int i = 0; i < 4; i++)
            {
                if (Convert.ToDouble(Form1.days[i].imgCondition) > 200 && Convert.ToDouble(Form1.days[i].imgCondition) < 300)
                {
                    Form1.conditionLabels[i].Image = Properties.Resources.thunderstorm;
                }
                else if (Convert.ToDouble(Form1.days[i].imgCondition) > 300 && Convert.ToDouble(Form1.days[i].imgCondition) < 600)
                {
                    Form1.conditionLabels[i].Image = Properties.Resources.rainy;
                }
                else if (Convert.ToDouble(Form1.days[i].imgCondition) > 600 && Convert.ToDouble(Form1.days[i].imgCondition) < 700)
                {
                    Form1.conditionLabels[i].Image = Properties.Resources.snow;
                }
                else if (Convert.ToDouble(Form1.days[i].imgCondition) == 800)
                {
                    Form1.conditionLabels[i].Image = Properties.Resources.sunny;
                }
                else if (Convert.ToDouble(Form1.days[i].imgCondition) > 800 && Convert.ToDouble(Form1.days[i].imgCondition) < 803)
                {
                    Form1.conditionLabels[i].Image = Properties.Resources.partiallyCloudy;
                }
                else if (Convert.ToDouble(Form1.days[i].imgCondition) > 802)
                {
                    Form1.conditionLabels[i].Image = Properties.Resources.cloudy;
                }
            }
        }
        
        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
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