using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Father
{

    /// <summary>
    /// рассчёт количества пар в день
    /// </summary>
    /// <param name="officeHours">колличество часов работы студентов</param>
    /// <returns>количество пар в день</returns>
    public static int[] Calculation(float officeHours)
    {
        int[] a = new int[2] { 0, 0 };
        float calculation = 0;
        calculation = (officeHours / 2);
        if (calculation % 5 != 0)
        {
           //Debug.Log(calculation / 5);
            a[1] = (int)Mathf.Ceil(calculation / 5);//в большую сторону
            a[0] = (int)Mathf.Floor(calculation / 5);//в меньш сторону 
        }
        else
        {
            a[0] = (int)calculation;
        }

        return a;
    }

    /// <summary>
    /// рассчёт каличества пар на всю неделю
    /// </summary>
    /// <param name="learn">варианты количества пар </param>
    /// <returns></returns>
    public static int[] AuteHelper3(float officeHours, int WarkDay)
    {
        int[] learn = Calculation(officeHours);
       
        int sum = 0;
        int[] A = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        while (sum != officeHours/2)
        {
            sum = 0;
            for (int i = 0; i < WarkDay; i++)
            {
                int R = Random.Range(0, learn.Length);
                A[i] = learn[R];
            }

            for (int i = 0; i < 5; i++)
            {
                sum += A[i];
            }
        }
        return A;

    }

    public static List<GroupClass> Groups = new List<GroupClass>
    {
         new GroupClass("КСК-316",7,new List<LessonClass>
             {
                 new LessonClass(new string[]{"Маштакова Р.А"},"Матан",3,1,new int[]{102}),
                 new LessonClass(new string[]{"Борисовна О.А","Сергей Борисович","Нет занятий"},"Физ-ра",3,1,new int[]{202,204,206}),
                 new LessonClass(new string[]{"Князев В.Ю" },"ППП",4,2,new int[]{212}),
                 new LessonClass(new string[]{"Алексеев А.С"},"Психология общения",4,2,new int[]{333}),
                 new LessonClass(new string[]{"Арифулин Ф.Н"},"Основы философии",4,2,new int[]{224})
             }),
         new GroupClass("КСК-316",7,new List<LessonClass>
             {
                 new LessonClass(new string[]{"Маштакова Р.А"},"Матан",3,1,new int[]{102}),
                 new LessonClass(new string[]{"Борисовна О.А","Сергей Борисович","Нет занятий"},"Физ-ра",3,1,new int[]{202,204,206}),
                 new LessonClass(new string[]{"Князев В.Ю" },"ППП",4,2,new int[]{212}),
                 new LessonClass(new string[]{"Алексеев А.С"},"Психология общения",4,2,new int[]{333}),
                 new LessonClass(new string[]{"Арифулин Ф.Н"},"Основы философии",4,2,new int[]{224})
             }),
    };
}
