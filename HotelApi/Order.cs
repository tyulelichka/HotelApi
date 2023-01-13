using System;
using System.Collections.Generic;

namespace HotelApi;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoomId { get; set; }

    public int? SpaId { get; set; }

    public int? MenuId { get; set; }

    //public virtual Menu? Menu { get; set; }

    //public virtual Room? Room { get; set; }

    //public virtual Spa? Spa { get; set; }

    //public virtual User? User { get; set; }
}
