using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsqrbp_irfgyak7
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticks;
        List<Entities.PortfolioItem> Portfolio = new List<Entities.PortfolioItem>();
        
        public Form1()
        {
            InitializeComponent();

            Ticks = context.Ticks.ToList();
            dgvTicks.DataSource = Ticks;
            CreatePortfolio();

            List<decimal> Nyereségek = new List<decimal>();
            int intervallum = 30;
            DateTime kezdoDatum = (from x in Ticks select x.TradingDay).Min();
            DateTime zaroDatum = new DateTime(2016, 12, 30);
            TimeSpan z = zaroDatum - kezdoDatum;
            for (int i = 0; i < z.Days - intervallum; i++)
            {
                decimal ny = GetPortfolioValue(kezdoDatum.AddDays(i + intervallum))
                    - GetPortfolioValue(kezdoDatum.AddDays(i));
                Nyereségek.Add(ny);
                Console.WriteLine(i + " " + ny);
            }
            var nyeresegekRendezve = (from x in Nyereségek
                                      orderby x
                                      select x).ToList();
            MessageBox.Show(nyeresegekRendezve[nyeresegekRendezve.Count() / 5].ToString());
        }

        private void CreatePortfolio()
        {
            Portfolio.Add(new Entities.PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new Entities.PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new Entities.PortfolioItem() { Index = "ELMU", Volume = 10 });
            dgvPortfolio.DataSource = Portfolio;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in Ticks
                            where item.Index == x.Index.Trim()
                            && date <= x.TradingDay
                            select x).First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }
    }
}
