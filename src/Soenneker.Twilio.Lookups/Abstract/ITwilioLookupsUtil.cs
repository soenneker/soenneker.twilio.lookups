using Soenneker.Twilio.OpenApiClient.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Twilio.Lookups.Abstract;

/// <summary>
///  A utility library for Twilio lookup related operations
/// </summary>
public interface ITwilioLookupsUtil
{
    /// <summary>
    /// Fetches Twilio Lookup details for a phone number.
    /// </summary>
    ValueTask<Lookups_v1_phone_number?> GetPhoneNumber(string phoneNumber, string[]? types = null, string[]? addOns = null, string? countryCode = null,
        string? addOnsData = null, CancellationToken cancellationToken = default);
}
