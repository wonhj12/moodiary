using UnityEngine;
using UnityEngine.UI;

public class DateElement : MonoBehaviour
{
    // UI
    public Image statusImg;
    public GameObject selectedImg;

    Setting setting;
    StatusManager statusManager;
    CalendarStatus calendarStatus;

    public int status = 0; // 0 - Default, 1 - Good, 1 - Bad
    public int year;
    public int month;
    public int day;

    void Awake()
    {
        setting = GameObject.FindGameObjectWithTag("Settings").GetComponent<Setting>();
        statusManager = GameObject.FindGameObjectWithTag("CalendarManager").GetComponent<StatusManager>();
        calendarStatus = GameObject.FindGameObjectWithTag("CalendarManager").GetComponent<CalendarStatus>();
    }

    // Set new status
    public void SetStatus(int stat)
    {
        status = stat;
        statusImg.color = setting.statusColors[status];
    }

    public void SaveStatus()
    {
        // Set calendar status
        calendarStatus.recordedDate[calendarStatus.index] = month * 100 + day;
        calendarStatus.recordedStatus.Add(status);
        calendarStatus.index++;
        calendarStatus.year = year;

        SaveCalendar.CalendarSave();
    }

    // Load Status
    public void LoadStatus()
    {
        for (int i = 0; i < 366; i++)
        {
            if (calendarStatus.recordedDate[i] == month * 100 + day)
            {
                status = calendarStatus.recordedStatus[i];
            }
        }

        SetStatus(status);
    }

    // Set status manager selectedDate to gameObject
    public void SelectDate()
    {
        selectedImg.SetActive(true);    // Show selected Img
        if (statusManager.selectedDate != null && statusManager.selectedDate != gameObject)
            statusManager.selectedDate.GetComponent<DateElement>().selectedImg.SetActive(false);   // Remove selected Img of current selected date
        statusManager.selectedDate = gameObject;    // Set selected date
        statusManager.RefreshStatus();
    }

    // Settings for today
    public void Today()
    {
        Text date = GetComponentInChildren<Text>();
        date.fontSize = 56;
        date.color = new Color32(123, 166, 227, 225);   // #7BA6E3
    }

    // Settings for future days
    public void Future()
    {
        Text date = GetComponentInChildren<Text>();
        date.color = new Color32(186, 186, 186, 255); // #BABABA
    }
}
