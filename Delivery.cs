using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    abstract class Delivery
    {
        public string DeliveryAdress;
    }
    class HomeDelivery<TDelivery> : Delivery
    {
        public TDelivery Delivery;        
         public HomeDelivery(TDelivery delivery)
        {
            Console.WriteLine("Ваш адрес доставки: " + delivery);

        }
        public void CanDelivery(Courier courier, Client client)
        {
            if (!courier.isWork) {
                Console.WriteLine("Извините доставка невозможна, курьер не рабочий");
            }
            else
            {
                Console.WriteLine("Курьер заберет посылку и привезет вам сегодня");
            }
        }

            
    }

    abstract class PickPointDelivery : Delivery
    {
        public PickPointDelivery() {
            
        }
        public abstract PickPointPostamat CheckInfo(PickPointPostamat[] Postamats, int postIndex);
    }
    class PickPointPostamat : PickPointDelivery
    {
        public bool isWork;
        public PickPointPostamat(string DeliveryAdress, bool isWork)
        {
            this.DeliveryAdress = DeliveryAdress;
            this.isWork = isWork;
        }

        public override PickPointPostamat CheckInfo(PickPointPostamat[] Postamats, int postIndex)
        {

            if (Postamats[postIndex].isWork)
            {
                Console.WriteLine("Выбран пункт выдачи: " + Postamats[postIndex].DeliveryAdress);
                return Postamats[postIndex];
            }
            else
            {
                Console.WriteLine("Данный постамат не работает, выберите другой");
                postIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                CheckInfo(Postamats, postIndex);
            }
            return Postamats[postIndex];
        }

    }

    class ShopDelivery : Delivery
    {
       public ShopDelivery()
        {
            string workTime = "с 09:00 до 17:00";
            string DeliveryAdress = "Какой-нибудь адрес магазина";
            Console.WriteLine($"Приходите в магазин {workTime} по адресу: {DeliveryAdress}");
        }
    }
}
