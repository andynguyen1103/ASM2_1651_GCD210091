using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asignment2
{
    internal class VipDecorator:RoomDecorator
    {
        public VipDecorator(IHotelRoom wrappee):base(wrappee)
        {

        }

        public override double Price
        {
            get => Math.Round(base.Price * 1.3, 1); //bump the price and round it to the first digit
            set => base.Price = value;
        }
        public override string Description => base.Description + " and with VIP features";
    }
}
