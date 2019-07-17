using Microsoft.Extensions.Localization;

namespace WebApp.Helpers
{
    public class SharedResource : ISharedResource
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public SharedResource(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }
        public string Incorrect_Login => _localizer["Incorrect_Login"];

        public string Test => _localizer["Test"];
    }
}
