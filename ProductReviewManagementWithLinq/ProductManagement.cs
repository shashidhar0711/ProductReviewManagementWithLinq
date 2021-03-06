﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace ProductReviewManagementWithLinq
{
    public class ProductManagement
    {
        public readonly DataTable dataTable = new DataTable();
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
        public ProductManagement()
        {
            /// Creating columns
            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("UserId", typeof(int));
            dataTable.Columns.Add("Rating", typeof(int));
            dataTable.Columns.Add("Review", typeof(string));
            dataTable.Columns.Add("isLike", typeof(bool));

            /// Creating rows and adding values into column wise
            dataTable.Rows.Add(1, 1, 5, "good", true);
            dataTable.Rows.Add(2, 2, 3, "better", false);
            dataTable.Rows.Add(3, 3, 5, "good", true);
            dataTable.Rows.Add(4, 4, 4, "nice", false);
            dataTable.Rows.Add(5, 5, 3, "better", true);
            dataTable.Rows.Add(6, 6, 5, "good", false);
            dataTable.Rows.Add(7, 7, 5, "good", true);
            dataTable.Rows.Add(8, 7, 5, "better", true);
            dataTable.Rows.Add(9, 8, 3, "good", true);
            dataTable.Rows.Add(10, 9, 5, "good", true);
            dataTable.Rows.Add(11, 10, 3, "better", true);
            dataTable.Rows.Add(12, 10, 4, "nice", false);
            dataTable.Rows.Add(13, 10, 3, "better", true);
            dataTable.Rows.Add(14, 10, 4, "good", true);
            dataTable.Rows.Add(15, 10, 5, "good", false);
            dataTable.Rows.Add(16, 11, 5, "good", true);
            dataTable.Rows.Add(17, 11, 3, "better", true);
            dataTable.Rows.Add(18, 12, 4, "nice", true);
            dataTable.Rows.Add(19, 15, 5, "good", true);
            dataTable.Rows.Add(20, 16, 5, "good", false);
            dataTable.Rows.Add(21, 17, 5, "good", true);
            dataTable.Rows.Add(22, 10, 4, "nice", true);
            dataTable.Rows.Add(23, 18, 3, "better",false);
            dataTable.Rows.Add(24, 19, 4, "nice", true);
            dataTable.Rows.Add(25, 20, 4, "nice", true);
        }

        /// <summary>
        /// UC8
        /// Retrieves the data from table.
        /// </summary>
        public void RetrieveDataFromTable()
        {
            var recordData = from products in dataTable.AsEnumerable()
                             where (products.Field<bool>("isLike") == true)
                             select products;

            foreach (var products in recordData)
            {
                Console.WriteLine("ProductId : " + products.Field<int>("ProductId") 
                                    +" UserId : "+products.Field<int>("userId")
                                    +" Rating : " + products.Field<int>("Rating")
                                    +" Review : " + products.Field<string>("Review")
                                    +" IsLike : " + products.Field<bool>("isLike"));
            }
        }

        /// <summary>
        /// UC9
        /// Converts to findaverageratingbyproductid.
        /// </summary>
        public void ToFindAverageRatingByProductID()
        {
            var Data = dataTable.AsEnumerable()
                       .GroupBy(product => product.Field<int>("ProductID"))
                       .Select(product => new
                       {
                           ProductID = product.Key,
                           Ratings = product.Average(product => product.Field<int>("Rating"))
                       });

            foreach (var dataItem in Data)
            {
                Console.WriteLine("Product Id: " + dataItem.ProductID + " " + "Average: " + dataItem.Ratings);
            }
        }

        /// <summary>
        /// UC10
        /// Retrieves the field of review.
        /// </summary>
        public void RetrieveFieldOfReview()
        {
            var recordData = from products in dataTable.AsEnumerable()
                            where (products.Field<string>("Review") == "nice")
                            select products;
            foreach (var products in recordData)
            {
                Console.WriteLine("ProductId : " + products.Field<int>("ProductId")
                                    + " UserId : " + products.Field<int>("userId")
                                    + " Rating : " + products.Field<int>("Rating")
                                    + " Review : " + products.Field<string>("Review")
                                    + " IsLike : " + products.Field<bool>("isLike"));
            }
        }

        /// <summary>
        /// UC11
        /// Retrieves the records having same user idwith ratings.
        /// </summary>
        public void RetrieveRecordsHavingSameUserIdwithRatings()
        {
            var recordedData = dataTable.AsEnumerable()
                .OrderBy(products => products.Field<int>("Rating"))
                .Where(products => products.Field<int>("userId") == 10)
                .Select(products => new 
                { 
                    SameUserId = products.Field<int>("userId"), 
                    Rating = products.Field<int>("Rating") 
                });

            foreach (var products in recordedData)
            {
                Console.WriteLine("SameUserId : " + products.SameUserId +" "+ " Ratings : " + products.Rating);
            }
        }
    }
}
