using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Google.Apis.Util;
using MailKit.Net.Smtp;

namespace Library.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("SendEmail")]
        public async Task<IActionResult> Get()
        {
            #region OAuth驗證
            const string GMailAccount = "前置作業文章打上去的測試帳號";

            var clientSecrets = new ClientSecrets
            {
                ClientId = "前置作業文章最後給的用戶ID",
                ClientSecret = "前置作業文章最後給的用戶端密碼"
            };

            var codeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                DataStore = new FileDataStore("CredentialCacheFolder", false),
                Scopes = new[] { "https://mail.google.com/" },
                ClientSecrets = clientSecrets
            });

            var codeReceiver = new LocalServerCodeReceiver();
            var authCode = new AuthorizationCodeInstalledApp(codeFlow, codeReceiver);

            var credential = await authCode.AuthorizeAsync(GMailAccount, CancellationToken.None);

            if (credential.Token.IsExpired(SystemClock.Default))
                await credential.RefreshTokenAsync(CancellationToken.None);

            var oauth2 = new SaslMechanismOAuth2(credential.UserId, credential.Token.AccessToken);
            #endregion

            #region 信件內容
            var message = new MimeMessage();
            //寄件者名稱及信箱(信箱是測試帳號)
            message.From.Add(new MailboxAddress("bill", "chusiyin9@gmail.com"));
            //收件者名稱，收件者信箱
            message.To.Add(new MailboxAddress("billhuang", "chusiying@outlook.com"));
            //信件標題
            message.Subject = "How you doing'?";
            //信件內容
            message.Body = new TextPart("plain")
            {
                Text = @"This is test"
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587);
                await client.AuthenticateAsync(oauth2);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            #endregion

            return Ok("OK");
        }
    }
}
