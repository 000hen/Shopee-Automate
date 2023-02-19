using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using Shopee_Automate.Forms;
using Panel = Shopee_Automate.Forms.Panel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Shopee_Automate
{
    class Program
    {
        private static BrowserObject bso = new();

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();

            BrowserObject _bso = bso;

            if (args.Length == 0)
            {
                Application.Run(new Panel());
                _ = Exit(0);
            }

            if (args.Length > 0)
            {
                if (args[0] == "help")
                {
                    string fileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

                    Console.WriteLine(String.Format("Usage:\n\t{0} <USERNAME> <PASSWORD> <COOKIES PATH>", fileName));
                    _ = Exit(0);
                }

                if (args[0] == "nogui")
                {
                    string[] account = Util.ReadAccountInfo();
                    if (account.Length != 2)
                    {
                        Console.WriteLine("無法讀取帳號資訊，請先設定帳號密碼。");
                        _ = Exit(1);
                    }

                    Task.Run(async () =>
                    {
                        await Runner(account[0], account[1]);
                    }).Wait();
                }

                if (args.Length == 2)
                {
                    string USERNAME = args[0];
                    string PASSWORD = args[1];

                    Task.Run(async () =>
                    {
                        await Runner(USERNAME, PASSWORD);
                    }).Wait();
                }
            }
        }

        public static async Task Exit(int exitCode)
        {
            Console.WriteLine("退出中...");
            if (bso != null) await bso.CloseBrowser();
            Environment.Exit(exitCode);
        }

        public static async Task Runner(string username, string password)
        {
            Console.WriteLine("正在設定自動化瀏覽器...");
            await bso.SetUpBrowser();

            Console.WriteLine("載入頁面中...");
            ShopeeMovement spm = new(bso);

            if (File.Exists(Util.CookiesPath))
            {
                Console.WriteLine("找到登入Cookies，載入Cookies中...");

                await bso.LoadPage(ShopeeMovement.Shopee);

                List<CookiesObject> cookiesJSON = JsonConvert.DeserializeObject<List<CookiesObject>>(File.ReadAllText(Util.CookiesPath));
                

                foreach (var cookie in cookiesJSON)
                {
                    await bso.SetCookies(new PuppeteerSharp.CookieParam
                    {
                        Name = cookie.Name,
                        Value = cookie.Value
                    });
                }

                Console.WriteLine("匯入Cookies成功!");
            }

            bool status = await spm.Login(username, password);
            if (!status)
            {
                Console.WriteLine("登入失敗");
                if (File.Exists(Util.CookiesPath))
                {
                    File.Delete(Util.CookiesPath);
                }
                _ = Exit(1);
            }

            Util.SaveAsJson(Util.CookiesPath, await bso.GetCookies());

            _ = Exit(0);
        }
    }
}
