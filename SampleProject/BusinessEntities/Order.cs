using System;

namespace BusinessEntities
{
    public class Order : IdNumberObject
    {
        private DateTime _orderDate;

        public DateTime OrderDate
        {
            get => _orderDate;
            private set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException("Order date cannot be in the future.");
                }
                _orderDate = value;
            }
        }
        
        public void SetOrderDate(DateTime orderDate)
        {
            OrderDate = orderDate;
        }
    }
}