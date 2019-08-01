using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.Collections.ObjectModel;

namespace GridIniOS
{
    public class OrderInfoRepository
    {
        ObservableCollection<OrderInfo> orderDetails;
        public OrderInfoRepository()
        {
            orderDetails = new ObservableCollection<OrderInfo>();
        }

        #region private variables

        private Random random = new Random();

        #endregion

        #region GetOrderDetails

        public ObservableCollection<OrderInfo> GetOrderDetails(int count)
        {
            for (int i = 10001; i <= count + 10000; i++)
            {
                var ord = new OrderInfo()
                {
                    OrderID = i,
                    CustomerID = CustomerID[random.Next(15)],
                    Freight = (Math.Round(random.Next(1000) + random.NextDouble())).ToString(),
                    Country = country[random.Next(15)]
                };
                orderDetails.Add(ord);
            }
            return orderDetails;
        }

        #endregion

        string[] CustomerID = new string[] {
            "Alfki",
            "Frans",
            "Merep",
            "Folko",
            "Simob",
            "Warth",
            "Vaffe",
            "Furib",
            "Seves",
            "Linod",
            "Riscu",
            "Picco",
            "Blonp",
            "Welli",
            "Folig"
        };

        string[] country = new string[]
        {
            "US",
            "Australia",
            "Canada",
            "UK",
            "India",
            "Italy",
            "China",
            "Japan",
            "Belgium",
            "Mexico",
            "Brazil",
            "Singapore",
            "North Korea",
            "Greece",
            "Norway",
            "Netherland",
            "Austria",
            "Sweden",
            "Poland",
            "Hungary",
            "Russia"
        };

    }
}