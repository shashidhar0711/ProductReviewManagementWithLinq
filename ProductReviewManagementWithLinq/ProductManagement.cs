using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductReviewManagementWithLinq
{
    public class ProductManagement
    {
        /// <summary>
        /// UC2
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

        /// <summary>
        /// UC3
        /// Gets the records greater than three.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public void GetRecordsGreaterThanThree(List<ProductReview> productReviewList)
        {
            /// Linq query to retrieve records with given condition
            var recordedData = (from products in productReviewList
                                where (products.Rating>3) && (products.ProductId == 1 || products.ProductId == 4 || products.ProductId == 9)
                                select products);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId :-" + list.ProductId + " " + "UserId:-" + list.UserId + " " + "Rating :-" + " " + list.Rating + " "
                + "Review :-" + list.Review + " " + "isLike :-" + list.isLike);
            }
        }

        /// <summary>
        /// UC4
        /// Gets the count of reviews.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public void GetCountOfReviews(List<ProductReview> productReviewList)
        {
            /// Linq query to retrieve records with given condition
            var recordedReviewCount = (from products in productReviewList
                                group products by products.ProductId into g
                                select new
                                {
                                    productId = g.Key,
                                    TotalCount = g.Count()
                                });
            foreach (var list in recordedReviewCount)
            {
                Console.WriteLine("Review Count : "+list.TotalCount);
            }
        }

        /// <summary>
        /// UC5
        /// Gets the product identifier and review.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public void GetProductIdAndReview(List<ProductReview> productReviewList)
        {
            /// Linq query to retrieve records with given condition
            var recordedReviewCount = (from products in productReviewList
                                       select new
                                       {
                                           productId = products.ProductId,
                                           Review = products.Review
                                       });
            foreach (var list in recordedReviewCount)
            {
                Console.WriteLine("ProductId : " + list.productId+ "\t"+"Review :"+list.Review);
            }
        }
    }
}
