using System;
using System.ComponentModel.DataAnnotations;
namespace beltexam4.ViewModels {
    public class IdeaViewModel {

        public string idea { get; set; }
        public string alias {get; set;}
        public int users_id {get; set;}
        public int ideas_id {get; set;}

    }
}