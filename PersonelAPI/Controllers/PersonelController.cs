using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelAPI.Model;
using System.Data.SqlClient;

namespace PersonelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public PersonelController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        [HttpPost]
        [Route("insertpersonel")]
        public void insertPersonel(Personel personel)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("PersonelConnection").ToString());
            String cmdstring = "INSERT INTO personel(Ad,Soyad) VALUES(@Ad,@Soyad)";
            SqlCommand cmd = new SqlCommand(cmdstring, con);
            createPersonelParams(cmd, personel);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void createPersonelParams(SqlCommand cmd,Personel personel)
        {
            cmd.Parameters.AddWithValue("@Ad", personel.Ad);
            cmd.Parameters.AddWithValue("@Soyad", personel.Soyad);
        }
    }

}
