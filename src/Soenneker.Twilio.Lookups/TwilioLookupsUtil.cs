using Soenneker.Twilio.Lookups.Abstract;
using Soenneker.Twilio.OpenApiClient.Models;
using Soenneker.Twilio.OpenApiClientUtil.Abstract;
using System;
using System.Threading;
using Soenneker.Extensions.String;
using System.Threading.Tasks;
using Soenneker.Extensions.Task;
using Soenneker.Twilio.OpenApiClient;

namespace Soenneker.Twilio.Lookups;

/// <inheritdoc cref="ITwilioLookupsUtil"/>
public sealed class TwilioLookupsUtil: ITwilioLookupsUtil
{
    private const string _lookupsBaseUrl = "https://lookups.twilio.com/v1/PhoneNumbers/";

    private readonly ITwilioOpenApiClientUtil _twilioOpenApiClientUtil;

    public TwilioLookupsUtil(ITwilioOpenApiClientUtil twilioOpenApiClientUtil)
    {
        _twilioOpenApiClientUtil = twilioOpenApiClientUtil;
    }

    public async ValueTask<Lookups_v1_phone_number?> GetPhoneNumber(string phoneNumber, string[]? types = null, string[]? addOns = null, string? countryCode = null,
        string? addOnsData = null, CancellationToken cancellationToken = default)
    {
        if (phoneNumber.IsNullOrWhiteSpace())
            throw new ArgumentException("Phone number cannot be null or whitespace.", nameof(phoneNumber));

        TwilioOpenApiClient client = await _twilioOpenApiClientUtil.Get(cancellationToken);

        var rawUrl = $"{_lookupsBaseUrl}{Uri.EscapeDataString(phoneNumber)}";

        return await client.Twilio_lookups_v1
            .V1
            .PhoneNumbers[phoneNumber]
            .WithUrl(rawUrl)
            .GetAsync(config =>
            {
                config.QueryParameters = new()
                {
                    AddOns = addOns,
                    AddOnsData = addOnsData,
                    CountryCode = countryCode,
                    Type = types
                };
            }, cancellationToken).NoSync();
    }
}
