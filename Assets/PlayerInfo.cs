using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// The PlayerInfo class.
/// Holds basic information of player, such as the current health and score.
/// </summary>
public class PlayerInfo
{
    /// <value>Indicates whether the story mode is enabled or not.</value>
    public static bool story = true;

    /// <value>Gets and sets the player score.</value>
    public static int score { get; set; }

    /// <value>Gets and sets the player level.</value>
    public static int level { get; set; }

    /// <value>Gets and sets the player health.</value>
    public static float health { get; set; }

    /// <value>Gets and sets the player pause status whether the the pause menu is active or not.</value>
    public static bool paused { get; set; }
}
