using System;

namespace No2
{
    public class Broker
    { 
        public string Name { get; set; }

        public Broker(string name)
        {
            this.Name = name;
        }

        public void Update(object sender, EventArgs eventArgs)
        {
            StockInfoChangedEventArgs stockInfo = (StockInfoChangedEventArgs)eventArgs;

            Console.WriteLine(
                stockInfo.USD > 30
                    ? $"Broker {this.Name} sells dollars; Dollar rate: {stockInfo.USD}"
                    : $"Broker {this.Name} buys dollars; Dollar rate: {stockInfo.USD}");
        }
    }
}
