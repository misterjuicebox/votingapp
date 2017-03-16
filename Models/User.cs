using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace beltexam4.Models
{
    public class User : BaseEntity
    {
        public User() {
            idea = new List<Idea>();
        }

        public string name {get; set;}
        public string email { get; set; }
        public string alias { get; set; }
        public string password { get; set; }
        public string compare { get; set; }
        public int posts {get; set;}
        public int likes {get; set;}
        public Likes like {get; set;}
        public ICollection<Idea> idea { get; set; }

    }
}