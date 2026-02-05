using Xunit;
using App04;

namespace App04.Tests;

public class App04Tests
{
   
    [Theory]
    [InlineData("1", "I")]
    [InlineData("3", "III")]
    [InlineData("4", "IV")]
    [InlineData("9", "IX")]
    [InlineData("58", "LVIII")]
    [InlineData("1994", "MCMXCIV")]
    [InlineData("3999", "MMMCMXCIX")]
    public void Test_ConvertRoman_WhenInputIsNumber(string input, string expected)
    {
        // Act
        var result = Program.ConvertRomanOrNumber(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("I", "1")] // Result ของฟังก์ชันน้องคืนค่าเป็น String ตาม Logic เก่า
    [InlineData("IV", "4")]
    [InlineData("IX", "9")]
    [InlineData("LVIII", "58")]
    [InlineData("MCMXCIV", "1994")]
    public void Test_ConvertRoman_WhenInputIsRoman(string input, string expected)
    {
        // Act
        var result = Program.ConvertRomanOrNumber(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("-1")]
    [InlineData("-100")]
    public void Test_ConvertRoman_WhenInputIsNonPositiveInteger(string input)
    {
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
        {
            Program.ConvertRomanOrNumber(input);
        });
    }

    [Fact]
    public void Test_ConvertRoman_WhenInputIsInvalidRomanChar()
    {
        // Arrange
        string input = "ABC"; 

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
        {
            Program.ConvertRomanOrNumber(input);
        });
    }
}
