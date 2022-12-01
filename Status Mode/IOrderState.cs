using System;
using System.Collections.Generic;
using System.Text;

namespace StateMode
{
    interface IOrderState
    {
        void Process(OrderContext context);
    }
}
