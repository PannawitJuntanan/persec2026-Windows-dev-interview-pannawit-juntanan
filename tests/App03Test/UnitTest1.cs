using Xunit;
using Xunit.Abstractions;
using App03;

namespace App03Test
{
    public class App03Test
    {
        private readonly ITestOutputHelper _output;
        public App03Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("th", new string[] { "Mother", "Think", "Worthy", "Apple", "Android" }, 2, new string[] { "Think", "Mother" })]
        [InlineData("a", new string[] { "Apple", "Banana", "Cat", "Area" }, 3, new string[] { "Apple", "Area", "Banana" })]
        public void Test_Autocomplete_Logic(string search, string[] items, int max, string[] expected)
        {
            // Act
            var result = Program.Autocomplete(search, items, max);

            // Print Result
            _output.WriteLine($"[Testing] items: '{items}'  , search : '{search}' , Max Result: {max}");
            _output.WriteLine($"[Result ] Expected: {expected}, Actual: {result}");
            _output.WriteLine("------------------------------------------");

            // Assert
            Assert.Equal(expected, result);
        }
    }
}