using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHelperPrefab : MonoBehaviour
{
    private Test2 test2;

    public Text Techer;
    public Text Room;
    public Text Group;
    public Text Lesson;

    void Start()
    {
        test2 = GameObject.FindObjectOfType<Test2>();
    }

   
}
