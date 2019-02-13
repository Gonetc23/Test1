using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListTecher4 : MonoBehaviour
{
    public ListTecher4[] AllTeacherToggle;

    private void Start()
    {
        AllTeacherToggle = GameObject.FindObjectsOfType<ListTecher4>();
    }

    public void TecherRemov()
    {
        if (gameObject.GetComponent<Toggle>().isOn == false)
        {
            GameObject.FindObjectOfType<Test4>().TeacherRemoval(gameObject);
            GameObject.FindObjectOfType<Test4>().removLessen();
        }
        else 
        {

            GameObject.FindObjectOfType<Test4>().returnTeacher(gameObject);
            foreach (ListTecher4 Teacher in AllTeacherToggle)
            {
                Teacher.GetComponent<Toggle>().isOn = true;
            }
        }
    }
}
