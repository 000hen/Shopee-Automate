using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace Shopee_Automate
{
    class BrowserObject
    {
        private IBrowser _browser;
        private IPage _page;
        private IElementHandle _currentElement;

        public async Task SetUpBrowser()
        {
            BrowserFetcher _browserfetcher = new ();
            await _browserfetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);

            _browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                Args = new[] {
                    "--disable-dev-shm-usage",
                    "--disable-gpu",
                    "--user-agent=\"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36\"",
                    "--disable-blink-features",
                    "--disable-blink-features=AutomationControlled"
                },
            });
            _page = await _browser.NewPageAsync();
        }

        public async Task LoadPage(string URL)
        {
            await SendDevToolsCommand("Page.addScriptToEvaluateOnNewDocument", new DevToolsScript()
            {
                source = "Object.defineProperty(navigator, 'webdriver', { get: () => undefined })"
            });
            await _page.GoToAsync(URL);
        }

        public async Task<byte[]> Capture()
        {
            return await _page.ScreenshotDataAsync();
        }

        public string GetCurrentURL()
        {
            return _page.Url;
        }

        public async Task WaitNavigation()
        {
            await _page.WaitForNavigationAsync();
        }

        public async Task WaitQuery(string query)
        {
            await _page.WaitForSelectorAsync(query);
        }

        public async Task<IElementHandle> FindElementByQuery(string query)
        {
            _currentElement = await _page.QuerySelectorAsync(query);
            return _currentElement;
        }

        public async Task FillText(string query, string text)
        {
            await _page.TypeAsync(query, text);
        }

        public async Task Click(string query)
        {
            await _page.ClickAsync(query);
        }

        public async Task<IElementHandle> XPathSeletorWait(string xpath)
        {
            return await _page.WaitForXPathAsync(xpath);
        }

        public async Task<IElementHandle[]> XPathSeletor(string xpath)
        {
            return await _page.XPathAsync(xpath);
        }

        public async Task<CookieParam[]> GetCookies()
        {
            return await _page.GetCookiesAsync(GetCurrentURL());
        }

        public async Task ExecuteJavascriptOnNewDocument(string script)
        {
            await _page.EvaluateExpressionOnNewDocumentAsync(script);
        }

        public async Task SendDevToolsCommand(string command, DevToolsScript script)
        {
            var client = await _page.Target.CreateCDPSessionAsync();
            await client.SendAsync(command, script);
        }

        public async Task ExecuteJavascript(string script)
        {
            await _page.EvaluateExpressionAsync(script);
        }

        public async Task SetCookies(CookieParam cookies)
        {
            await _page.SetCookieAsync(cookies);
        }

        public async Task CloseBrowser()
        {
            if (_browser != null) await _browser.CloseAsync();
        }
    }
}
