using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Parameters
{
    public class PaginationMetadata<T> where T: class
    {
        public PaginationMetadata()
        {

        }

        public PaginationMetadata(PageList<T> models)
        {
            TotalCount = models.TotalCount;
            PageSize = models.PageSize;
            CurrentPage = models.CurrentPage;
            TotalPages = models.TotalPages;
            HasNext = models.HasNext;
            HasPrevious = models.HasPrevious;
        }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
