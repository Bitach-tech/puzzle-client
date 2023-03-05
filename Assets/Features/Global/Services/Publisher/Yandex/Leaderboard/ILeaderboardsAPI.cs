namespace Global.Publisher.Yandex.Leaderboard
{
    public interface ILeaderboardsAPI
    {
        void SetLeaderBoard_Internal(string target, int score);
    }
}