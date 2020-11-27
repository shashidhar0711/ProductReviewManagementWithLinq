using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace ProductReviewManagementWithLinq
{
    public class ProductManagement
    {
        DataTable dataTable = new DataTable();
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
                Console.WriteLine("ProductId : " + list.productId + "\t" + "Review :" + list.Review);
            }
        }

        /// <summary>
        /// UC6
        /// Gets all records except top five records.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public void GetAllRecordsExceptTopFiveRecords(List<ProductReview> productReviewList)
        {
            /// Linq query to retrieve all records except top five records
            var recordedReviewCount = (from product in productReviewList
                                       orderby product.ProductId
                                       select product).Skip(5);
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var list in recordedReviewCount)
            {
                Console.WriteLine("ProductId :-" + list.ProductId + " " + "UserId:-" + list.UserId + " " + "Rating :-" + " " + list.Rating + " "
                + "Review :-" + list.Review + " " + "isLike :-" + list.isLike);
            }
        }

        /// <summary>
        /// UC7
        /// Creates the new data table.
        /// </summary>
        public void CreateNewDataTable()
        {
            /// Creating columns
            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("UserId", typeof(int));
            dataTable.Columns.Add("Rating", typeof(int));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("isLike", typeof(string));

            /// Creating rows and adding values into column wise
            dataTable.Rows.Add(1, 1, 5, "good", "true");
            dataTable.Rows.Add(2, 2, 3, "better", "true");
            dataTable.Rows.Add(3, 3, 5, "good", "true");
            dataTable.Rows.Add(4, 4, 4, "nice", "true");
            dataTable.Rows.Add(5, 5, 3, "better", "true");
            dataTable.Rows.Add(6, 6, 5, "good", "false");
            dataTable.Rows.Add(7, 7, 5, "good", "true");
            dataTable.Rows.Add(8, 7, 5, "better", "true");
            dataTable.Rows.Add(9, 8, 3, "good", "true");
            dataTable.Rows.Add(10, 9, 5, "good", "true");
            dataTable.Rows.Add(11, 10, 3, "better", "true");
            dataTable.Rows.Add(12, 10, 4, "nice", "false");
            dataTable.Rows.Add(13, 11, 3, "better", "true");
            dataTable.Rows.Add(14, 11, 4, "good", "true");
            dataTable.Rows.Add(15, 11, 5, "good", "true");
            dataTable.Rows.Add(16, 11, 5, "good", "true");
            dataTable.Rows.Add(17, 11, 3, "better", "true");
            dataTable.Rows.Add(18, 12, 4, "nice", "true");
            dataTable.Rows.Add(19, 15, 5, "good", "true");
            dataTable.Rows.Add(20, 16, 5, "good", "true");
            dataTable.Rows.Add(21, 17, 5, "good", "true");
            dataTable.Rows.Add(22, 11, 4, "nice", "true");
            dataTable.Rows.Add(23, 18, 3, "better", "false");
            dataTable.Rows.Add(24, 19, 4, "nice", "true");
            dataTable.Rows.Add(25, 20, 4, "nice", "true");
        }
    }
}
