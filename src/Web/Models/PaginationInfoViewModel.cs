using System;

namespace Web.Models
{
    public class PaginationInfoViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int ItemsOnPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)Constants.ITEMS_PER_PAGE);
        public int DisplayStart => (CurrentPage - 1) * Constants.ITEMS_PER_PAGE + 1;
        public int DisplayEnd => (CurrentPage - 1) * Constants.ITEMS_PER_PAGE + ItemsOnPage;
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

    }
}
