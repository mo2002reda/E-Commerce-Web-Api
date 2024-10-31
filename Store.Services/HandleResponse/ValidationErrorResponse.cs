using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.HandleResponse
{
    public class ValidationErrorResponse : CustomeException
    {
        public ValidationErrorResponse() : base(400)
        {
        }

        public IEnumerable<String> Errors { get; set; }//Represent List of Validation Error
    }
}
