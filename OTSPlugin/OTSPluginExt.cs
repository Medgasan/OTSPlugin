using KeePass.Plugins;
using System.Windows.Forms;
using System;
using KeePassLib;
using KeePassLib.Security;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Drawing;


namespace OTSPlugin
{
    public class OTSPluginExt : Plugin
    {
        private IPluginHost m_host = null;

        public override bool Initialize(IPluginHost host)
        {
            if (host == null) return false;
            m_host = host;
            return true;
        }

        public override void Terminate() {}

        public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
        {
            if (t == PluginMenuType.Entry)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem
                {
                    Image = new ImageConverter().ConvertFrom(Resource1.favicon_16x16_conv) as Image,
                    Text = "Get OneTimeSecret URL from Password"
                };
                toolStripMenuItem.Click += this.AsyncOlaQAseClicked;
                return toolStripMenuItem;
            }
            return null;
        }


        private async void AsyncOlaQAseClicked(object sender, EventArgs e)
        {
            PwEntry selectedEntry = m_host.MainWindow.GetSelectedEntry(false);
            if (selectedEntry != null)
            {
                ProtectedString protectedPassword = selectedEntry.Strings.Get(PwDefs.PasswordField);
                ProtectedString protectedUsername = selectedEntry.Strings.Get(PwDefs.UserNameField);
                string password = protectedPassword.ReadString();
                string username = protectedUsername.ReadString();
                string secretUrl = await SendPasswordToOneTimeSecret(password);

                Clipboard.SetText(secretUrl);
                MessageBox.Show($"OTP URL: {secretUrl}\n\nCopiada al portapapeles", "Contraseña encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private async Task<string> SendPasswordToOneTimeSecret(string password)
        {
            string otsServer = "onetimesecret.com";

            var body = new Dictionary<string, string>
            {
                { "ttl", "604800" }, // 14 días
                { "secret", password }
            };

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(body);

                HttpResponseMessage response = await client.PostAsync($"https://{otsServer}/api/v1/share", content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Parsear la respuesta JSON para obtener la clave del secreto
                OTSResponse jsonResponse =   JsonConvert.DeserializeObject<OTSResponse>(responseBody);
                string secretKey = jsonResponse.Secret_Key;

                string urlOts = $"https://{otsServer}/secret/{secretKey}";
                return urlOts;

            }
        }
    }
}
