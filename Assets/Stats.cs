using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    DataSaver dataSaver;

    // Start is called before the first frame update
    void Start()
    {
        dataSaver = new DataSaver();
        PlayerData data = dataSaver.ReadPlayerData();
        data.PlayerInfos.Add(new PlayerInfo());
        dataSaver.SavePlayerData(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
