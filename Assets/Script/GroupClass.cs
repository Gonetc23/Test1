using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupClass 
{
    public string Name;//название группы 
    //public int[] OfficeHoursArray=new int[7] ;
    public List<LessonClass> Lessons;
    
    public GroupClass(string name,int OfficeHours,List<LessonClass> lessons)
    {
        Name = name;
        Lessons = lessons;
    }

}
