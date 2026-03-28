using Soenneker.Twilio.Lookups.Abstract;
using Soenneker.Tests.FixturedUnit;
using System.Threading.Tasks;
using Xunit;

namespace Soenneker.Twilio.Lookups.Tests;

[Collection("Collection")]
public sealed class TwilioLookupsUtilTests : FixturedUnitTest
{
    private readonly ITwilioLookupsUtil _util;

    public TwilioLookupsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ITwilioLookupsUtil>(true);
    }

    [Fact]
    public void Default()
    { 
    }
}
