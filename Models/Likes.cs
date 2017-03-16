using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace beltexam4.Models
{
    public class Likes : BaseEntity
    {
        public int ideas_id { get; set; }
        public int like_count {get; set;}
        public int users_id {get; set;}
        public User user {get; set;}
        public int no_votes { get; set;}
    }
}