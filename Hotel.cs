using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        //return the description of all the available rooms
        public string GetEmptyRoomsDetails()
        {
            var availableRooms = hotelRooms.FindAll((r) => r.IsAvailable);
            StringBuilder allDescription = new StringBuilder();
            if (availableRooms.Count()!=0)
            {
                foreach (var room in availableRooms)
                {
                    allDescription.AppendLine(room.GetDescription()).
                                    AppendLine(room.DisplayPrice() + "\n"); 
                }
            }

            return allDescription.ToString();
            
        }
        public string GetAllRoomsDetails()
        {
            StringBuilder allDescription = new StringBuilder();
            foreach (var room in hotelRooms)
            {
                allDescription.AppendLine(room.GetDescription()).
                                AppendLine(room.DisplayPrice() + "\n");
            }
            return allDescription.ToString();

        }
        public string GetBookedRoomsDetails()
        {
            StringBuilder allDescription = new StringBuilder();
            foreach (var room in hotelRooms.FindAll((c)=>!c.IsAvailable))
            {
                allDescription.AppendLine(room.GetDescription()).
                                AppendLine(room.DisplayPrice()+"\n");
            }
            return allDescription.ToString();
        }
        public void AddRoom(double price, bool isBeachSide, bool isVip)
        {
            // find the next room number

            int nextRoomNo;

            if (hotelRooms.Count() == 0)
            {
                nextRoomNo = 1;
            }
            else
            {
                nextRoomNo = hotelRooms.MaxBy((r) => r.RoomNo).RoomNo + 1; //find the biggest room number and add 1
            }

            IHotelRoom newRoom = new HotelRoom(nextRoomNo, price);

            //check if this is beach side or vip room or both

            if (isBeachSide)
            {
                newRoom = new BeachSideDecorator(newRoom);
            }

            if (isVip)
            {
                newRoom = new VipDecorator(newRoom);
            }

            hotelRooms.Add(newRoom);
        }
        
        public void RemoveRoom(int roomNo)
        {
            // find the Room to be deleted
            int index = hotelRooms.FindLastIndex((r) => r.RoomNo == roomNo);
            //remove it
            
            if (index!=-1)
            {
                hotelRooms.RemoveAt(index);
                Console.WriteLine("deleted successfully");
                return;
            }

            Console.WriteLine("Room not found!");

        }

        public void BookRoom(int roomNo, string guestName)
        {
            // find the Room to be booked
            int index = hotelRooms.FindLastIndex((r) => r.RoomNo == roomNo);

            if (index!=-1)
            {
                hotelRooms[index].IsAvailable = false;
                hotelRooms[index].Guest=guestName;
                return;
            }

            Console.WriteLine("Room not found!");
        }

        public void UnbookRoom(int roomNo)
        {
            // find the Room to be booked
            int index = hotelRooms.FindLastIndex((r) => r.RoomNo == roomNo);

            if (index != -1)
            {
                if (!hotelRooms[index].IsAvailable)
                {
                    hotelRooms[index].IsAvailable = true;
                    hotelRooms[index].Guest = String.Empty;
                    return;
                }

                Console.WriteLine("The room is not booked");
                
            }

            Console.WriteLine("Room not found!");
        }
    }
}
