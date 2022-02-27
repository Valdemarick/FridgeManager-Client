using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;

namespace Infastucture.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IFlurlClient _flurlClient;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get(Constants.ApiUrl);

            _httpContextAccessor = httpContextAccessor;

            _flurlClient.BeforeCall(flurlCall =>
            {
                var token = _httpContextAccessor.HttpContext.Request.Cookies[Constants.XAccessToken];

                if (!string.IsNullOrWhiteSpace(token))
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", $"bearer {token}");
                else
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", string.Empty);
            });
        }
    }
}