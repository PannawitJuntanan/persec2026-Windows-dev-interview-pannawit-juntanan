namespace App06.Tests;

public class UnitTest1
{
   [Fact]
    public void Tribonacci_ShouldWorkWithStandardInput()
    {
        // Arrange
        int[] arr = { 1, 1, 1 };
        int n = 10;
        int[] expected = { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105 };

        // Act
        int[] result = Program.Tribonacci(arr, n);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Tribonacci_ShouldHandleShortArray()
    {
        // Arrange
        int[] arr = { 1 }; // มีแค่ตัวเดียว
        int n = 5;
        // Logic: 
        // i=0: 1
        // i=1: 0+0+1 = 1
        // i=2: 0+1+1 = 2
        // i=3: 1+1+2 = 4
        // i=4: 1+2+4 = 7
        int[] expected = { 1, 1, 2, 4, 7 };

        // Act
        int[] result = Program.Tribonacci(arr, n);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Tribonacci_ShouldHandleEmptyArray()
    {
        // Arrange
        int[] arr = { }; 
        int n = 5;
        int[] expected = { 0, 0, 0, 0, 0 };

        // Act
        int[] result = Program.Tribonacci(arr, n);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Tribonacci_WhenNIsLessThanArray()
    {
        // Arrange
        int[] arr = { 10, 20, 30, 40 };
        int n = 2; 
        int[] expected = { 10, 20 };

        // Act
        int[] result = Program.Tribonacci(arr, n);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Tribonacci_WhenNIsZero()
    {
        // Arrange
        int[] arr = { 1, 2, 3 };
        int n = 0;

        // Act
        int[] result = Program.Tribonacci(arr, n);

        // Assert
        Assert.Empty(result);
    }
}
