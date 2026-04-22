using Soenneker.Twilio.Lookups.Abstract;
using Soenneker.Tests.HostedUnit;
using System.Threading.Tasks;
using Soenneker.Tests.Attributes.Local;
using Soenneker.Twilio.OpenApiClient.Models;

namespace Soenneker.Twilio.Lookups.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TwilioLookupsUtilTests : HostedUnitTest
{
    private const string _phoneNumber = "";
    private const string _nomoroboSpamScore = "";

    private readonly ITwilioLookupsUtil _util;

    public TwilioLookupsUtilTests(Host host) : base(host)
    {
        _util = Resolve<ITwilioLookupsUtil>(true);
    }

    [Test]
    public void Default()
    {
    }

    [LocalOnly]
    public async Task GetPhoneNumber_should_return_lookup_data()
    {
        var result = await _util.GetPhoneNumber(_phoneNumber, addOns: [_nomoroboSpamScore], cancellationToken: CancellationToken);

        Assert.NotNull(result);
        Assert.Equal(_phoneNumber, result!.PhoneNumber);
        Assert.NotNull(result.AddOns);
    }
}