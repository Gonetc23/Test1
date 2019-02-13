using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test4 : MonoBehaviour
{
    public Toggle togglePrefab;
    public GameObject prefab;
    public int width = 5;
    public int height = 10;

    public float offSetX;
    public float offSetY;
    public float offSetYTeacher;

    public List<string> teacher = new List<string>()
    {
        "Князев", "Шашков", "Маштаков", "Филаткин", "Губедулин", "соколов"
    };

    public GameObject[,] AllTest;

    public prefabClass[,] AllTestCopy;

    private void Start()
    {
        AllTest = new GameObject[width, height];
        AllTestCopy = new prefabClass[width, height];
        CreateMatrix();
        ListTeachers();
    }


    private void CreateMatrix()
    {
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                CreateHelper(w, h);
            }
        }
        gameObject.transform.localPosition = new Vector3(-800, 500, 500);
        MatrixFill();
        
    }

    private void SaveCopy()
    {
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                
                AllTestCopy[w, h].Techer = AllTest[w, h].gameObject.GetComponent<prefabClass>().Techer;
                AllTestCopy[w, h].Room = AllTest[w, h].gameObject.GetComponent<prefabClass>().Room;
                AllTestCopy[w, h].Lessen = AllTest[w, h].gameObject.GetComponent<prefabClass>().Lessen;
            }
        }
       
    }
    private void CreateHelper(int x, int y)
    {
        Vector3 pos = new Vector3(x * offSetX, -y * offSetY, 50);

        GameObject Obj = Instantiate(prefab, pos, Quaternion.identity);
        Obj.transform.parent = gameObject.transform;
        Obj.transform.position = pos;
        Obj.transform.localScale = new Vector3(1, 1, 1);
        Obj.name = "Точка ( " + x + " , " + y + " )";
        AllTest[x, y] = Obj;

        AllTestCopy[x, y] = new prefabClass();
    }

    /// <summary>
    /// Заполнение матрицы
    /// </summary>
    private void MatrixFill()
    {
        int R = 0;
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                R = Random.Range(0, teacher.Count);
                if (AllTest[w, h].gameObject.GetComponent<prefabClass>().Techer == "")//заполнение только пустых ячеек 
                {
                    if (w == 0 && h < 4)//заполнение только первого дня и только первых четырёх строк
                    {
                        
                        AllTest[w, h].gameObject.GetComponent<prefabClass>().Techer = teacher[R];
                        AllTest[w, h].gameObject.GetComponent<prefabClass>().Refresh();
                    }
                    else if (w != 0 && h < 4)//заполнение не первого дня и только первых четырёх строк
                    {
                        int MaxReturn = 0;
                        while (MatrixFillHelper(w, h, R) == true && MaxReturn < 100)//заполнение если в перведущем стобце этой строки нет преподователя 
                        {
                            R = Random.Range(0, teacher.Count);
                            MaxReturn++;

                        }
                      
                        MaxReturn = 0;
                        
                        AllTest[w, h].gameObject.GetComponent<prefabClass>().Techer = teacher[R];
                        AllTest[w, h].gameObject.GetComponent<prefabClass>().Refresh();


                    }
                }
            }
        }
        if (AllTestCopy[1, 1].Techer == null)
        {
            SaveCopy();
            
        }
    }

    private bool MatrizHelper(int W, int H, int R)
    {
        return false;
    }

    private bool MatrixFillHelper(int W, int H, int R)
    {
        int numberCoincidences = 0;
        List<string> teacherList = new List<string>();

        for (int w = 0; w < W + 1; w++)
        {
            teacherList.Add(AllTest[w, H].gameObject.GetComponent<prefabClass>().Techer);
        }
        foreach (string item in teacherList)
        {
            //Debug.Log(item + " столбец " + W + " строка " + H);
            if (item == teacher[R])
            {
                numberCoincidences++;
            }
        }
        if (numberCoincidences == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void removLessen()
    {
        int a = 0;
        for (int l = 0; l < teacher.Count; l++)
        {


            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    if (w == 0 && h < 4)//первый стобец
                    {
                        //    Debug.Log("1");
                        if (AllTest[w, h].GetComponent<prefabClass>().Techer == teacher[l])//если любое нгахвание повторяеться то а++
                        {
                            a++;
                            //Debug.Log("2 " + AllTest[w, h].GetComponent<prefabClass>().Techer);
                            //Debug.Log("2 " + a);
                        }
                        if (a == 4)//если 4 раза подряд 
                        {
                            Debug.Log("a= 4");
                            AllTest[0, 0].GetComponent<prefabClass>().Techer = "0";
                            AllTest[0, 3].GetComponent<prefabClass>().Techer = "0";
                         //   AllTest[0, 0].GetComponent<prefabClass>().Refresh();
                           // AllTest[0, 3].GetComponent<prefabClass>().Refresh();
                        }
                        else if (a == 3)// если есть три повторения 
                        {
                            Debug.Log("a=3 "+h);
                            if (AllTest[0, 0].GetComponent<prefabClass>().Techer == teacher[l] && AllTest[3, 0].GetComponent<prefabClass>().Techer == teacher[l])
                            {
                                Debug.Log("и то и другое");
                                AllTest[0, 3].GetComponent<prefabClass>().Techer = "0";
                            }
                            else if (AllTest[0, 0].GetComponent<prefabClass>().Techer == teacher[l])
                            {
                                AllTest[0, 0].GetComponent<prefabClass>().Techer = "0";
                            }
                            else if (AllTest[0, 3].GetComponent<prefabClass>().Techer == teacher[l])
                            {
                                AllTest[0, 3].GetComponent<prefabClass>().Techer = "0";
                            }

                        }

                    }
                    else if (w != 0 && h < 4)
                    {

                    }


                }

            }
            a = 0;
        }
    }

    public void ListTeachers()
    {
       
        GameObject parentList = GameObject.Find("Преподователи");
        for (int i = 0; i < teacher.Count; i++)
        {
            float y = 350 - (i * offSetYTeacher);
            Vector3 pos = new Vector3(0, 0, 0);
            Toggle Tg = Instantiate(togglePrefab, new Vector3(), Quaternion.identity);

            Tg.name = "Toggle Teacher";
            Tg.GetComponentInChildren<Text>().text = teacher[i];
            Tg.transform.parent = parentList.transform;
            Tg.transform.localPosition = new Vector3(0, y, 0);
            Tg.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    /// <summary>
    /// удаление преподователя
    /// </summary>
    /// <param name="toggle"></param>
    public void TeacherRemoval(GameObject toggle)
    {
        string name = toggle.gameObject.GetComponentInChildren<Text>().text;

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                if (AllTest[w, h].gameObject.GetComponent<prefabClass>().Techer == name)
                {
                    AllTest[w, h].gameObject.GetComponent<prefabClass>().Techer = "";
                }
            }
        }

        for (int i = 0; i < teacher.Count; i++)
        {
            if (teacher[i] == name)
            {
                teacher.RemoveAt(i);
            }
        }
        MatrixFill();
    }


    public void returnTeacher(GameObject toggle)
    {

        string name = toggle.gameObject.GetComponentInChildren<Text>().text;
        teacher.Add(name);
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                AllTest[w, h].GetComponent<prefabClass>().Techer = AllTestCopy[w, h].Techer;
                AllTest[w, h].GetComponent<prefabClass>().Refresh();
            }

        }

       
    }
}
//private void Troll()
//{
//    int R=20000;
//    int B = 0;
//    int A = 0;
//    for (int i = 0; i < R; i++)
//    {

//        int a = Random.Range(0, R);
//        if (a != 1)
//        {
//            A++;
//        }
//        else
//        {
//            B++;
//        }

//    }
//    Debug.Log("Число Равиля " + A + " число Гонца " + B + " Число повторений " + R);
//}