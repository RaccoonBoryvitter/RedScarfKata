namespace KataExercises.Tests;

public class TwoCrystalBallsTests
{
    [Theory]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(10000)]
    public void GivenBreaksMask_ReturnsPosition(int arraySize)
    {
        // Arrange
        var expectedIndex = Random.Shared.Next(0, arraySize);
        var breaksMask = CreateBreaksMask(arraySize, expectedIndex);
        var solver = TwoCrystalBalls.CreateFromMask(breaksMask);

        // Act
        var actualIndex = solver.Solve();

        // Assert
        Assert.Equal(expectedIndex, actualIndex);
    }

    private static bool[] CreateBreaksMask(int arraySize, int index)
    {
        var breaksMask = Enumerable.Repeat(false, arraySize).ToArray();
        for (var i = index; i < arraySize; ++i)
        {
            breaksMask[i] = true;
        }

        return breaksMask;
    }
}