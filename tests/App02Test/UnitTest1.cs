namespace App02Test;

public class App02Test
{
    private readonly ITestOutputHelper _output;

    public App02Test(ITestOutputHelper output)
    {
        _output = output;
    }

    [Theory]
    [MemberData(nameof(GetSortingData))]
    public void Test_Sort(string[] input, string[] expected)
    {
        // Act
        var result = StringSorter.ManualNaturalSort(input);
        // Print Result
        _output.WriteLine($"Input:  [{string.Join(", ", input)}]");
        _output.WriteLine($"Result: [{string.Join(", ", result)}]");
        _output.WriteLine($"Expected: [{string.Join(", ", expected)}]");
        
        // Assert
        Assert.Equal(expected, result);
    }
    public static IEnumerable<object[]> GetSortingData()
    {
        yield return new object[]
        {
                new string[] { "TH19", "SG20", "TH2" },
                new string[] { "SG20", "TH2", "TH19" }
        };
        yield return new object[]
        {
                new string[] { "TH10", "TH3Netflix", "TH1", "TH7" },
                new string[] { "TH1", "TH3Netflix", "TH7", "TH10" }
        };
    }
}
