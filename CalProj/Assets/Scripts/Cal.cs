using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cal : MonoBehaviour
{
    public DateTime curDate = DateTime.Now;
    private List<Day> days = new List<Day>();
    [SerializeField] private Transform[] weeks;
    [SerializeField] private TMP_Text MonthYr;
    [SerializeField] private TMP_Text currDateText;


    void Start()
    {
        UpdateCal(DateTime.Now.Year, DateTime.Now.Month);
        currDateText.text = DateTime.Now.ToString("yyyy-MM-dd");
    }

    private void UpdateCal(int year, int month)
    {
        DateTime tmp  = new DateTime(year, month, 1);
        curDate = tmp;
        MonthYr.text = tmp.ToString("MMMM") + " " + tmp.Year.ToString();

        int start = (int)tmp.DayOfWeek;
        int end = DateTime.DaysInMonth(year, month);

        if (days.Count == 0)
        {
            for (int i = 0; i < 6; i++) //wks
            {
                for (int j = 0; j < 7; j++) //days in a wk
                {
                    Day thisDay = weeks[i].GetChild(j).gameObject.AddComponent<Day>();

                    int currday = (i * 7) + j;

                    if(currday < start || currday - start >= end)
                    {
                        thisDay.Initialize(currday - start, Color.gray, weeks[i].GetChild(j).gameObject);
                    }
                    else
                    {
                        thisDay.Initialize(currday - start, Color.cyan, weeks[i].GetChild(j).gameObject);
                    }
                    days.Add(thisDay);
                }
            }
        }
        else
        {
            for (int i = 0; i < 42; i++)
            {
                if(i< start || i - start >= end)
                {
                    days[i].UpdateColor(Color.gray);
                }
                else
                {
                    days[i].UpdateColor(Color.cyan);
                }
                days[i].UpdateDay(i - start);
            }
        }

        if(DateTime.Now.Year == year && DateTime.Now.Month == month)
        {
            days[(DateTime.Now.Day -1) + start].UpdateColor(Color.green);
        }
    }

    public void MonthRight(bool dir)
    {
        if (dir)
        {
            curDate = curDate.AddMonths(1);
        }
        else
        {
            curDate = curDate.AddMonths(-1);
        }
        UpdateCal(curDate.Year, curDate.Month);
    }

}
