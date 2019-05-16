using System;
using System.Collections.Generic;

namespace No2
{
    public class Stock 
    {
        public int USDValue { get; private set; }
        public int Euro { get; private set; }

        public event EventHandler<StockInfoChangedEventArgs> StockInfoChanged;

        public void OnStockInfoChanged()
        {
            this.StockInfoChanged?.Invoke(this, new StockInfoChangedEventArgs() { USD = this.Euro, Euro = this.Euro });
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
