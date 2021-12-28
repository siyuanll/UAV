using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameCtrl : MonoBehaviour
{
    public GameObject UAV_Prefab;

    void Start()
    {   
        Application.targetFrameRate = 60;
        GameObject UAV = Instantiate(UAV_Prefab);
    }
   
    void Update()
    {
        if(GameObject.Find("UAV") == null) { // 为空（null），即找不到这样一个无人机时，就创建一个
            GameObject UAV = Instantiate(UAV_Prefab);
        }
    }

}
