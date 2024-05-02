using System;
using UnityEngine;

public class CalendarManager : MonoBehaviour
{
    DateTime targetDateTime;

    public StatusManager statusManager;
    public DatesCreator datesCreator;
    public CalendarStatus calendarStatus;

    void Start()
    {
        targetDateTime = DateTime.Now;
        RefreshCalendar(targetDateTime.Year, targetDateTime.Month); // Initialize calendar
    }

    // Refresh calendar
    void RefreshCalendar(int year, int month)
    {
        // Load calendar data
        CalendarData calendarData = SaveCalendar.CalendarLoad(year);
        calendarStatus.LoadCalendarData(calendarData, year);

        datesCreator.CreateDates(year, month);

        statusManager.RefreshStatus();
    }

    // Change the month of the calendar
    public void ChangeMonth(int val)
    {
        targetDateTime = targetDateTime.AddMonths(val);
        RefreshCalendar(targetDateTime.Year, targetDateTime.Month);
    }
}
