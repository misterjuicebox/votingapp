using beltexam4.Models;
using System.Collections.Generic;
namespace beltexam4.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
        // T Add(T item);
        T FindByID(int id);
        IEnumerable<T> FindAll(); 
        
    }
}