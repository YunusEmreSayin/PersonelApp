using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonelAPI.Model;
using System.Data.SqlClient;
using System.Text.Json;

namespace PersonelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class getPersonelController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public getPersonelController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        [HttpGet]
        [Route("selectpersonel")]
        public ActionResult<Personel> GetPersonel()
        {
            List<Personel> personelList = new List<Personel>();

            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("PersonelConnection").ToString());
                String cmdstring = "SELECT TOP 1 * FROM personel ORDER BY ID DESC";
                SqlCommand cmd = new SqlCommand(cmdstring, con);
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Personel personel = new Personel();

                    personel.Ad = dr["Ad"].ToString();
                    personel.Soyad = dr["Soyad"].ToString();
                    personel.ID = (int)dr["ID"];
                    personelList.Add(personel);

                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
              //  return ex.Message;
            }
            string message = System.Text.Json.JsonSerializer.Serialize(personelList);
            return Content(message);
           

        }

        

       
    }

}
