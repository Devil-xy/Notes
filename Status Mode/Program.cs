using System;

namespace StateMode
{
    class Program
    {
        static void Main(string[] args)
        {
            //订单顺序执行，客户成功收到货物
            Console.WriteLine("[订单顺序执行，客户成功收到货物]");
            var order = new OrderContext();
            order.Minutes = 9;
            order.Action();
            Console.WriteLine();

            //可以取消订单[客户在30min内主动取消，取消成功]
            Console.WriteLine("[客户在30min内主动取消，取消成功]");
            var order1 = new OrderContext();
            order1.IsCancel = true;
            order1.Minutes = 20;
            order1.Action();
            Console.WriteLine();

            //不可以取消订单[超时30min (商家已准备好发货)，即使客户想主动取消，也无法取消]
            Console.WriteLine("[客户超过30min后主动取消，取消失败]");
            var order2 = new OrderContext();
            order2.IsCancel = true;
            order2.Minutes = 33;
            order2.Action();
            Console.Read();
        }
    }
}
