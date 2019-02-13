using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabLessen : MonoBehaviour
{
    public Text LesonName;
    public Text Techer;
    public Text Room;

    public string lesonName;
    public string techer;
    public int room;

    private Test2 test2;

    public int column;
    public int row;
    public int L;
    public int Tech;
    public int ro;

    private void Start()
    {
        test2 = GameObject.FindObjectOfType<Test2>();
       
    }
    private void OnMouseDown()
    {
       // Debug.Log("Нажал");
        test2.dot = gameObject;
        test2.HelperPanel();
        TextReplay();
    }
    private void Update()
    {
        if (techer == "Нет занятий")
        {
            LesonName.color = new Color32(0, 0, 0, 0);
            techer = "Нет занятий";
            Room.color = new Color32(0, 0, 0, 0);
        }
        else
        {
            LesonName.color = new Color32(0, 0, 0, 255);
            Techer.color = new Color32(0, 0, 0, 255);
            Room.color = new Color32(0, 0, 0, 255);
        }
        TextReplay();
    }
    private void TextReplay()
    {
        LesonName.text = lesonName;
        Techer.text = techer;
        Room.text = room.ToString();
    }
}
