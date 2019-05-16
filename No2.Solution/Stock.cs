using System;
using System.Collections.Generic;

namespace No2
{
    public class Stock 
    {
        public event EventHandler<StockInfoChangedEventArgs> StockInfoChanged;

        private int USDValue;
        private int Euro;

        public void OnStockInfoChanged()
        {
            StockInfoChanged?.Invoke(this, new StockInfoChangedEventArgs() { USD = this.Euro, Euro = this.Euro });
        }

        public void Market()
        {
            Random rnd = new Random();
            int newUSD = rnd.Next(20, 40);
            int newEuro = rnd.Next(30, 50);
            if (newUSD != this.USDValue || newEuro != this.Euro)
            {
                this.USDValue = newUSD;
                this.Euro = newEuro;
                OnStockInfoChanged();
            }
        }
    }
}
