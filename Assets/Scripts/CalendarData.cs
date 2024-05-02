using System.Collections.Generic;

[System.Serializable]
public class CalendarData
{
    public int[] recordedDate;
    public List<int> recordedStatus;
    public int index;
    public int year;

    public CalendarData(CalendarStatus status)
    {
        recordedDate = status.recordedDate;
        recordedStatus = status.recordedStatus;
        index = status.index;
        year = status.index;
    }
}
