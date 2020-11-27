using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductReviewManagementWithLinq
{
    public class ProductManagement
    {
        /// <summary>
        /// UC1
        /// Gets the top three records.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public void GetTopThreeRecords(List<ProductReview> productReviewList)
        {
            /// Linq query to retrieve top three having high ratings
            var recordedData = (from prodctReviews in productReviewList
                               orderby prodctReviews.Rating descending
                               select prodctReviews).Take(3);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId :-" + list.ProductId + " " + "UserId:-" + list.UserId + " " + "Rating :-" + " " + list.Rating + " "
                + "Review :-" + list.Review + " " + "isLike :-" + list.isLike);
            }
        }
    }
}
