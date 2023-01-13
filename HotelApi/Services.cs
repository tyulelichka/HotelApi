using Microsoft.EntityFrameworkCore;

namespace HotelApi
{
    [Keyless]
    public class Services
    {
        public int id_services { get; set; }
        public int port { get; set; }   
        public string name { get; set; }    
        public string host { get; set; } 
        public DateTime entered { get; set; }   
    }
}
