using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace TailSpin.SpaceGame.Web
{
    public class LeaderboardFunctionClient : ILeaderboardServiceClient
    {
        private string _functionUrl;

        public LeaderboardFunctionClient(string functionUrl)
        {
            this._functionUrl = functionUrl;
        }

        async public Task<LeaderboardResponse> GetLeaderboard(int page, int pageSize, string mode, string region)
        {
            using (HttpClient webClient = new HttpClient())
            {
                string json = await webClient.GetStringAsync($"{this._functionUrl}?page={page}&pageSize={pageSize}&mode={mode}&region={region}");                
                return JsonSerializer.Deserialize<LeaderboardResponse>(json);
            }
        }
    }
}
