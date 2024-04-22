using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLWeather
{
    public partial class SearchScreen : UserControl
    {
        public SearchScreen()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                cityOutput.Text = dateOutput.Text = currentOutput.Text = maxOutput.Text = minOutput.Text = humidityOutput.Text = imageLabel.Text = "";
                imageLabel.Image = null;

                string city = searchInput.Text;
                XmlReader reader = XmlReader.Create($"http://api.openweathermap.org/data/2.5/weather?q=+ {city} +&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

                reader.ReadToFollowing("city");
                Form1.days[0].location = reader.GetAttribute("name");

                reader.ReadToFollowing("temperature");
                Form1.days[0].currentTemp = reader.GetAttribute("value");
                Form1.days[0].tempLow = reader.GetAttribute("min");
                Form1.days[0].tempHigh = reader.GetAttribute("max");

                reader.ReadToFollowing("humidity");
                Form1.days[0].humidity = reader.GetAttribute("value");

                reader.ReadToFollowing("weather");
                Form1.days[0].imgCondition = reader.GetAttribute("number");

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

                Form1.days[0].date = DateTime.Now.AddDays(0).DayOfWeek.ToString();

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
            catch
            {
                cityOutput.Text = dateOutput.Text = currentOutput.Text = maxOutput.Text = minOutput.Text = humidityOutput.Text = imageLabel.Text = "";
                imageLabel.Image = null;
                imageLabel.Text = "Invalid input try again";
            }
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
