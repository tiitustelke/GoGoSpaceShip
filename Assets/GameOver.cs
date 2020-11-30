using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The GameOver class.
/// Responsible for handling the given player name to scoreboards.
/// </summary>
public class GameOver : MonoBehaviour
{
    InputField playerName;
   
    void Start()
    {
        playerName = GameObject.Find("UserInput").GetComponent<InputField>();
        
    }

    /// <summary>
    /// When player presses enter while the input field is active, the data will be saved with the given name.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerName.enabled && playerName.text.Length > 0)
        {
            DataSaver dataSaver = new DataSaver();
            PlayerData playerData = dataSaver.ReadPlayerData();
            Info info = new Info();
            info.Score = PlayerInfo.score;
            info.Name = playerName.text;
            playerData.PlayerInfos.Add(info);
            dataSaver.SavePlayerData(playerData);
            playerName.enabled = false;
        }
    }
}
