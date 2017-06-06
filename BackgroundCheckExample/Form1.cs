using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundCheckExample
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> statusDataSource = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSendUpdate_Click(object sender, EventArgs e)
        {
            var btnText = btnSendUpdate.Text;
            btnSendUpdate.Text = "Please Wait...";
            btnSendUpdate.Enabled = false;


            var client = new WebClient();

            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            var url = txtURL.Text;

            var reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("apikey", txtApiKey.Text);
            reqparm.Add("status", cmbStatus.Text);
            reqparm.Add("status_date", DateTime.Now.ToLongDateString());
            reqparm.Add("provider", txtProvider.Text);
            reqparm.Add("student_email", txtEmail.Text);

            // This version not yet implemented
            // reqparm.Add("program_code", txtProgramCode.Text);

            reqparm.Add("promo_code", txtProgramCode.Text);

            var result = "";
            try { 
                var rawResult = client.UploadValues(url, "POST", reqparm);
                result = Encoding.UTF8.GetString(rawResult);
            } catch(WebException ex) {
                result = ex.ToString();
            };

            MessageBox.Show(result);

            btnSendUpdate.Text = btnText;
            btnSendUpdate.Enabled = true;
        }
    }
}
