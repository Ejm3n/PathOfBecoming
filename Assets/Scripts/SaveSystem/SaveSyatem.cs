using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GlobalVariables;

public static class SaveSyatem
{
    public static GameSettings gameSettings
    {
        get
        {
            try
            {
                return Load_Settings();
            }
            catch (NullReferenceException)
            {
                return new GameSettings();
            }
        }
        set
        {
            value.Save();
        }
    }

    public static void Save(this SaveData data)
    {
        data.Save(Paths.SAVEDATAPATH);
    }

    public static SaveData Load_Data()
    {
        return Load<SaveData>(Paths.SAVEDATAPATH);
    }

    public static void Save(this GameSettings data)
    {
        data.Save(Paths.GAMEDATAPATH);
    }

    public static GameSettings Load_Settings()
    {
        return Load<GameSettings>(Paths.GAMEDATAPATH);
    }

    static void Save<T>(this T data, string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = File.Open(path, FileMode.OpenOrCreate))
        {
            bf.Serialize(fs, data);
        }
    }

    static T Load<T>(string path)
    {
        if (!File.Exists(path))
            throw new NullReferenceException("No .dat file found");
        T data;
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = File.Open(path, FileMode.Open))
        {
            data = (T)bf.Deserialize(fs);
        }
        return data;
    }
}
