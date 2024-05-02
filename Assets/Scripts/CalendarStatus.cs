using System.Collections.Generic;
using UnityEngine;

public class CalendarStatus : MonoBehaviour
{
    public int[] recordedDate = new int[366];
    public List<int> recordedStatus = new List<int>();
    public int index;
    public int year;

    public void LoadCalendarData(CalendarData data, int defaultYear)
    {
        if (data != null)
        {
            recordedDate = data.recordedDate;
            recordedStatus = data.recordedStatus;
            index = data.index;
            year = data.index;
        }
        else
        {
            recordedDate = new int[366];
            recordedStatus = new List<int>();
            index = 0;
            year = defaultYear;
        }
    }
}
