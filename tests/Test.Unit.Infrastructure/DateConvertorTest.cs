using FluentAssertions;
using Infrastructure.Convertor;

namespace Test.Unit.Infrastructure;

public class DateConvertorTest
{
    [Fact]
    public void Should_1374_09_19_When_1995_12_10()
    {
        var date = new DateTime(1995, 12, 10);

        var result = date.ToShamsi();

        result.Should().Be("1374/09/19");
    }
}