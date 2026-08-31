using Soenneker.Twilio.OpenApiClient.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Twilio.Lookups.Abstract;

/// <summary>
/// Retrieves Twilio Lookup v1 data for phone numbers.
/// </summary>
public interface ITwilioLookupsUtil
{
    /// <summary>
    /// Retrieves data for a phone number from Twilio Lookup v1.
    /// </summary>
    /// <param name="phoneNumber">The phone number to look up. E.164 format is recommended.</param>
    /// <param name="types">Optional Twilio data packages to request, such as <c>carrier</c> or <c>caller-name</c>.</param>
    /// <param name="addOns">Optional Twilio Marketplace add-ons to invoke.</param>
    /// <param name="countryCode">The ISO country code to use when <paramref name="phoneNumber"/> is not in E.164 format.</param>
    /// <param name="addOnsData">Optional add-on-specific data.</param>
    /// <param name="cancellationToken">The token used to cancel the request.</param>
    /// <returns>The lookup response, or <see langword="null"/> when the API returns no response body.</returns>
    ValueTask<LookupsV1PhoneNumber?> GetPhoneNumber(string phoneNumber, string[]? types = null, string[]? addOns = null, string? countryCode = null,
        string? addOnsData = null, CancellationToken cancellationToken = default);
}
