using gsqrbp_irfgyak5.MnbServiceReference;
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
using System.Xml;

namespace gsqrbp_irfgyak5
{
    public partial class Form1 : Form
    {
        BindingList<Entities.RateData> Rates = new BindingList<Entities.RateData>();
        
        public Form1()
        {
            InitializeComponent();

            dgvRates.DataSource = Rates.ToList();
            XmlDocument(ExchangeRates());
            Chart();
        }

        private string ExchangeRates()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            return result;
            //richTextBox1.Text = result;
        }

        private void XmlDocument(string result)
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);
            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new Entities.RateData();
                Rates.Add(rate);
                rate.Date = DateTime.Parse(element.GetAttribute("date"));
                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }

        private void Chart()
        {
            chartRateData.DataSource = Rates;
            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;
            var legend = chartRateData.Legends[0];
            legend.Enabled = false;
            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void RefreshData()
        {
            //Rates.Clear();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RefreshData();
        }
    }
}
