using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{

    class Order
    {

        public string Number;
        public DateTime Date { get; }
        public string Description;
        private static int orderNumber = 000000000;
        public decimal summPrice { 
            get 
            { 
                decimal summPrice = 0;
                foreach (var item in productList)
                {
                    summPrice += item.Price;
                }
                return summPrice;
            } 
        }

        public Order(DateTime date)
        {
            Date = date;
            Number = orderNumber.ToString();
            orderNumber++;
        }
        private List<Product> productList = new List<Product>();
        public void AddProduct(string name, decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Цена не должна быть меньше 0");
            }
            var product = new Product(name, price);
            productList.Add(product);
        }
        public void AddProduct(string name)
        {
            var product = new Product(name);
            productList.Add(product);
        }
        public string GetAllProducts()
        {
            var report = new StringBuilder();
            report.AppendLine("Название товара\t\tЦена");
            
            foreach (var product in productList) { 
                report.AppendLine($"{product.Name}\t\t\t{product.Price}");
            }
            return report.ToString();
        }

        public void SetPaymentMethod(int method)
        {
            if (method == 1)
            {
                CashPay payment = new CashPay();
                payment.Method();
            }
            else if (method == 2)
            {
                CardPay payment = new CardPay();
                payment.Method();
            }
        }

        private void DeliveryStatus(Courier courier, Client client)
        {
            courier.GetProduct(productList);
            courier.GiveProduct(productList);
            client.GetProduct(productList);
            client.GiveMoney();
            courier.GetMoney();
        }
        public void SetDelivery(Courier courier, Client client)
        {
            Console.WriteLine("\nКакой выберите вариант доставки? \n1 - доставка курьером; \n2 - самовывоз; \n3 - пункты выдачи");
            int delType = Convert.ToInt32(Console.ReadLine());

            if (delType == 1)
            {
                Console.WriteLine("Введите адрес доставки:");
                client.Adress = Console.ReadLine();
                HomeDelivery<string> addressDelivery = new HomeDelivery<string>(client.Adress);
                addressDelivery.CanDelivery(courier, client);
                DeliveryStatus(courier, client);
            }
            else if (delType == 2)
            {
                ShopDelivery pickup = new ShopDelivery();
            }
            else if (delType == 3)
            {
                PickPointPostamat postamat1 = new PickPointPostamat("Алтуфьево 12", false);
                PickPointPostamat postamat2 = new PickPointPostamat("Где-то далеко", true);
                PickPointPostamat postamat3 = new PickPointPostamat("Где-то рядом", false);
                PickPointPostamat[] allPostamats = { postamat1, postamat2, postamat3 };
                Console.WriteLine("Все пункты выдачи. Какой выберете? (1 - 3)");
                int index = 1;
                foreach (var item in allPostamats)
                {
                    var work = item.isWork ? "работает" : "не работает";
                    Console.WriteLine(index + " - Пункт выдачи - " + item.DeliveryAdress + ". В данный момент он " + work);
                    index++;
                }
                int postIndex = Convert.ToInt32(Console.ReadLine()) - 1;                
                allPostamats[postIndex].CheckInfo(allPostamats, postIndex);

            }
        }
        // ... Другие поля
    }
}
