using System;
using System.IO;
using System.Xml.Serialization;

/// <summary>
/// The DataSaver class.
/// This class is responsible for reading and saving player scores.
/// </summary>
public class DataSaver
{
    private string path;
    private XmlSerializer serializer;

    /// <summary>
    /// Class constructor.
    /// </summary>
    public DataSaver()
    {
        this.path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "stats.xml");
        this.serializer = new XmlSerializer(typeof(PlayerData));
    }

    /// <summary>
    /// A method to read player data. Data is read from documents folder.
    /// </summary>
    /// See <see cref="PlayerData"/>.
    /// <returns>A PlayerData object.</returns>
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

    /// <summary>
    /// A method to save player data. The data will be written to an XML file located at user's documents.
    /// </summary>
    /// <param name="data"></param>
    public void SavePlayerData(PlayerData data)
    {
        using (FileStream stream = new FileStream(this.path, FileMode.Create))
        {
            this.serializer.Serialize(stream, data);
        }
    }
}
