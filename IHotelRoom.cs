using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asignment2
{
    internal interface IHotelRoom
    {
        int RoomNo { get; set; }
        bool IsAvailable { get; set; }
        double Price { get; set; }
        string Guest { get; set; }
        string Description { get;}
    }
}
