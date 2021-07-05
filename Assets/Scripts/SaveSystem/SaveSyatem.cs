using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using GlobalVariables;

public class SaveSyatem : MonoBehaviour
{
    public static SaveData data;

    public static void Save(SaveData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = File.Open(Paths.SAVEPATH, FileMode.OpenOrCreate))
        {
            bf.Serialize(fs, data);
        }
    }

    public static SaveData Load()
    {
        if (!File.Exists(Paths.SAVEPATH))
            throw new NullReferenceException("No savedata.dat file found");
        SaveData data;
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = File.Open(Paths.SAVEPATH, FileMode.Open))
        {
            data = (SaveData)bf.Deserialize(fs);
        }
        return data;
    }
}
