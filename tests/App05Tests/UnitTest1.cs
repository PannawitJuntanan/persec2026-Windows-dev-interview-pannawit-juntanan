namespace App05.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(42145, 54421)]
    [InlineData(145263, 654321)]
    [InlineData(123456789, 987654321)]
    [InlineData(5, 5)]       
    [InlineData(0, 0)]       
    [InlineData(999, 999)]   
    public void SortDigitsDesc_Correctly(int input, int expected)
    {
        // Act
        int result = Program.SortDigitsDescending(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SortDigitsDesc_WhenInputIsNegative()
    {
        // Arrange
        int input = -123;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
        {
            Program.SortDigitsDescending(input);
        });
    }

    [Fact]
    public void ortDigitsDesc_IfResultExceedsIntMax()
    {
        // เทสเกิน Max value ของ int 
        int input = 1999999999; 
        var result = Program.SortDigitsDescending(input);
        Assert.Equal(999999991, result);
    }
}
