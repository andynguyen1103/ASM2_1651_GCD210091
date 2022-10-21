using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asignment2
{
    internal abstract class RoomDecorator : IHotelRoom
    {
        protected IHotelRoom wrappee;
        public RoomDecorator(IHotelRoom wrappee)
        {
            this.wrappee = wrappee;
        }
        public int RoomNo
        {
            get => wrappee.RoomNo;
            set => wrappee.RoomNo = value;
        }
        public bool IsAvailable 
        { 
            get => wrappee.IsAvailable; 
            set => wrappee.IsAvailable = value; 
        }
        public virtual double Price 
        { 
            get => wrappee.Price;
            set => wrappee.Price = value; 
        }
        public string Guest 
        { 
            get => wrappee.Guest;
            set => wrappee.Guest = value;
        }

        public virtual string GetDescription() => wrappee.GetDescription();

        public string DisplayPrice()
        {
            return $"Price: {Price}";
        }
    }
}
