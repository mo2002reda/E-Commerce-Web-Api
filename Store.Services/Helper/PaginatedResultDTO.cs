using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Helper
{
    public class PaginatedResultDTO<T>
    {
        public PaginatedResultDTO(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;  //

            PageSize = pageSize;    //
            Count = count;          //number of items in the page
            Data = data;
        }

        public int PageIndex { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
