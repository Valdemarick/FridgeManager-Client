using Domain.Common;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;

namespace Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IFlurlClient FlurlClient;
        protected readonly IHttpContextAccessor HttpContextAccessor;

        public BaseRepository(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            FlurlClient = flurlClientFactory.Get(Constants.ApiUrl);

            this.HttpContextAccessor = httpContextAccessor;

            FlurlClient.BeforeCall(flurlCall =>
            {
                var token = this.HttpContextAccessor.HttpContext.Request.Cookies[Constants.XAccessToken];

                if (!string.IsNullOrWhiteSpace(token))
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", $"bearer {token}");
                else
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", string.Empty);
            });
        }
    }
}