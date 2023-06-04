using System;
using System.Collections.Generic;

namespace Product_Catalog.Entity;

public partial class SubCategory
{
    public int SubCategoryNo { get; set; }

    public string? SubCategoryName { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }


}
