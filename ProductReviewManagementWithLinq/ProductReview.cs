﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProductReviewManagementWithLinq
{
    /// <summary>
    /// Gettes and setters of class
    /// </summary>
    public class ProductReview
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public bool isLike { get; set; }

    }
}
