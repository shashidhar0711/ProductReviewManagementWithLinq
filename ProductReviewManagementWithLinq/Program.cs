using System;
using System.Collections.Generic;

namespace ProductReviewManagementWithLinq
{
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product review mangaement with linq");
            /// Created instances of object class
            ProductManagement productManagement = new ProductManagement();
            /// Created a list 
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ ProductId = 1, UserId = 1, Rating = 5, Review = "Good", isLike = true},
                new ProductReview(){ ProductId = 2, UserId = 2, Rating = 4, Review = "Good", isLike = true},
                new ProductReview(){ ProductId = 3, UserId = 3, Rating = 5, Review = "Good", isLike = true},
                new ProductReview(){ ProductId = 4, UserId = 4, Rating = 5, Review = "Good", isLike = true},
                new ProductReview(){ ProductId = 5, UserId = 5, Rating = 4, Review = "Good", isLike = true},
                new ProductReview(){ ProductId = 6, UserId = 6, Rating = 5, Review = "Good", isLike = true},
                new ProductReview(){ ProductId = 7, UserId = 7, Rating = 5, Review = "bad", isLike = true},
                new ProductReview(){ ProductId = 8, UserId = 8, Rating = 5, Review = "Good", isLike = true},
                new ProductReview(){ ProductId = 9, UserId = 9, Rating = 5, Review = "nice", isLike = true},
                new ProductReview(){ ProductId = 10, UserId = 10, Rating = 4, Review = "Good", isLike = false},
                new ProductReview(){ ProductId = 11, UserId = 10, Rating = 4, Review = "nice", isLike = true},
                new ProductReview(){ ProductId = 12, UserId = 10, Rating = 5, Review = "Good", isLike = true},
                new ProductReview(){ ProductId = 13, UserId = 11, Rating = 2, Review = "Good", isLike = false},
                new ProductReview(){ ProductId = 14, UserId = 12, Rating = 5, Review = "nice", isLike = true},
                new ProductReview(){ ProductId = 15, UserId = 13, Rating = 3, Review = "Good", isLike = false},
                new ProductReview(){ ProductId = 16, UserId = 13, Rating = 4, Review = "nice", isLike = true},
                new ProductReview(){ ProductId = 17, UserId = 13, Rating = 4, Review = "Good", isLike = true},
                new ProductReview(){ ProductId = 18, UserId = 14, Rating = 5, Review = "Good", isLike = false},
                new ProductReview(){ ProductId = 19, UserId = 15, Rating = 5, Review = "Good", isLike = false},
                new ProductReview(){ ProductId = 20, UserId = 16, Rating = 5, Review = "nice", isLike = false},
                new ProductReview(){ ProductId = 21, UserId = 17, Rating = 4, Review = "Good", isLike = false},
                new ProductReview(){ ProductId = 22, UserId = 10, Rating = 5, Review = "Good", isLike = false},
                new ProductReview(){ ProductId = 23, UserId = 18, Rating = 5, Review = "Good", isLike = false},
                new ProductReview(){ ProductId = 24, UserId = 20, Rating = 5, Review = "Good", isLike = false},
                new ProductReview(){ ProductId = 25, UserId = 20, Rating = 5, Review = "Good", isLike = false},
            };
            /// UC1
            /// Iterating through list.
            foreach (var list in productReviewList)
            {
                Console.WriteLine("ProductId :-" + list.ProductId + " " + "UserId:-" + list.UserId + " " + "Rating :-" + " " + list.Rating + " "
                + "Review :-" + list.Review + " " + "isLike :-" + list.isLike);
            }
            /// Calling method to create data table
            productManagement.CreateNewDataTable();
        }
    }
}
