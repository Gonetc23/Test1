using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefabClass : MonoBehaviour
{
   
    public string Lessen;
    public int Room;
    private string techer;

    public string Techer
    {
        set
        {
            techer = "test";
            Debug.Log(techer);
        }
        get
        {
            return techer;
            
        }
    }

    public Text TecherT;
    public Text LessemT;
    public Text RoomT;


    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        
        if (Lessen == "" && Room.ToString() == "0")
        {
            TecherT.alignment = TextAnchor.LowerRight;
            TecherT.fontSize = 35;
        }
        else
        {
            TecherT.alignment = TextAnchor.MiddleCenter;
            TecherT.fontSize = 26;
            LessemT.fontSize = 26;
            RoomT.fontSize = 26;
        }
        RefreshHelper();
    }

    public void RefreshHelper()
    {
        TecherT.text = Techer;
        LessemT.text = Lessen;
        if (Room != 0)
        {
            RoomT.text = Room.ToString();
        }
        else
        {
            RoomT.text = "";
        }
        
    }
    
}
