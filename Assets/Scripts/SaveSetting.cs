using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSetting
{
    public static void SettingSave(int good, int bad)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/setting.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        SettingData settingData = new SettingData(good, bad);

        formatter.Serialize(stream, settingData);
        stream.Close();
    }

    public static SettingData SettingLoad()
    {
        string path = Application.persistentDataPath + "/setting.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SettingData settingData = formatter.Deserialize(stream) as SettingData;

            stream.Close();
            return settingData;
        }
        else
        {
            return null;
        }
    }
}
