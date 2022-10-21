using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asignment2
{
    //Add to the room with 
    internal class BeachSideDecorator : RoomDecorator
    {
        public BeachSideDecorator(IHotelRoom wrappee) : base(wrappee)
        {
        }

        public override double Price 
        { 
            get => Math.Round(wrappee.Price*1.2,1); //bump the price and round it to the first digit
            set => wrappee.Price = value; 
        }
        public override string GetDescription() => base.GetDescription() + " with beautiful beach view";


    }
}
