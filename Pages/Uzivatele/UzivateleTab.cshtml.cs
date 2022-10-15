using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebRegistrace.Pages.Uzivatele
{
    public class IndexModel : PageModel
    {
        public List<Uzivatel>listUzivatelu=new List<Uzivatel>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source = TOMAS; Initial Catalog = Projekt; Integrated Security = True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Login";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Uzivatel uzivatel = new Uzivatel();
                                uzivatel.login = reader.GetString(0);
                                uzivatel.heslo = reader.GetString(1);

                                listUzivatelu.Add(uzivatel);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            
        }

        public class Uzivatel
        {
            public String login;
            public String heslo;
        }
    }
}
