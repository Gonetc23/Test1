using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3ScheduleClass
{
    public string nameGroup;
    public const int width=7;
    public const int height = 6;
    public PrefabLessen[,] schedule;
   


    public Test3ScheduleClass(string NameGroup, PrefabLessen[,] Scheduile)
    {
        nameGroup = NameGroup;
        schedule = Scheduile;
    }
}
