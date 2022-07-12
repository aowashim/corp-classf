using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OffersMicroservices.Database
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int N_Likes { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime? Engaged_Date { get; set; }
        public int Category_Id { get; set; }
        public int Emp_Id { get; set; }
        public List<Comment> CommentList { get; set; }
        [ForeignKey("Category_Id")]
        public Offer_Category Offer_Category { get; set; }
    }

    public class Offer_Category
    {
        [Key]
        public int Cateory_Id { get; set; }
        public string Name { get; set; }
    }
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int User_Id { get; set; }
        public int Offer_Id { get; set; }
    }
}
