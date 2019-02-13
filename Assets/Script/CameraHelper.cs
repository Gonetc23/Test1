using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    private Test1 test1;
    private void Start()
    {
        test1 = GameObject.FindObjectOfType<Test1>();
        transform.position = PositionStart();
    }

    private Vector3 PositionStart()
    {
        float x = test1.width / 2;
        float y = test1.height / 2;

        return new Vector3(x, y, 10);
    }

}
