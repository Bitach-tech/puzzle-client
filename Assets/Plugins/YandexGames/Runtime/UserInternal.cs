using System.Runtime.InteropServices;

namespace Plugins.YandexGames.Runtime
{
    public class UserInternal
    {
        [DllImport("__Internal")]
        public static extern void AuthenticateUser();
        
        [DllImport("__Internal")]
        public static extern void GetUserData();

        [DllImport("__Internal")]
        public static extern void InitPurchases();

        [DllImport("__Internal")]
        public static extern void Purchase(string id);

        [DllImport("__Internal")]
        public static extern string GetLang();

        [DllImport("__Internal")]
        public static extern void Review();

        [DllImport("__Internal")]
        public static extern void SetLeaderBoard(int score);
    }
}