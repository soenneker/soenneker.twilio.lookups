[![](https://img.shields.io/nuget/v/soenneker.twilio.lookups.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.twilio.lookups/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.twilio.lookups/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.twilio.lookups/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.twilio.lookups.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.twilio.lookups/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.twilio.lookups/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.twilio.lookups/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Twilio.Lookups

Retrieves phone-number data from Twilio Lookup v1, including optional carrier, caller-name, and Marketplace add-on results.

## Installation

```bash
dotnet add package Soenneker.Twilio.Lookups
```

## Configuration

Add the Twilio credentials used by the underlying OpenAPI client:

```json
{
  "Twilio": {
    "AccountSid": "AC...",
    "AuthToken": "..."
  }
}
```

## Registration

```csharp
using Soenneker.Twilio.Lookups.Registrars;

services.AddTwilioLookupsUtilAsScoped();
```

Singleton registration is also available through `AddTwilioLookupsUtilAsSingleton()`.

## Usage

```csharp
using Soenneker.Twilio.Lookups.Abstract;
using Soenneker.Twilio.OpenApiClient.Models;

public sealed class PhoneInspector
{
    private readonly ITwilioLookupsUtil _lookups;

    public PhoneInspector(ITwilioLookupsUtil lookups)
    {
        _lookups = lookups;
    }

    public ValueTask<LookupsV1PhoneNumber?> GetCarrierData(
        string phoneNumber,
        CancellationToken cancellationToken)
    {
        return _lookups.GetPhoneNumber(
            phoneNumber,
            types: ["carrier"],
            cancellationToken: cancellationToken);
    }
}
```

Use E.164 numbers such as `+15551234567` when possible. For a national-format number, pass the ISO country code separately:

```csharp
LookupsV1PhoneNumber? result = await lookups.GetPhoneNumber(
    "020 7946 0018",
    countryCode: "GB",
    cancellationToken: cancellationToken);
```

`types` requests Twilio data packages. `addOns` invokes Twilio Marketplace add-ons, and `addOnsData` passes add-on-specific input. These options can have separate Twilio charges. API and authentication failures are propagated to the caller.
