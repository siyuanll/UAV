using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameObject : MonoBehaviour
{
    public float rollRate = 0; // 自转
    public float pitchRate = 0;
    public float azimuthRate = 0;
    public float forwardSpeed = 0;
    public float highSpeed = 0;
    public float lateralSpeed = 0;
    
    void gui0(){
        rollRate = 0;
        pitchRate = 0;
        azimuthRate = 0;
        forwardSpeed = 0;
        highSpeed = 0;
        lateralSpeed = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        lateralSpeed = 0.2f;
    }
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){ // W 前进 
            gui0();
            forwardSpeed = 0.5f;
        }
        if(Input.GetKey(KeyCode.S)){ // S 后退   
            gui0();
            forwardSpeed = -0.5f;
        }
        if(Input.GetKey(KeyCode.A)){ // A 向左
            gui0();
            lateralSpeed = -0.5f;
        }
        if(Input.GetKey(KeyCode.D)){ // D 向右
            gui0();
            lateralSpeed = 0.5f;
        }
        if(Input.GetKey(KeyCode.U)){  // U 向上
            gui0();
            highSpeed = 0.5f;
        }
        if(Input.GetKey(KeyCode.I)){  // I 向下
            gui0();
            highSpeed = -0.5f;
        }
        if(Input.GetKey(KeyCode.J)){     
            gui0();
            rollRate = 1f;
        }
        if(Input.GetKey(KeyCode.K)){     
            gui0();
            pitchRate = 1f;
        }
        if(Input.GetKey(KeyCode.L)){     
            gui0();
            azimuthRate = 1f;
        }

        float angle = 30f * Time.deltaTime;
     //   transform.Translate(lateralSpeed*0.01f, highSpeed*0.01f, forwardSpeed*0.01f,Space.Self);
     //   transform.Rotate(pitchRate * angle, azimuthRate * angle, rollRate * angle, Space.Self);
        transform.Translate(lateralSpeed * 0.01f, highSpeed * 0.01f, forwardSpeed * 0.01f);
        transform.Rotate(pitchRate * angle, azimuthRate * angle, rollRate * angle);
    }
}
