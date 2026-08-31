using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Twilio.Lookups.Abstract;
using Soenneker.Twilio.OpenApiClientUtil.Registrars;

namespace Soenneker.Twilio.Lookups.Registrars;

/// <summary>
/// Registers services that retrieve Twilio Lookup v1 phone-number data.
/// </summary>
public static class TwilioLookupsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ITwilioLookupsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddTwilioLookupsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddTwilioOpenApiClientUtilAsSingleton()
                .TryAddSingleton<ITwilioLookupsUtil, TwilioLookupsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ITwilioLookupsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddTwilioLookupsUtilAsScoped(this IServiceCollection services)
    {
        services.AddTwilioOpenApiClientUtilAsScoped()
                .TryAddScoped<ITwilioLookupsUtil, TwilioLookupsUtil>();

        return services;
    }
}
