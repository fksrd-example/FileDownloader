using System;
using System.Net.Mime;
using System.Security.Policy;

namespace FileDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                FileDownloader();
            }
        }

        private static readonly HttpClient _httpClient = new HttpClient();

        private async void FileDownloader()
        {
            UriBuilder uriBuilder = new UriBuilder(textBox1.Text);
            byte[] fileBytes = await _httpClient.GetByteArrayAsync(uriBuilder.Uri);
            SaveFileDialog saveFileDialog = new SaveFileDialog();   
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, fileBytes);
            }
        }
    }
}