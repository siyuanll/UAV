using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Blade : MonoBehaviour
{
    private int step = 23;

    public int RollAngle = 0;

    public Text paramText4;

    // Start is called before the first frame update
    void Start()
    {
        paramText4 = GameObject.Find("Canvas/Text4").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, step, 0, Space.Self);
        RollAngle += step;
        if (RollAngle > 360){
            RollAngle -= 360;
        }

        paramText4.text = "机翼旋转角:" + RollAngle.ToString("f0");
    }
}
