using KataAlgorithms;

namespace KataAlgorithms.Tests;


public class LinearSearchTests
{
    private readonly int[] _testArray;

    public LinearSearchTests()
    {
        _testArray = new[] { 1, 3, 4, 69, 71, 81, 90, 99, 420, 1337, 69420 };
    }
    
    [Theory]
    [InlineData(69)]
    [InlineData(69420)]
    [InlineData(1)]
    public void WhenElementIsInArray_ShouldReturnTrue(int valueToSearch)
    {
        var actualResult = _testArray.LinearSearch(valueToSearch);
        
        Assert.Equal(valueToSearch, _testArray[actualResult]);
    }
    
    [Theory]
    [InlineData(1336)]
    [InlineData(69421)]
    [InlineData(0)]
    public void WhenElementIsNotInArray_ShouldReturnFalse(int valueToSearch)
    {
        var actualResult = _testArray.LinearSearch(valueToSearch);
        
        Assert.Throws<IndexOutOfRangeException>(() => _testArray[actualResult]);
    }

    [Fact]
    public void WhenArrayIsNull_ShouldThrowException()
    {
        int[]? array = null;
        var valueToSearch = 1;

        Assert.Throws<ArgumentNullException>(() => array.LinearSearch(valueToSearch));
    }
}