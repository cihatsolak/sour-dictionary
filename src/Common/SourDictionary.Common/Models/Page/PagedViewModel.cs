namespace SourDictionary.Common.Models.Page
{
    public class PagedViewModel<T> where T : class
    {
        public IList<T> Result { get; set; }
        public Page PageInfo { get; set; }

        public PagedViewModel() : this(new List<T>(), new Page())
        {
        }

        public PagedViewModel(IList<T> result, Page pageInfo)
        {
            Result = result;
            PageInfo = pageInfo;
        }
    }
}
