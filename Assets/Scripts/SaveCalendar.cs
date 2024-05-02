using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveCalendar
{
    public static void CalendarSave()
    {
        CalendarStatus status = GameObject.FindGameObjectWithTag("CalendarManager").GetComponent<CalendarStatus>();

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + status.year.ToString() + ".save";
        FileStream stream = new FileStream(path, FileMode.Create);

        CalendarData calendarData = new CalendarData(status);

        formatter.Serialize(stream, calendarData);
        stream.Close();
    }

    public static CalendarData CalendarLoad(int year)
    {
        string path = Application.persistentDataPath + "/" + year.ToString() + ".save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CalendarData calendarData = formatter.Deserialize(stream) as CalendarData;

            stream.Close();
            return calendarData;
        }
        else
        {
            return null;
        }
    }
}
