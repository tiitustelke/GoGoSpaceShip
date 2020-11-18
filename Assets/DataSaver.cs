using System;
using System.IO;
using System.Xml.Serialization;

public class DataSaver
{
    private string path;
    private XmlSerializer serializer;

    public DataSaver()
    {
        this.path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "stats.xml");
        this.serializer = new XmlSerializer(typeof(PlayerData));
    }

    public PlayerData ReadPlayerData()
    {
        PlayerData playerData = new PlayerData();
        try
        {
            using (FileStream stream = new FileStream(this.path, FileMode.Open))
            {
                playerData = (PlayerData)this.serializer.Deserialize(stream);
            }
            return playerData;
        }
        catch
        {
            return new PlayerData();
        }
        
    }

    public void SavePlayerData(PlayerData data)
    {
        using (FileStream stream = new FileStream(this.path, FileMode.Create))
        {
            this.serializer.Serialize(stream, data);
        }
    }
}
