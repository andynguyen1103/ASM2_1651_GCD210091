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
        private double _price = 100;
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
                else throw new ArgumentException("Please input room number again");
            }
        }
        public bool IsAvailable 
        { 
            get => _isAvailable; 

            set => _isAvailable=value;
        }
        public double Price 
        { get => _price; 
          set
            {
                if (value > 0)
                {
                    _price = value;
                }
                else throw new ArgumentException("Please input price again");
            } 
        }
        public string Guest
        {
            get
            {
                if (string.IsNullOrEmpty(_guest))
                {
                    return "N/A";
                }

                return _guest;
            }
            set
            {
                _guest = value;
            }
        }

        public string Description
        {
            get
            {
                StringBuilder desc = new StringBuilder();
                desc.AppendLine($"Room number: {RoomNo}").
                    AppendLine($"Price: {Price} dollars").
                    Append($"Description: This is a hotel room");
                return desc.ToString();
            }
        }
    }
}
