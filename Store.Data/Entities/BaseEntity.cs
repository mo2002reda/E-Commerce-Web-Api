using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class BaseEntity<T>//this is generaic table that accept any type 
    {
        //any table inherit from this class the type will be same type of this column (id)
        public T id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now; //default value of creating 

    }
}
