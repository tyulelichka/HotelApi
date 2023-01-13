using System;
using System.Collections.Generic;

namespace HotelApi;

public partial class Spa
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

  //  public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
