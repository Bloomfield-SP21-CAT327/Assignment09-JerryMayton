using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad
{
    public static void Save(Player player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + 
        Path.DirectorySeparatorChar  + "savedGames.gd");
        PlayerData data = new PlayerData(player);
        bf.Serialize(file, data);
        file.Close();
    }

    public static PlayerData Load()
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + 
            "savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar 
                + "savedGames.gd", FileMode.Open);
            PlayerData data = bf.Deserialize(file) as PlayerData;
            file.Close();

            return data;
        }
        else
        {
            return null;
        }
    }

    
}
