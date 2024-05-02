[System.Serializable]
public class SettingData
{
    public int goodIndex;
    public int badIndex;

    public SettingData(int good, int bad)
    {
        goodIndex = good;
        badIndex = bad;
    }
}
