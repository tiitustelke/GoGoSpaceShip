using System.Collections.Generic;

public class HighestScoreFirst : Comparer<PlayerInfo>
{
    public override int Compare(PlayerInfo x, PlayerInfo y)
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
