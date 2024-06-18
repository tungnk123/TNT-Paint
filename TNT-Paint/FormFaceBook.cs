using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FacebookWrapper.ObjectModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TNT_Paint
{
    public partial class FormFaceBook : Form
    {
        User m_LoggedInUser;
        private Cloudinary cloudinary;
        Account account = new Account(
              "dxyfcffvz",
              "839826873884674",
              "EN58HAYBnbxoEjw-TF_FjGFVS3o");
        public FormFaceBook()
        {
            InitializeComponent();
        }

        public FormFaceBook(User user)
        {
            InitializeComponent();
            m_LoggedInUser = user; 
            fetchUserInfo();
        }
        private void fetchUserInfo()
        {
            if (m_LoggedInUser == null)
            {
                MessageBox.Show("User is null");
                return;
            }

            pb_ava.LoadAsync(m_LoggedInUser.PictureNormalURL);
            lb_name.Text = m_LoggedInUser.Name;

            pb_image.Image = Form1.instance.pb_mainScreen.Image;
        }

        private async void btn_post_Click(object sender, EventArgs e)
        {
            string filePath = Form1.path;
            if (filePath == "")
            {
                MessageBox.Show("Bạn phải lưu trước khi share facebook!");
                return;
            }

            cloudinary = new Cloudinary(account);
            try
            {
                var uploadResult = await UploadImageToCloudinary(filePath);

                string m_AccessToken = "EAALtIOu0jkkBOww1gw0Vben9ZB25J0fGLcS1WdQolDwyhZBr27H2079IOcBGNLEY0E5XSuqqMVfFmddO9jq8066IFtCqNEwVTv69bSB4fbfazu4m7Q5pwTdaZAKWhx5FEBAOk1dEjCb4Yhmr6VMkaZBhZAuZCS4SIZAcB1dcczuKyaSSHsobGp1krX5amFDOmzfXfthTl32qnzZC63x5jGErBH0ZD";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                JObject json = JObject.Parse($@"
            {{
                ""access_token"": ""{m_AccessToken}"",
                ""message"": ""hahaha"",
                ""published"": ""true"",
                ""url"": ""{uploadResult.Uri}"",

            }}");

                var postData = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                var request = await client.PostAsync("https://graph.facebook.com/v20.0/111818641551816/photos", postData);


                if (request.IsSuccessStatusCode)
                {
                    MessageBox.Show("Status Posted Successfully!");
                }
                else
                {
                    string responseContent = await request.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed to post status: {request.StatusCode}. Response: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error uploading image: {ex.Message}");
            }


            
            
            
            
        }

        private async Task<CloudinaryDotNet.Actions.ImageUploadResult> UploadImageToCloudinary(string filePath)
        {
            var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams()
            {
                File = new FileDescription(filePath)
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Failed to upload image to Cloudinary: " + uploadResult.Error.Message);
            }

            return uploadResult;

        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
