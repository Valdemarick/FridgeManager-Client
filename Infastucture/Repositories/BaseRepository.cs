using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;

namespace Infastucture.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IFlurlClient flurlClient;
        protected readonly IHttpContextAccessor httpContextAccessor;

        public BaseRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            flurlClient = flurlClientFactory.Get(Constants.ApiUrl);

            this.httpContextAccessor = httpContextAccessor;

            flurlClient.BeforeCall(flurlCall =>
            {
                var token = this.httpContextAccessor.HttpContext.Request.Cookies[Constants.XAccessToken];

                if (!string.IsNullOrWhiteSpace(token))
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", $"bearer {token}");
                else
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", string.Empty);
            });
        }
    }
}