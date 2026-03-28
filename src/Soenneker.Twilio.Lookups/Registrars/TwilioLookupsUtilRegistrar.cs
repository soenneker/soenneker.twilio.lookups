using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Twilio.Lookups.Abstract;
using Soenneker.Twilio.OpenApiClientUtil.Registrars;

namespace Soenneker.Twilio.Lookups.Registrars;

/// <summary>
///  A utility library for Twilio lookup related operations
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
