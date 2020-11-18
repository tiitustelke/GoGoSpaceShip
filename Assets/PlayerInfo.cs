using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerInfo
{
    public static int score { get; set; }

    public static int level { get; set; }

    public static float health { get; set; }

    public string Name;

    public int Score;

    public PlayerInfo()
    {
        Name = "Test";
        Score = score;
    }
}
