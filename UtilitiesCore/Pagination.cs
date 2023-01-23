using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesCore
{
    public class Pagination<T>
    {
        public int PageSize { get; set; }
        public int TotalPage
        {
            get
            {
                return Data.Count() % PageSize == 0 ? Data.Count() / PageSize : (Data.Count() / PageSize) + 1;
            }
        }
        public int CurrentPage { get; set; }
        private IEnumerable<T> Data;
        public IEnumerable<T> PageContent { get; set; }

        public Pagination(int pageSize, int currentPage, IEnumerable<T> data)
        {
            PageSize = pageSize;
            CurrentPage = currentPage;
            Data = data;
            PageContent = data.Skip((currentPage - 1) * pageSize).Take(pageSize);
        }
    }
}
