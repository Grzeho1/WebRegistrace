using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace WebRegistrace.Pages
{
    public class RegistraceModel : PageModel
    {
        public Uzivatel uzivatel = new Uzivatel();
        public String error = "";

        public void OnGet()
        {
           
        }
        public void OnPost()
        {

            uzivatel.login = Request.Form["login"];
            uzivatel.heslo = Request.Form["heslo"];

            if (uzivatel.login == "" || uzivatel.heslo == "")
            {
                error = "xxx";
                return;
            }

            try
            {
                String connectionString = "Data Source=TOMAS;Initial Catalog=Projekt;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Login " + "(login,heslo) VALUES" + "(@login,@heslo);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("login", uzivatel.login);
                        command.Parameters.AddWithValue("heslo", uzivatel.heslo);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public class Uzivatel
        {
            public string login;
                public string heslo;
        }
    }
}
