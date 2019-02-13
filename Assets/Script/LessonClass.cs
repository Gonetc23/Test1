using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonClass
{

    public string[] teacher;
    public string nameLesson;
    public int sumHour;
    public int dayHour;
    public int[] room;

    public LessonClass(string[] Teacher, string NameLesson, int SumHour, int DayHour, int[] Room)
    {
        teacher = Teacher;
        nameLesson = NameLesson;
        sumHour = SumHour;
        dayHour = DayHour;
        room = Room;
    }
}
