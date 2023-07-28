using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnekle_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.Ad = txtad.Text;
            personel.Soyad = txtsoyad.Text;
            var Client = new System.Net.Http.HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5153");
            var SerializedPersonel = JsonSerializer.Serialize(personel);
            StringContent strcontent = new StringContent(SerializedPersonel, Encoding.UTF8, "application/json");
            await Client.PostAsync("api/PersonelAPI/", strcontent);
        }

    }
}
