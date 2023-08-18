using System;
using System.Collections.Generic;

namespace Northwind_Example.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
