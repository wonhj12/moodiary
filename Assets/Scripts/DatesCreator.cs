using System;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatesCreator : MonoBehaviour
{
    // Date elements
    public GameObject datePref;
    public GameObject dateEmptyPref;
    List<GameObject> datesList;

    bool thisMonth = false;

    // UI
    public GameObject bar6;
    public GameObject bar7;
    public GridLayoutGroup barGrid;
    public GridLayoutGroup calendarGrid;
    public Text titleText;

    public string yearStr;
    public string cultureStr;

    public void CreateDates(int year, int month)
    {
        DateTime dateTime = new DateTime(year, month, 1);
        CultureInfo cultureInfo = new CultureInfo(cultureStr);
        int daysInMonth = DateTime.DaysInMonth(year, month);    // Number of days in month
        int dayOfWeek = (int)dateTime.DayOfWeek;    // First day of the month
        thisMonth = (month == DateTime.Now.Month);  // Check if it is this month

        // Find how many weeks in the month
        int numWeek = (dayOfWeek + daysInMonth) / 7;
        if ((dayOfWeek + daysInMonth) % 7 > 0)
            numWeek++;

        // UI Settings based on num of week
        calendarGrid.spacing = new Vector2(0, (1498 - (calendarGrid.cellSize.y * numWeek)) / numWeek);  // Set calendarGrid spacing
        bar6.GetComponent<Image>().color = new Color(1, 1, 1, (float)(numWeek % 5));    // Bar6 is invisible when numWeek is 5
        bar7.SetActive(numWeek == 6);   // Only activate bar7 when numWeek is 6
        barGrid.spacing = new Vector2(0, (1498 - (barGrid.cellSize.y * numWeek)) / numWeek);    // Set barGrid spacing
        titleText.text = (year + yearStr + " " + cultureInfo.DateTimeFormat.GetMonthName(month)); //(month.ToString() + " 월");  // Set month text

        // Initialize date elements
        int[] dateElements = new int[numWeek * 7];  // Empty = 0, else = day
        for (int i = 0; i < daysInMonth; i++)
            dateElements[dayOfWeek + i] = i + 1;

        // Initialize dates list
        if (datesList == null)
            datesList = new List<GameObject>();
        foreach (GameObject day in datesList)
            Destroy(day);
        datesList.Clear();

        // Create date elements
        foreach (int day in dateElements)
        {
            GameObject temp = Instantiate(day == 0 ? dateEmptyPref : datePref, transform);   // Create date element
            if (day != 0)   // If day
            {
                temp.GetComponentInChildren<Text>().text = day.ToString();  // Set date text
                temp.name = day.ToString(); // Set gameObject name

                // Set dateElement
                temp.GetComponent<DateElement>().year = year;
                temp.GetComponent<DateElement>().month = month;
                temp.GetComponent<DateElement>().day = day;
                temp.GetComponent<DateElement>().LoadStatus();

                if (day == DateTime.Now.Day && month == DateTime.Now.Month && year == DateTime.Now.Year) // If today
                    temp.GetComponent<DateElement>().Today();   // Set to today
                if (year * 10000 + month * 100 + day > DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day) // If future 20201012
                    temp.GetComponent<DateElement>().Future();  // Set to future
            }
            datesList.Add(temp);    // Add to datesList
        }

        // Initial selected date
        if (thisMonth)
            datesList[dayOfWeek + DateTime.Now.Day - 1].GetComponent<Button>().onClick.Invoke();
        else
            datesList[dayOfWeek].GetComponent<Button>().onClick.Invoke();
    }
}
