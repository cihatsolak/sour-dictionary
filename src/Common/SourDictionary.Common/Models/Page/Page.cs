namespace SourDictionary.Common.Models.Page
{
    public class Page
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRowCount { get; set; }
        public int TotalPageCount => (int)Math.Ceiling((double)(TotalRowCount / PageSize));
        public int Skip => (CurrentPage - 1) * PageSize;

        public Page() : this(0)
        {
        }

        public Page(int totalRowCount) : this(10, totalRowCount, 1)
        {
        }

        public Page(int pageSize, int totalRowCount) : this(pageSize, totalRowCount, 1)
        {
        }

        public Page(int pageSize, int totalRowCount, int currentPage)
        {
            if (currentPage < 1)
                throw new ArgumentNullException(nameof(currentPage), "Invalid current page.");

            if (pageSize < 1)
                throw new ArgumentNullException(nameof(pageSize), "Invalid page size.");

            TotalRowCount = totalRowCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}
