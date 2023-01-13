using System;
using System.Collections.Generic;

namespace HotelApi;

public partial class Room
{
    public int Id { get; set; }

    public int Price { get; set; }

    public int Number { get; set; }

    public int Count { get; set; }

  //  public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
