using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamFormsEfficientNetworking.Models
{
    public static class RandomOrdersHelper
    {
        private static DataService _dataService = new DataService();

        static RandomOrdersHelper()
        {
            InitRandomNumber(100000);
        }

        public static Task InsertOrdersAsync(int max)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < max; i++)
            {
                Order order = new Order
                {
                    OrderNumber = GenerateRandomNumber().ToString()
                };
                order.Items = new List<Item>
                    {
                        new Item { Code = GenerateRandomNumber().ToString(), OrderNumber = order.OrderNumber },
                        new Item { Code = GenerateRandomNumber().ToString(), OrderNumber = order.OrderNumber },
                        new Item { Code = GenerateRandomNumber().ToString(), OrderNumber = order.OrderNumber },
                        new Item { Code = GenerateRandomNumber().ToString(), OrderNumber = order.OrderNumber },
                        new Item { Code = GenerateRandomNumber().ToString(), OrderNumber = order.OrderNumber },
                        new Item { Code = GenerateRandomNumber().ToString(), OrderNumber = order.OrderNumber }
                    };
                tasks.Add(_dataService.InsertOrderAsync(order));
            }
            return Task.WhenAll(tasks);
        }

        private static Random random;
        private static object syncObj = new object();
        private static void InitRandomNumber(int seed)
        {
            random = new Random(seed);
        }
        private static int GenerateRandomNumber(int max = 100000)
        {
            lock (syncObj)
            {
                if (random == null)
                    random = new Random(); // Or exception...
                return random.Next(max);
            }
        }
    }
}
