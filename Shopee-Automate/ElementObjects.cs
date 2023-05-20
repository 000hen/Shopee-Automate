using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopee_Automate
{
    public class ElementObjects : ElementProvider
    {
        public static string INPUT_USERNAME = "input[name=loginKey]";
        public static string INPUT_PASSWORD  = "input[name=password]";
        public static string BUTTON_LOGIN_TEXT  = "登入";


        public static string PLAY_PUZZLE = "點擊以重新載入頁面";
        public static string USE_LINK = "使用連結驗證";
        public static string USE_EMAIL = "透過電子郵件連結驗證";
        public static string TOO_MUCH_TRY = "您已達到今日驗證次數上限。";
        public static string SHOPEE_REWARD = "蝦幣獎勵";
        public static string[] SHOPEE_ALREADY = {
            "明天再回來領取",
            "明天再回來",
            "明天再回來簽到"
        };
        public static string[] SHOPEE_CAN_GET = {
            "今日簽到獲得",
            "完成簽到"
        };
        public static string VERIFICATION_DENIED = "很抱歉，您的身份驗證已遭到拒絕。";
        public static string[] WRONG_PASSWORD = {
          "你的帳號或密碼不正確，請再試一次",
          "登入失敗，請稍後再試或使用其他登入方法",
          "您輸入的帳號或密碼不正確，若遇到困難，請重設您的密碼。"
        };
    }

    public enum StatusCode
    {
        SUCCESS_LOGIN,
        WRONG_PASSWORD,
        NEED_HUMAN,
        SMS_VERIFICATION,
        EMAIL_VERIFICATION,

        ALREADY_GET,

        UNKNOWN
    }
    
    public interface ElementProvider
    {
    }
}
