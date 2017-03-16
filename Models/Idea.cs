using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace beltexam4.Models
{
    public class Idea : BaseEntity
    {
        public string idea { get; set; }
        public string alias {get; set;}
        public int likes { get; set; }
        public int users_id {get; set;}
        public User user { get; set; }
        public int yes_votes { get; set; }
        public int no_votes { get; set; }
    }
}