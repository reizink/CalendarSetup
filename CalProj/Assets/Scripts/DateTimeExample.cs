using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DateTimeExample : MonoBehaviour
{
    void Start()
    {
        DateTime now = DateTime.Now;
        Debug.Log("Current DateTime: " + now);

        DateTime curDate = DateTime.Today;
        TimeSpan curTime = now.TimeOfDay;
        Debug.Log("Current Date: " + curDate);
        Debug.Log("Current Time: " + curTime);

        DateTime futureDate = curDate.AddDays(4);
        TimeSpan pastTime = curTime.Subtract(new TimeSpan(2, 0, 0));

        string dateString = "2024-03-18 12:30:45";
        DateTime parsedTime;
        if(DateTime.TryParse(dateString, out parsedTime))
        {
            Debug.Log("Parsed Time: " +  parsedTime);
        }
        else
        {
            Debug.Log("Parsed time failed");
        }

        string formattedDate = now.ToString("yyyy-MM-dd HH:mm");
        Debug.Log("Formatted Date: " + formattedDate);

        DateTime day1 = new DateTime(2024, 3, 12);
        DateTime day2 = new DateTime(2024, 3, 20);
        int compareResults = DateTime.Compare(day1, day2);
        Debug.Log("Compared dates: " +  compareResults);
        TimeSpan dayDifference = day2 - day1;
        Debug.Log(" Difference between days:" + dayDifference);
    }

}
