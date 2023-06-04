using System;
using System.Collections.Generic;

namespace Product_Catalog.Entity;

public partial class Product
{
    public int ProductNo { get; set; }

    public int? SubCategoryId { get; set; }

    public string? Brand { get; set; }

    public decimal? Price { get; set; }

    public string? Specification { get; set; }

}
