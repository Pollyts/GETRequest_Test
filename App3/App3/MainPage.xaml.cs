using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "https://10.0.2.2:44378/Users/";
        public MainPage()
        {
            InitializeComponent();
        }

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            var json = await GetJsonAsync();
            await DisplayAlert("Result:", json, "OK");

        }
        public static async Task<string> GetJsonAsync()
        {
            var client = GetClient();
            string jsonString = await client.GetStringAsync(Url);
            return jsonString;
        }
    }
}
