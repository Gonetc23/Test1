using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    public int width;
    public int height;
    public float offSetX;
    public float offSetY;

    public GameObject[,] AllTest1;
    public GameObject[,] AllTest2;

    public GameObject PrefText;

    public int OfficeHours=18;

    public int[] OfficeHoursArray = new int[7] {0,0,0,0,0,0,0 };

    private int RepetitionCounter=0;

    private LessonClass[] Lessons = new LessonClass[]
    {
        new LessonClass(new string[]{"Маштакова"},"Матан",3,1,new int[]{102}),
         new LessonClass(new string[]{"Ольга Борисовна","Сергей Борисович","Нет занятий"},"Физ-ра",3,1,new int[]{202,204,206}),
         new LessonClass(new string[]{"Князев" },"ППП",4,2,new int[]{212}),
         new LessonClass(new string[]{"Алексеев А.С"},"Психология общения",4,2,new int[]{333}),
         new LessonClass(new string[]{"Арифулин Ф.Н"},"Основы философии",4,2,new int[]{224})
    };

    private void Start()
    {
        AllTest1 = new GameObject[width, height];
        CreateMatris();
        OfficeHoursArray = Father.AuteHelper3(36,5);
        AutoTest1();
        //AuteHelper5();
        gameObject.transform.localPosition = new Vector3(-500, 80, 0);

        //foreach (var item in OfficeHoursArray)
        //{
        //    Debug.Log(item);
        //}
    }

    private void CreateMatris()
    {
        
        for (int i = 0; i < width; i++)
        {
            for (int l = 0; l < height; l++)
            {
                CreateHelper(i,l);
            }
        }

    }

    private void CreateHelper(int x ,int y)
    {
        Vector3 pos = new Vector3(x*offSetX,-y*offSetY,50);
        GameObject Obj = Instantiate(PrefText, pos, Quaternion.identity);
        Obj.transform.parent = gameObject.transform;
        Obj.transform.position = pos;
        Obj.transform.localScale = new Vector3(1, 1, 1);
        Obj.name = "Точка ( " + x + " , " + y + " )";
        AllTest1[x, y] = Obj;
    }

    private void AutoTest1()
    {
        
        for (int i = 0; i < width; i++)
        {
            for (int l = 0; l < height; l++)
            {
                int testhelper1 = 0;
                int L = Random.Range(0, Lessons.Length);
                while (AuteHelper1(i, l, L) == false && testhelper1 < 100)
                {
                    L = Random.Range(0, Lessons.Length);
                    testhelper1++;
                }
                testhelper1 = 0;

                if (AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().lesonName == "")//разрешение заполнять пустые поля
                {
                    //  Debug.Log("3");
                    if (AuteHelper2(Lessons[L].nameLesson, i) < Lessons[L].dayHour)//часы одного предмета в день в день
                    {
                        // Debug.LogError(AuteHelper4("", i));
                        if (AuteHelper4("", i) < OfficeHoursArray[i])//часы в день
                        {
                            if (AuteHelper(Lessons[L].nameLesson) < Lessons[L].sumHour)//часы в неделю
                            {
                                AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().lesonName = Lessons[L].nameLesson;
                                AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().techer = Lessons[L].teacher[0];
                                AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().room = Lessons[L].room[0];
                                AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().column = i;
                                AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().row = l;
                                AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().L = L;
                                AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().Tech = 0;

                            }
                            else
                            {
                                AllTest1[i, l].gameObject.GetComponentInChildren<Text>().text = "";
                            }
                        }
                        else
                        {
                            AllTest1[i, l].gameObject.GetComponentInChildren<Text>().text = "";
                        }
                    }
                    else
                    {
                        
                    }
                }
            }
        }
        //AuteHelper5();
    }

    private bool AuteHelper1(int i,int l,int L)
    {
       
        if (AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().lesonName == "")
        {
           // Debug.Log("3");
            if (AuteHelper2(Lessons[L].nameLesson, i) < Lessons[L].dayHour)
            {
                //   Debug.Log("2");
                if (AuteHelper4("", i) < OfficeHoursArray[i])//часы в день
                {
                    
                    if (AuteHelper(Lessons[L].nameLesson) < Lessons[L].sumHour)//часы в неделю
                    {
                        AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().lesonName = Lessons[L].nameLesson;
                        AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().techer = Lessons[L].teacher[0];
                        AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().room = Lessons[L].room[0];
                        AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().column = i;
                        AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().row = l;
                        AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().L = L;
                        AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().Tech = 0;
                        AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().ro = 0;
                    }
                    else
                    {
                        AllTest1[i, l].gameObject.GetComponentInChildren<Text>().text = "";
                    }
                }
                else
                {
                    AllTest1[i, l].gameObject.GetComponentInChildren<Text>().text = "";
                }
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    /// <summary>
    /// проверка , количества уроков в неделю
    /// </summary>
    /// <param name="st">название предмета</param>
    /// <returns></returns>
    private int AuteHelper(string st)
    {
        int a=0;
        for (int i = 0; i < width; i++)
        {
            for (int l = 0; l < height; l++)
            {
                if (AllTest1[i, l].gameObject.GetComponent<PrefabLessen>().lesonName == st)
                {
                    a++;
                }
            }
        }
        return a;
    }

    private void AuteHelper5()
    {
       
        int a = 0;
        for (int i = 0; i < width; i++)
        {
            for (int l = 0; l < height; l++)
            {
                if (AllTest1[i,l].gameObject.GetComponent<PrefabLessen>().room!=0)
                {
                    a++;
                }
            }
        }
       
        if (a < OfficeHours && RepetitionCounter<50)
        {
            AutoTest1();
            Debug.LogError("Работаю " + RepetitionCounter);
        }
        else if (RepetitionCounter>=50)
        {
            Debug.LogError("Устал "+ RepetitionCounter);
        }
        Debug.LogError("test " + a);
        RepetitionCounter++;

    }

    /// <summary>
    /// проверка наличие одного предмета в день 
    /// </summary>
    /// <param name="st">название предмета</param>
    /// <param name="column">день</param>
    /// <returns></returns>
    private int AuteHelper2(string st, int column)
    {
        int a = 0;

        for (int l = 0; l < height; l++)
        {
            if (AllTest1[column, l].gameObject.GetComponent<PrefabLessen>().lesonName == st)
            {
                a++;
            }
        }
     
        return a;
    }

    /// <summary>
    /// проверка на количество предметов в день
    /// </summary>
    /// <param name="st">название предмета</param>
    /// <param name="column">день</param>
    /// <returns></returns>
    private int AuteHelper4(string st, int column)
    {
        int a = 0;

        for (int l = 0; l < height; l++)
        {
            if (AllTest1[column, l].gameObject.GetComponent<PrefabLessen>().lesonName != st)
            {
                a++;
            }
        }

        return a;
    }

    /// <summary>
    /// рассчёт количества пар в день
    /// </summary>
    /// <param name="officeHours">колличество часов работы студентов</param>
    /// <returns>количество пар в день</returns>
    private int[] Calculation(float officeHours)
    {
        int[] a = new int[2] {0,0 };
        float calculation = 0;
        calculation = (officeHours / 2);
        if (calculation % 5 != 0)
        {
            Debug.Log(calculation / 5);
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
    private int[] AuteHelper3(float officeHours)
    {
        int[] learn=Calculation(officeHours);
        //foreach (var item in learn)
        //{
        //    Debug.Log(item);
        //}
       
        int sum = 0;
        int[] A = new int[7] { 0,0,0,0,0,0,0};
        while (sum != OfficeHours)
        {
            sum = 0;
           // Debug.LogError("Ахуенная прблема !");

            for (int i = 0; i < 5; i++)
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

    /// <summary>
    /// Замена преподователя
    /// </summary>
    /// <param name="dot"></param>
    public void TeacherReplacement(GameObject dot)
    {
        PrefabLessen lesen = dot.gameObject.GetComponent<PrefabLessen>();
        if (lesen.Tech+1< Lessons[lesen.L].teacher.Length)
        {
            AllTest1[lesen.column, lesen.row].GetComponent<PrefabLessen>().techer = Lessons[lesen.L].teacher[lesen.Tech + 1];
            AllTest1[lesen.column, lesen.row].GetComponent<PrefabLessen>().Tech = lesen.Tech + 1;
        }
        else if (lesen.Tech + 1 == Lessons[lesen.L].teacher.Length)
        {
            AllTest1[lesen.column, lesen.row].GetComponent<PrefabLessen>().techer = Lessons[lesen.L].teacher[0];
            AllTest1[lesen.column, lesen.row].GetComponent<PrefabLessen>().Tech = 0;
        }
       
    }

    public void RoomReplacement(GameObject dot)
    {
        PrefabLessen lesen = dot.gameObject.GetComponent<PrefabLessen>();
        if (lesen.ro + 1 < Lessons[lesen.L].room.Length)
        {
            AllTest1[lesen.column, lesen.row].GetComponent<PrefabLessen>().room = Lessons[lesen.L].room[lesen.ro + 1];
            AllTest1[lesen.column, lesen.row].GetComponent<PrefabLessen>().ro = lesen.ro + 1;
        }
        else if (lesen.ro + 1 == Lessons[lesen.L].room.Length)
        {
            AllTest1[lesen.column, lesen.row].GetComponent<PrefabLessen>().room = Lessons[lesen.L].room[0];
            AllTest1[lesen.column, lesen.row].GetComponent<PrefabLessen>().ro = 0;
        }

    }
    public void AllReplau(GameObject dot)
    {
        PrefabLessen lesen = dot.gameObject.GetComponent<PrefabLessen>();
        LessonClass[] lesenCopy= Lessons;
        int I = lesen.column+1;
        int Y = lesen.row;
        for (int i = 0; i < I; i++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int l = 0; l < lesenCopy.Length; l++)
                {
                    if (AllTest1[i,y].GetComponent<PrefabLessen>().lesonName==lesenCopy[l].nameLesson)
                    {
                        if (y >= Y && i == I-1)
                        {
                            break;
                        }

                        lesenCopy[l].sumHour--;
                        AllTest1[i, y].GetComponent<Image>().color = new Color32(0, 255, 0, 255);
                    }
                }
            }
        }
        foreach (var item in lesenCopy)
        {
            Debug.Log(item.sumHour);
        }

    }
    private void AllReplauHelper(LessonClass[] lesenCopy)
    {
        

    }
}
