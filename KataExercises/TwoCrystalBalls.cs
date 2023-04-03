namespace KataExercises;

public class TwoCrystalBalls
{
    private readonly bool[] _breaksMask;
    
    private TwoCrystalBalls(bool[] breaksMask)
    {
        _breaksMask = breaksMask;
    }

    public static TwoCrystalBalls CreateFromMask(bool[]? breaksMask)
    {
        ArgumentNullException.ThrowIfNull(breaksMask);

        return new TwoCrystalBalls(breaksMask);
    }
    
    public int Solve()
    {
        var step = (int) Math.Sqrt(_breaksMask.Length);
        var i = step;
        while (i < _breaksMask.Length)
        {
            if (_breaksMask[i])
            {
                break;
            }

            i += step;
        }

        i -= step;

        for (var j = 0; j < step && i < _breaksMask.Length; ++j, ++i)
        {
            if (_breaksMask[i])
            {
                return i;
            }
        }

        return -1;
    }
}