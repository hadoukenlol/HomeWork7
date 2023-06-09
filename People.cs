using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    abstract class People
    {
        public string Name { get; }
        abstract public void GetProduct(List<Product> products);
    }
    class Courier : People
    {
        public bool isWork { get; set; }
        public string workTime;
        public Courier(string Name, bool isWork)
        {
            this.isWork = isWork;
        }
        public void CheckWork(bool isWork)
        {
            if (isWork == false)
            {
                workTime = "не работает";
            }
            else
            {
                workTime = "работает";
            }
        }

        public void GetMoney()
        {
            Console.WriteLine("Взял деньги у клиента");
        }
        public void GiveProduct(List<Product> products)
        {
            Console.WriteLine("Передал товары клиенту");
        }
        public override void GetProduct(List<Product> products)
        {
            Console.WriteLine("Забрал товары со склада");
        }
    }
    class Client : People
    {
        public string Adress { get; set; }
        public Client(string Name) { }

        public override void GetProduct(List<Product> products)
        {               
            Console.WriteLine("Получил товары от курьера");

        }
        public void GiveMoney()
        {
            Console.WriteLine("Оплатил");
        }
    }
}
