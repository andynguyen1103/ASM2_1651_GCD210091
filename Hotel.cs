using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asignment2
{
    internal class Hotel
    {
        private List<IHotelRoom> hotelRooms;
        private string _name;

        public Hotel()
        {
            this.hotelRooms = new List<IHotelRoom>();
        }
        public Hotel(string name):this()
        {
            this._name = name;
        }
        public string Name
        {
            get 
            {
                if (string.IsNullOrEmpty(_name))
                {
                    return "N/A";
                } 
                return _name;
            }
            set => _name = value;
        }

    }
}
