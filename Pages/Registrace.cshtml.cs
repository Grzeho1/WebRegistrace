using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace WebRegistrace.Pages
{
    public class RegistraceModel : PageModel
    {
        public List<Uzivatel> listUzivatele=new List<Uzivatel>();
        public string login;
        public string heslo;

        public void OnGet()
        {
           
        }
        public void OnPost()
        {

            login = Request.Form["login"];
            heslo = Request.Form["heslo"];

           
        }
        public class Uzivatel
        {
            public string login;
                public string heslo;
        }
    }
}
