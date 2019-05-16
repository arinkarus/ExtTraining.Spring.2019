﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No2.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var stock = new Stock();

            var bank = new Bank("Bank");
            var broker = new Broker("Broker");

            stock.StockInfoChanged += bank.Update;
            stock.StockInfoChanged += broker.Update;

            stock.Market();

            stock.StockInfoChanged -= bank.Update;

            stock.Market();
      
            stock.StockInfoChanged -= broker.Update;
            stock.Market();

            System.Console.ReadLine();
        }
    }
}
