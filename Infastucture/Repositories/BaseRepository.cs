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
            var token = _httpContextAccessor.HttpContext.Request.Cookies[Constants.XAccesstoken];

            if (!string.IsNullOrWhiteSpace(token))
                _flurlClient.WithOAuthBearerToken(token);
        }
    }
}