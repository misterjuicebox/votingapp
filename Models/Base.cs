using System;
using System.ComponentModel.DataAnnotations;
namespace beltexam4.Models
{
    public abstract class BaseEntity 
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}