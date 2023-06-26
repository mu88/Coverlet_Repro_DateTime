using BusinessLogic;
using FluentAssertions;
using FluentAssertions.Extensions;

namespace TestSuite;

public class UnitTest1
{
    [Fact]
    public void Descending()
    {
        // Arrange
        var testee = new Service();
        
        // Act
        var results = testee.Descending(new []{new Dto(12.April(1953)), new Dto(14.April(1953))});

        // Assert
        results.Should().BeInDescendingOrder();
    }
}