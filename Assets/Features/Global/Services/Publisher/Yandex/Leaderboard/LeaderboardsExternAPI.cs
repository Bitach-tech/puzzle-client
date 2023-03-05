using System.Runtime.InteropServices;

namespace Global.Publisher.Yandex.Leaderboard
{
    public class LeaderboardsExternAPI : ILeaderboardsAPI
    {
        [DllImport("__Internal")]
        private static extern void SetLeaderBoard(string target, int score);

        public void SetLeaderBoard_Internal(string target, int score)
        {
            SetLeaderBoard(target, score);
        }
    }
}