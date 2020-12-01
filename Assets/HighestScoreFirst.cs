using System.Collections.Generic;

public class HighestScoreFirst : Comparer<Info>
{
    public override int Compare(Info x, Info y)
    {
        if (x.Score > y.Score)
        {
            return -1;
        }
        else if (x.Score < y.Score)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
