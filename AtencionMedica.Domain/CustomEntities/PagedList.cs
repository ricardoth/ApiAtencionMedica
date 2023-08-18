namespace AtencionMedica.Domain.CustomEntities
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?)null;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        //public static PagedList<T> Create(ICollection<T> source, int pageNumber, int pageSize)
        //{
        //    var count = source.Count();
        //    var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        //    return new PagedList<T>(items, count, pageNumber, pageSize);
        //}

        public static PagedList<T> Create(ICollection<T> source, int pageSize, int pageNumber, int totalCount)
        {
            var items = source.ToList();
            return new PagedList<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
