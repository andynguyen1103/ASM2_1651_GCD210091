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
        private string _guest= String.Empty;

        public int RoomNo 
        {
            get  => _roomNo; 
            
            set
            {
                if (value > 0)
                {
                    _roomNo = value;
                }
                else Console.WriteLine("Please input room number again");
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
                else Console.WriteLine("Please input price again");
            } 
        }

        //the guest name
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

        //get the description of the room including room num, price, availble?, description
        public string GetDescription()
        {
                StringBuilder desc = new StringBuilder();
                desc.AppendLine($"Room number: {RoomNo}").
                    AppendLine($"Status : {(IsAvailable ? "Available" : "Unavailable")}"). //check if the room is available
                    AppendLine($"Guest: {Guest}").
                    Append($"Description: This is a hotel room");
                return desc.ToString();
        }

        public string DisplayPrice()
        {
            return $"Price: {Price}";
        }

        public HotelRoom(int roomNo, double price)
        {
            this.RoomNo = roomNo;
            this.Price = price;
            this.IsAvailable = true;
        }
    }
}
