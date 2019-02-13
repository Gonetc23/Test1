using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public GameObject dot;
    public PanelHelperPrefab panelHelperPrefab;
    private Test1 test1;

    private void Start()
    {
        test1 = GameObject.FindObjectOfType<Test1>();
        panelHelperPrefab = GameObject.FindObjectOfType<PanelHelperPrefab>();
    }

    public void HelperPanel()
    {
        PrefabLessen lesen = dot.gameObject.GetComponent<PrefabLessen>();

        if (panelHelperPrefab.gameObject.activeInHierarchy==false)
        {
            panelHelperPrefab.gameObject.SetActive(true);
        }
        panelHelperPrefab.Techer.text = lesen.techer;
        panelHelperPrefab.Room.text = lesen.room.ToString();
        panelHelperPrefab.Lesson.text = lesen.lesonName;
        panelHelperPrefab.Group.text = "КСК-316";//нажо доработать
    }

    public void TeacherReplacement()
    {
        test1.TeacherReplacement(dot);
        HelperPanel();
    }
    public void RoomReplacement()
    {
        test1.RoomReplacement(dot);
        HelperPanel();
    }
    public void AllReplac()
    {
        test1.AllReplau(dot);
        HelperPanel();
    }
}
