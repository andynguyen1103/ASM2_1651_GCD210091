using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asignment2
{
    internal class HotelProgram
    {
        private static HotelProgram _hotelProgram;
        private Hotel _hotel;

        private HotelProgram()
        {
            _hotel = new Hotel();
        }
        public static HotelProgram getHotelProgram()
        {
            if (_hotelProgram == null)
            {
                _hotelProgram = new HotelProgram();
            }
            return _hotelProgram;
        }
        public void StartProgram()
        {
            Login();
            Console.Write("Please name your hotel: ");
            string name = Console.ReadLine();
            bool isExit = false;
            int option;
            do
            {
                DisplayOptions(name);
                option = int.Parse(Console.ReadLine());
                isExit = ChooseOption(option);
            } while (!isExit);
        }

        private void DisplayOptions(string name)
        {
            Console.WriteLine($"{name} Hotel Management program");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("1. Create a room");
            Console.WriteLine("2. Remove a room");
            Console.WriteLine("3. Get details of all rooms");
            Console.WriteLine("4. Get details of available rooms");
            Console.WriteLine("5. Book a room");
            Console.WriteLine("6. Unbook a room");
            Console.WriteLine("0. Exit");
            Console.Write("Chosen option: ");
        }

        private void Login()
        {
            string username;
            string password;
            while (true)
            {
                Console.Write("Username: ");
                username= Console.ReadLine();
                Console.Write("Password: ");
                password= Console.ReadLine();
                if (username=="admin"&&password=="admin")
                {
                    return;
                }
                Console.WriteLine("Wrong username or password!");
            }
        }

        /// <summary>
        /// Manage the chosen option from user
        /// </summary>
        /// <param name="option"></param>
        /// <returns>true if the user choose 0, else false</returns>
        private bool ChooseOption(int option)
        {
            switch (option)
            {
                case 1:
                    double price;
                    bool isBeachSide=false;
                    bool isVip=false;
                    Console.Write("Please input the price: ");
                    price=double.Parse(Console.ReadLine());
                    Console.Write("Does it have beach view?(Y/N): ");
                    string a=Console.ReadLine();
                    if (a=="Y")
                    {
                        isBeachSide = true;
                        
                    }
                    Console.Write("Is it VIP?(Y/N): ");
                    a = Console.ReadLine();
                    if (a=="Y")
                    {
                        isVip = true;
                    }
                    _hotel.AddRoom(price, isBeachSide, isVip);
                    break;

                case 2:
                    if (_hotel.GetAllRoomsDetails().Equals(String.Empty))
                    {
                        Console.WriteLine("There is no room");
                        break;
                    }
                    Console.WriteLine(_hotel.GetAllRoomsDetails());
                    Console.Write("Put the room number to remove: ");
                    int roomNo = int.Parse(Console.ReadLine());
                    _hotel.RemoveRoom(roomNo);
                    break;

                case 3:
                    if (_hotel.GetAllRoomsDetails().Equals(String.Empty))
                    {
                        Console.WriteLine("There is no room");
                        break;
                    }
                    Console.WriteLine(_hotel.GetAllRoomsDetails());
                    break;

                case 4:
                    if (_hotel.GetEmptyRoomsDetails().Equals(String.Empty))
                    {
                        Console.WriteLine("There are no available room!");
                        break;
                    }
                    Console.WriteLine(_hotel.GetEmptyRoomsDetails());
                    break;

                case 5:
                    Console.WriteLine("Here are all the details of avaible rooms");
                    if (_hotel.GetEmptyRoomsDetails().Equals(String.Empty))
                    {
                        Console.WriteLine("There are no available room!");
                        break;
                    }
                    Console.WriteLine(_hotel.GetEmptyRoomsDetails());
                    Console.Write("Please choose the room you want to book: ");
                    int temp = int.Parse(Console.ReadLine());
                    Console.Write("Please provide the guest name: ");
                    string guest = Console.ReadLine();
                    _hotel.BookRoom(temp, guest);
                    break;
                case 6:
                    if (_hotel.GetBookedRoomsDetails().Equals(String.Empty))
                    {
                        Console.WriteLine("There are no booked room!");
                        break;
                    }
                    Console.WriteLine(_hotel.GetBookedRoomsDetails());
                    Console.Write("Choose a room to unbook: ");
                    int room = int.Parse(Console.ReadLine());
                    _hotel.UnbookRoom(room);
                    break;
                case 0:
                    return true;
                    break;

                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }
            return false;
        }


    }
}