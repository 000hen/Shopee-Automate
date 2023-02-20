using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Shopee_Automate
{
    class Util
    {
        public static string CurrentPath = Path.GetDirectoryName(Program.ExecutePath);
        public static string LoginInfoPath = CurrentPath + "/login";
        public static string CookiesPath = CurrentPath + "/cookies";

        public static string XPathByText(string queryElement, string text)
        {
            return String.Format("//{0}[contains(text(), '{1}')]", queryElement, text);
        }

        public static string GetLoginXpaths()
        {
            List<string> xpaths = new();
            foreach (string xpath in ElementObjects.WRONG_PASSWORD)
            {
                xpaths.Add(XPathByText("div", xpath));
            }

            xpaths.Add(XPathByText("button", ElementObjects.PLAY_PUZZLE));
            xpaths.Add(XPathByText("button", ElementObjects.SHOPEE_ALREADY));
            xpaths.Add(XPathByText("div", ElementObjects.USE_EMAIL));
            xpaths.Add(XPathByText("div", ElementObjects.USE_LINK));
            xpaths.Add(XPathByText("div", ElementObjects.TOO_MUCH_TRY));
            xpaths.Add(XPathByText("div", ElementObjects.SHOPEE_REWARD));

            return String.Join("|", xpaths.ToArray());
        }

        public static string GetCoinXpath()
        {
            return String.Join("|", new List<string>
            {
                XPathByText("button", ElementObjects.SHOPEE_ALREADY),
                XPathByText("button", ElementObjects.SHOPEE_CAN_GET)
            });
        }

        public static string[] ReadAccountInfo()
        {
            return File.ReadAllText(LoginInfoPath).Split(":");
        }

        public static void SaveAsJson(string path, object data)
        {
            string formated = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, formated);
        }
    }

    public class CookiesObject
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }
        public double Expires { get; set; }
        public int Size { get; set; }
        public bool HttpOnly { get; set; }
        public bool Secure { get; set; }
        public bool Session { get; set; }
    }
}
