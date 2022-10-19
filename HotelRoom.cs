using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Asignment2
{
    internal class HotelRoom : IHotelRoom
    {
        private int _roomNo;
        private bool _isAvailable;
        private double _price;
        private string _guest;
        public int RoomNo 
        {
            get  => _roomNo; 
            
            set
            {
                if (value > 0)
                {
                    _roomNo = value;
                }
                else Console.WriteLine("Invalid input");
            }
        }
        public bool IsAvailable 
        { 
            get => _isAvailable; 

            set => _isAvailable=value;
        }
        public double Price 
        { get => throw new NotImplementedException(); 
          set => throw new NotImplementedException(); 
        }
        public string Guest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetDescription()
        {
            throw new NotImplementedException();
        }
    }
}
