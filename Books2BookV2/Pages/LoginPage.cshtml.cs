 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Books2Book.Models;
using NuGet.Protocol.Plugins;

namespace Books2BookV2.Pages
{
    public class LoginPageModel : PageModel
    {
        public void OnGet()
        {
        }

        public bool buttonPressed()
        {
            bool flag = false;
            SqlConnection conn = new SqlConnection("Server=VIDUR\\MSSQLSERVER01;Database=Book2Book;Trusted_Connection=True;");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(); 
            
            return flag;
        }
    }
}
