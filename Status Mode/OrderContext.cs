using System;
using System.Collections.Generic;
using System.Text;

namespace StateMode
{
    /**
     * （1）环境角色（Context）：也称上下文，定义客户端所感兴趣的接口，并且保留一个具体状态类的实例。这个具体状态类的实例给出此环境对象的现有状态。
     * （2）抽象状态角色（State）：定义一个接口，用以封装环境对象的一个特定的状态所对应的行为。
     * （3）具体状态角色（ConcreteState）：每一个具体状态类都实现了环境（Context）的一个状态所对应的行为。
     * 实现过程：new 一个上下文，初始化上下文时，可传参赋予初始状态，也可以固定初始状态。状态的改变由具体状态类内部实现=》查看OrderState类
     * 状态改变后，状态携带的行为也会随之改变
     */
    class OrderContext
    {
        private IOrderState orderState;

        public OrderContext()
        {
            //工单初始化
            orderState = new OrderInit();
        }

        /// <summary>
        /// 是否关闭工单
        /// </summary>
        public bool IsCancel { get; set; }

        public double Minutes { get; set; }

        public bool IsFinished { get; set; }

        public void SetOrderState(IOrderState s)
        {
            orderState = s;
        }
        public void Action()
        {
            orderState.Process(this);
        }
    }
}
