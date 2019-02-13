using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    
    public List<Test3ScheduleClass> Basa;

    public List<GroupClass> Groups = Father.Groups;



    public void CreateSchedule()
    {
        
    }

    public void BasaDate()
    {
        Basa = new List<Test3ScheduleClass>();
        for (int G = 0; G < Groups.Count; G++)
        {
            Basa.Add(new Test3ScheduleClass(Groups[G].Name,new PrefabLessen[Test3ScheduleClass.width,Test3ScheduleClass.height]));
            for (int i = 0; i < Test3ScheduleClass.width; i++)
            {
                for (int l = 0; l < Test3ScheduleClass.height ; l++)
                {
                    
                }
            }
        }
    }
    public void Test33()
    {
        for (int G = 0; G < Groups.Count; G++)
        {
            
        }
    }
}
