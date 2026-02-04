using Xunit;
using Xunit.Abstractions;
using App01; 

namespace App01Test
{
    public class App01Test
    {
        private readonly ITestOutputHelper _output;
         
         // ประกาศเอาไว้ print ค่าออก
        public App01Test(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("{[()]}", true)]
        [InlineData("([{}])", true)]
        [InlineData("([{)", false)]
        [InlineData("(]", false)]
        [InlineData("([)]", false)]
        [InlineData("(((", false)]
        [InlineData("))", false)]
        [InlineData("", true)]
        public void Test_IsBalanced(string input, bool expected)
        {
            // Act
            bool result = Program.IsBalanced(input);

            // Print Result
            _output.WriteLine($"[Testing] Input: '{input}'");
            _output.WriteLine($"[Result ] Expected: {expected}, Actual: {result}");
            _output.WriteLine("------------------------------------------");

            // Assert
            Assert.Equal(expected, result);
        }
    }
}