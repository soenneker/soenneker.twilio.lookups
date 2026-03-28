using Soenneker.Twilio.Lookups.Abstract;
using Soenneker.Tests.FixturedUnit;
using System.Threading.Tasks;
using Soenneker.Facts.Local;
using Soenneker.Twilio.OpenApiClient.Models;
using Xunit;

namespace Soenneker.Twilio.Lookups.Tests;

[Collection("Collection")]
public sealed class TwilioLookupsUtilTests : FixturedUnitTest
{
    private const string _phoneNumber = "";
    private const string _nomoroboSpamScore = "";

    private readonly ITwilioLookupsUtil _util;

    public TwilioLookupsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ITwilioLookupsUtil>(true);
    }

    [Fact]
    public void Default()
    {
    }

    [LocalFact]
    public async Task GetPhoneNumber_should_return_lookup_data()
    {
        Lookups_v1_phone_number? result = await _util.GetPhoneNumber(_phoneNumber, addOns: [_nomoroboSpamScore], cancellationToken: CancellationToken);

        Assert.NotNull(result);
        Assert.Equal(_phoneNumber, result!.PhoneNumber);
        Assert.NotNull(result.AddOns);
    }
}