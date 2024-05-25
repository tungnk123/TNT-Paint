using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenerativeAI.Methods;
using GenerativeAI.Models;
using GenerativeAI.Types;

namespace TNT_Paint
{
    public partial class FormGemini : Form
    {
        private readonly HttpClient _httpClient;
        private string key = "lmwr_sk_KG4u2mK1dD_aV7BjEKHvKVbxhHsA6alYDAsBDcbICye4MEpT";
        ChatSession chatSession;
        public string apiKey = "AIzaSyADlzxTNbFb2Xh3wbbXCYSPgwVp3T4d4DY";

        public FormGemini()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            var model = new GenerativeModel(apiKey);
            chatSession = model.StartChat(new StartChatParams());
        }


        public async Task testAsync()
        {
            pb_image.Image = Properties.Resources.loading;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Api-Version", "v1");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + key);

            string content = tb_content.Text;

            var result = await chatSession.SendMessageAsync("Chuyển từ tiếng việt qua tiếng anh cho tôi với nội dung như sau:" + content);

            JObject json = JObject.Parse($@"
            {{
                ""prompt"": ""{result}"",
                ""aspect_ratio"": ""1:1""
            }}");

            var postData = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var request = await client.PostAsync("https://api.limewire.com/api/image/generation", postData);
            var response = await request.Content.ReadAsStringAsync();

            // Parse the response JSON to get the image URL
            JObject responseObject = JObject.Parse(response);
            var imageUrl = responseObject["data"]?[0]?["asset_url"]?.ToString();

            if (!string.IsNullOrEmpty(imageUrl))
            {
                Console.WriteLine(imageUrl);
                await LoadImageIntoPictureBox(imageUrl);
            }
            else
            {
                MessageBox.Show("Image URL not found.");
            }
        }

        private async Task LoadImageIntoPictureBox(string imageUrl)
        {
            try
            {
                var response = await _httpClient.GetAsync(imageUrl);
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var image = Image.FromStream(stream);
                    pb_image.Image = image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }

        private async void btn_tao_Click(object sender, EventArgs e)
        {
            await testAsync();
        }

        private void btn_chup_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.instance.g.DrawImage(pb_image.Image, Form1.instance.pb_mainScreen.Location.X, Form1.instance.pb_mainScreen.Location.Y,
                    Form1.instance.pb_mainScreen.Width, Form1.instance.pb_mainScreen.Height);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
