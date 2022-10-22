using Books2BookV2.Controllers;
using Books2BookV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Books2BookV2.Pages.Shared
{
    public class BookViewModel : PageModel
    {
        private readonly TblBooksController tblBooksController;

        public TblBook ?tblBook { get; set; }
        public BookViewModel(TblBooksController tblBooksController)
        {
            this.tblBooksController = tblBooksController;
        }

        public async void OnGet(int id)
        {
         tblBook = (TblBook?)await tblBooksController.Details(id);
        }
    }
}
