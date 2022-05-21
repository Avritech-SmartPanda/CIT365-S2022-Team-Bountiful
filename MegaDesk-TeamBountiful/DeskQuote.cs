using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_TeamBountiful
{
    public class DeskQuote
    {
        //Desk, rush days, customer name, and quote date. This class will also hold the logic in determining the desk quote total.
        public string CustomerName { get; set; }
        public int RushDays { get; set; }
        public double QuoteTotal { get; set; }
        public Desk Desk { get; set; }
        public DateTime QuoteDate { get; set; }

        // Constructor of class
        public DeskQuote()
        {
            CustomerName = this.CustomerName;
            RushDays = this.RushDays;
            QuoteDate = this.QuoteDate;
            Desk = this.Desk;
            QuoteTotal = 0;
        }

        public double CalculateDeskQuoteTotal()
        {
            string[] rushOrderPriceList = getRushOrder();
            double QuoteTotal = 0;
            double DeskDrawersPrice = 0;
            double DeskBasePrice = 200;
            double DeskRushOrderPrice = 0;
            double DeskArea = Desk.Width * Desk.Depth;

            if (Desk.NumberOfDrawers > 0)
            {
                DeskDrawersPrice = Desk.NumberOfDrawers * 50;
            }
            if (DeskArea > 1000)
            {
                DeskBasePrice = 200 + DeskArea;
            }


            switch (RushDays)
            {
                case 3:
                    if (DeskArea < 1000)
                    {
                        DeskRushOrderPrice = Int32.Parse(rushOrderPriceList[0]);
                    }
                    if (DeskArea >= 1000 && DeskArea <= 2000)
                    {
                        DeskRushOrderPrice = Int32.Parse(rushOrderPriceList[1]);
                    }
                    if (DeskArea > 2000)
                    {
                        DeskRushOrderPrice = Int32.Parse(rushOrderPriceList[2]);
                    }
                    break;

                case 5:
                    if (DeskArea < 1000)
                    {
                        DeskRushOrderPrice = Int32.Parse(rushOrderPriceList[3]);
                    }
                    if (DeskArea >= 1000 && DeskArea <= 2000)
                    {
                        DeskRushOrderPrice = Int32.Parse(rushOrderPriceList[4]);
                    }
                    if (DeskArea > 2000)
                    {
                        DeskRushOrderPrice = Int32.Parse(rushOrderPriceList[5]);
                    }
                    break;

                case 7:
                    if (DeskArea < 1000)
                    {
                        DeskRushOrderPrice = Int32.Parse(rushOrderPriceList[6]);
                    }
                    if (DeskArea >= 1000 && DeskArea <= 2000)
                    {
                        DeskRushOrderPrice = Int32.Parse(rushOrderPriceList[7]);
                    }
                    if (DeskArea > 2000)
                    {
                        DeskRushOrderPrice = Int32.Parse(rushOrderPriceList[8]);
                    }
                    break;
                default:
                    DeskRushOrderPrice = 0;
                    break;
            }


            switch (Desk.SurfaceMaterial)
            {
                case Desk.Material.Laminate:
                    QuoteTotal = DeskBasePrice + DeskRushOrderPrice + DeskDrawersPrice + 100;
                    break;

                case Desk.Material.Oak:
                    QuoteTotal = DeskBasePrice + DeskRushOrderPrice + DeskDrawersPrice + 200;
                    break;

                case Desk.Material.Rosewood:
                    QuoteTotal = DeskBasePrice + DeskRushOrderPrice + DeskDrawersPrice + 300;
                    break;

                case Desk.Material.Veneer:
                    QuoteTotal = DeskBasePrice + DeskRushOrderPrice + DeskDrawersPrice + 125;
                    break;

                case Desk.Material.Pine:
                    QuoteTotal = DeskBasePrice + DeskRushOrderPrice + DeskDrawersPrice + 50;
                    break;

                default:
                    QuoteTotal = DeskBasePrice;
                    break;
            }
            return QuoteTotal;
        }


        public string[] getRushOrder()
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\Data\1 - BYUI\7 - CIT 365\Megadesk2.0\MegaDesk-TeamBountiful\TextFile1.txt");

            return text;
        }
    }
}
