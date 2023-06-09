using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    abstract class Payment {
        abstract public void Method();
        static public void SetDelivery()
        {

        }
    }
    class CashPay : Payment {
        public override void Method()
        {
            Console.WriteLine("Выбрана оплата наличными");
        }
    }
    class CardPay : Payment
    {
        public override void Method()
        {
            Console.WriteLine("Выбрана оплата картой");
            
        }
    }
}
