using System;
using System.Collections.Generic;
using System.Text;

namespace StateMode
{
    /// <summary>
    /// 工单初始化
    /// </summary>
    class OrderInit : IOrderState
    {
        public void Process(OrderContext context)
        {
            Console.WriteLine("工单正在初始化。。。");
            //小于30分钟 可以取消
            if (context.Minutes <= 30 && context.IsCancel)
            {
                Console.WriteLine("正在取消工单。。。");
                context.SetOrderState(new CancelOrder());
                context.Action();
            }
            else
            {
                context.SetOrderState(new OrderGo());
                Console.WriteLine("工单初始化完成。。。");
                context.Action();
            }          
        }
    }

    /// <summary>
    /// 工单开始处理
    /// </summary>
    class OrderGo : IOrderState
    {
        public void Process(OrderContext context)
        {
            Console.WriteLine("工单开始处理。。。");
            context.SetOrderState(new OrderComplete());
            context.Action();
        }
    }

    /// <summary>
    /// 工单处理完毕
    /// </summary>
    class OrderComplete : IOrderState
    {
        public void Process(OrderContext context)
        {
            Console.WriteLine("工单处理完毕。。。");
            context.IsFinished = true;
        }
    }

    /// <summary>
    /// 取消工单
    /// </summary>
    class CancelOrder : IOrderState
    {
        public void Process(OrderContext context)
        {
            Console.WriteLine("工单已取消。。。");
            context.IsFinished = true;
        }
    }

}
