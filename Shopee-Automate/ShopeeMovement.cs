using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopee_Automate
{
    class ShopeeMovement
    {
        public static string Shopee = "https://shopee.tw/";
        public static string ShopeeCoinURL = "https://shopee.tw/shopee-coins";
        public static string ShopeeCoinAuthURL = "https://shopee.tw/shopee-coins?is_from_login=true";
        public static string ShopeeLoginURL = "https://shopee.tw/buyer/login?from=https%3A%2F%2Fshopee.tw%2Fuser%2Fcoin&next=https%3A%2F%2Fshopee.tw%2Fshopee-coins";
        public static string ShopeeVerification = "https://shopee.tw/verify/ivs?is_initial=true";
        public static string ShopeeVerificationSMS = "https://shopee.tw/verify/link";
        public static string ShopeeVerificationEmail = "https://shopee.tw/verify/email-link";

        private BrowserObject bso;

        public ShopeeMovement(BrowserObject _bso)
        {
            bso = _bso;
        }

        public async Task<bool> Login(string username, string password)
        {
            await bso.LoadPage(ShopeeLoginURL);

            if (bso.GetCurrentURL() == ShopeeCoinURL)
            {
                return true;
            }

            Console.WriteLine("未登入! 嘗試登入中...");

            await bso.WaitQuery(ElementObjects.INPUT_PASSWORD);
            await bso.FillText(ElementObjects.INPUT_USERNAME, username);
            await bso.FillText(ElementObjects.INPUT_PASSWORD, password);

            System.Threading.Thread.Sleep(500);

            var loginBtn = await bso.XPathSeletorWait(Util.XPathByText("button", ElementObjects.BUTTON_LOGIN_TEXT));
            await loginBtn.ClickAsync();

            int status = await CheckLoginPage();

            if (status == StatusCode.WRONG_PASSWORD || status == StatusCode.NEED_HUMAN) return false;

            if (status == StatusCode.SMS_VERIFICATION)
            {
                return await VerifcationViaSMS();
            }

            if (status == StatusCode.EMAIL_VERIFICATION)
            {
                return await VerificationViaEmail();
            }

            return true;
        }

        private async Task<int> CheckLoginPage()
        {
            PuppeteerSharp.IElementHandle[] result;

            do
            {
                result = await bso.XPathSeletor(Util.GetLoginXpaths());
                
                await Task.Delay(500);
            } while (result.Length > 0);

            string rstext = (await (await bso.XPathSeletorWait(Util.GetLoginXpaths())).GetPropertyAsync("innerHTML")).ToString().Replace("JSHandle:", "");

            if (rstext == ElementObjects.SHOPEE_REWARD)
            {
                Console.WriteLine("登入成功!");
                return StatusCode.SUCCESS_LOGIN;
            }

            if (rstext.Contains(ElementObjects.SHOPEE_ALREADY))
            {
                Console.WriteLine("登入成功! 已領取過蝦幣了!");
                return StatusCode.ALREADY_GET;
            }

            if (ElementObjects.WRONG_PASSWORD.Contains(rstext))
            {
                Console.WriteLine("密碼錯誤!");
                return StatusCode.WRONG_PASSWORD;
            }

            if (rstext == ElementObjects.PLAY_PUZZLE)
            {
                Console.WriteLine("需要人類驗證，自動化工具無法驗證!");
                return StatusCode.NEED_HUMAN;
            }

            if (rstext == ElementObjects.USE_LINK)
            {
                Console.WriteLine("請查看您的手機簡訊! 將使用簡訊連結登入!");
                return StatusCode.SMS_VERIFICATION;
            }

            if (rstext == ElementObjects.USE_EMAIL)
            {
                Console.WriteLine("請查看您的電子郵件信箱! 將使用信箱中的連結登入!");
                return StatusCode.EMAIL_VERIFICATION;
            }

            Console.WriteLine(String.Format("發生錯誤! 於尋找xpath {0} 時發生錯誤", Util.GetLoginXpaths()));
            return StatusCode.UNKNOWN;
        }

        private async Task<bool> CheckVerification()
        {
            while (true)
            {
                if ((await bso.XPathSeletor(Util.XPathByText("div", ElementObjects.VERIFICATION_DENIED))).Length != 0)
                {
                    Console.WriteLine("自動化工具被拒絕驗證登入。請稍後再嘗試一次。");
                    return false;
                }

                if (bso.GetCurrentURL() == ShopeeCoinURL)
                {
                    Console.WriteLine("驗證成功!");
                    return true;
                }

                await Task.Delay(500);
            }
        }

        private async Task<bool> VerifcationViaSMS()
        {
            var smsbtn = await bso.XPathSeletorWait(Util.XPathByText("div", ElementObjects.USE_LINK));
            await smsbtn.ClickAsync();

            while (bso.GetCurrentURL() != ShopeeVerificationSMS)
            {
                await Task.Delay(500);
            }

            if (await bso.XPathSeletorWait(Util.XPathByText("div", ElementObjects.TOO_MUCH_TRY)) != null)
            {
                Console.WriteLine("無法使用簡訊驗證登入: 已達到當日最高驗證次數");
                return false;
            }

            Console.WriteLine("已發送驗證簡訊，請檢查您的手機。一旦您點擊驗證連結，此自動化工具將會繼續執行。");

            return await CheckVerification();
        }

        private async Task<bool> VerificationViaEmail()
        {
            var emailbtn = await bso.XPathSeletorWait(Util.XPathByText("div", ElementObjects.USE_EMAIL));
            await emailbtn.ClickAsync();

            while (bso.GetCurrentURL() != ShopeeVerificationEmail)
            {
                await Task.Delay(500);
            }

            Console.WriteLine("已發送郵件，請檢查您的信箱。一旦您點擊驗證連結，此自動化工具將會繼續執行。");

            return await CheckVerification();
        }
    }
}
