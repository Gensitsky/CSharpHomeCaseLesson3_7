/*
    Описать перечисление PayType определяющее форму
    оплаты клиентом заказа, и добавить соответствующее
    поле в структуру Request из задания №4.
*/
using System;
using System.Linq;

namespace CSharpHomeCaseLesson3_7
{
    enum PayType
    {
        Cash,
        Visa,
        MasterCard,
        WebMoney
    }
    struct Request
    {
        private int orderId;
        private string orderClient;
        private DateTime orderDate;
        private string[] orderItems;
        private double[] orderUnits;
        private double orderTotal;
        private PayType orderPay;

        public Request(int id, string client, DateTime date,
            string[] items, double[] units, PayType pay)
        {
            orderId = id;
            orderClient = client;
            orderDate = date;
            orderItems = items;
            orderUnits = units;
            orderTotal = units.Sum();
            orderPay = pay;
        }

        public void PrintRequest()
        {
            Console.WriteLine($"Code:\t{orderId}");
            Console.WriteLine($"Client:\t{orderClient}");
            Console.WriteLine($"Date:\t{orderDate}");
            Console.Write("Items:\t");
            foreach (var item in orderItems)
            {
                Console.Write(item + "\t");
            }
            Console.Write("\nUnits:\t");
            foreach (var item in orderUnits)
            {
                Console.Write(item + " $\t\t");
            }
            Console.WriteLine($"\nTotal:\t{orderTotal} $");
            Console.WriteLine($"Paid:\t{orderPay}\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] items1 = { "Notebook", "Printer HP", "PC" };
            double[] units1 = { 700, 200, 400 };
            string[] items2 = { "Notebook", "Smartphone", "PC" };
            double[] units2 = { 700, 300, 500 };
            string[] items3 = { "Notebook", "Smartphone", "PC" };
            double[] units3 = { 700, 300, 500 };

            Request order1 = new Request(1, "Vadim Gensitsky",
                DateTime.Now.Date, items1, units1,PayType.MasterCard);
            Request order2 = new Request(2, "Vlad Tkachenko",
                DateTime.Now.Date, items2, units2,PayType.WebMoney);
            Request order3 = new Request(3, "Alex Zloba",
                DateTime.Now.Date, items2, units2, PayType.Cash);

            order1.PrintRequest();
            order2.PrintRequest();
            order3.PrintRequest();

            Console.ReadKey();
        }
    }
}
