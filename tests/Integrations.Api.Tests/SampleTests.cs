namespace Integrations.Api.Tests;

public class SampleTests
{
    [Fact]
    public void Addition_ReturnsExpectedResult()
    {
        var result = 2 + 2;

        Assert.Equal(4, result);
    }

    [Fact]
    public void StringComparison_IgnoresCase()
    {
        var value = "Integrations.Api";

        Assert.Equal("integrations.api", value.ToLowerInvariant());
    }
}
