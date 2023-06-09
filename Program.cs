using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace HomeWork7

{

    
    internal class Program
    {
        static void Main(string[] args)
        {
            Courier courier = new Courier("Ваня", true);
            //Console.WriteLine($"Курьер {courier.Name} - {courier.workTime}");
            Console.WriteLine("Представьтесь");
            string UserName = Console.ReadLine();
            Client client = new Client(UserName);
            Order order = new Order(DateTime.Now);

            order.AddProduct("Товар 1", 100);
            order.AddProduct("Товар 2", 300);
            order.AddProduct("Товар 3", 800);
            order.AddProduct("Товар 4");
            Console.WriteLine($"Создан заказ на имя {client.Name} - номер заказа {order.Number}. Дата создания {order.Date}");
            Console.WriteLine(order.GetAllProducts());
            Console.WriteLine("Общая сумма заказа: " + order.summPrice);

            Console.WriteLine("Какой метод оплаты? 1 - наличными, 2 оплата картой");
            int method = Convert.ToInt32(Console.ReadLine());
            order.SetPaymentMethod(method);
            order.SetDelivery(courier, client);

        }
    }
}