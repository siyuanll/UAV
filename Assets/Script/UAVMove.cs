using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UAVMove : MonoBehaviour
{

    Vector3 init_pos = new Vector3(0, 0, 0); // 初始位置

    // public bool destroy = false;
    public float YawAngle = 0f; // 偏航角
    public float RollingAngle = 0f; // 滚动角
    public float PitchAngle = 0f; // 俯仰角

    // point to Text component
    public Text paramText1;
    public Text paramText2;
    public Text paramText3;

    public Text paramText5;

    // 绘制轨迹组件
    public LineRenderer line;
    public List<Vector3> points;


    float move_unit = 0.1f; // 一步走多远
    
    // Start is called before the first frame update
    void Start()
    {
        init_pos = transform.position; // 记录初始位置

        paramText1 = GameObject.Find("Canvas/Text1").GetComponent<Text>();
        paramText2 = GameObject.Find("Canvas/Text2").GetComponent<Text>();
        paramText3 = GameObject.Find("Canvas/Text3").GetComponent<Text>();

        paramText5 = GameObject.Find("Canvas/Text5").GetComponent<Text>();

        line = GameObject.Find("LineRenderer").GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 绘制轨迹
        //!!!!!if(cameras[i].GetComponent<Camera>().enabled)
        AddPoints();

        key_control(); // 键盘可以控制移动
        mouse_control_move(); // 鼠标可以控制步长、回到原位
        
        paramText1.text = "无人机偏航角:" + YawAngle.ToString("f0");
        paramText2.text = "无人机滚动角:" + RollingAngle.ToString("f0");
        paramText3.text = "无人机俯仰角:" + PitchAngle.ToString("f0");

        paramText5.text = "UAV height:" + transform.position.y.ToString();

        // automove();
    }

    // 绘制轨迹方法
    public void AddPoints()
    {
        Vector3 pos = transform.position;
        if (points.Count > 0 && (pos - lastPoint).magnitude < 0.1f)
            return;
        if (pos != new Vector3(0, 0, 0))
            points.Add(pos);

        line.positionCount = points.Count;
        if (points.Count > 0)
            line.SetPosition(points.Count - 1, lastPoint);
    }

    public Vector3 lastPoint
    {
        get
        {
            if (points == null)
                return Vector3.zero;
            return (points[points.Count - 1]);
        }
    }

    void mouse_control_move()
    {
        if (Input.GetMouseButtonDown(2))
        { // 鼠标中键按下，无人机瞬移回原位
            transform.position = init_pos;
        }
        // 鼠标控制一步的大小
        if (Input.GetMouseButtonDown(0))
        {
            move_unit = move_unit + 0.1f;
        }
        if (Input.GetMouseButtonDown(1))
        {
            move_unit = move_unit - 0.1f;
        }
    }

    void key_control() //键盘控制无人机运动
    {
        if(Input.GetKey(KeyCode.W)){ // W 前进 
            transform.Translate(0, 0, move_unit);
        }
        if(Input.GetKey(KeyCode.S)){ // S 后退   
            transform.Translate(0, 0, -move_unit);
        }
        if(Input.GetKey(KeyCode.A)){ // A 向左
            transform.Rotate(0, -move_unit*10, 0, Space.Self);
            YawAngle -= move_unit*10;
            //paramText1.text = "无人机偏航角:" + YawAngle.ToString("f0");
        }
        if(Input.GetKey(KeyCode.D)){ // D 向右
            transform.Rotate(0, move_unit*10, 0, Space.Self);
            YawAngle += move_unit*10;
            //paramText1.text = "无人机偏航角:" + YawAngle.ToString("f0");
        }
        if(Input.GetKey(KeyCode.U)){  // U 向上
            transform.Translate(0, move_unit, 0);
        }
        if(Input.GetKey(KeyCode.I)){  // I 向下
            transform.Translate(0, -move_unit, 0);
        }
        if(Input.GetKey(KeyCode.J) && RollingAngle < 45){ // 正向滚动（限制滚动角度不大于 45度）
            Transform target = transform.Find("UAV").gameObject.transform;
            target.transform.Rotate(0, 0, move_unit*10, Space.Self);
            RollingAngle += move_unit*10;

            //if(RollingAngle > 360){RollingAngle -= 360;}
        }
        if (Input.GetKey(KeyCode.K) && RollingAngle > -45){ //反向滚动（限制滚动角度不小于 -45度）
            Transform target = transform.Find("UAV").gameObject.transform;
            target.transform.Rotate(0, 0, -move_unit * 10, Space.Self);
            RollingAngle -= move_unit * 10;

            //if (RollingAngle < 360) { RollingAngle -= 360; }
        }

        if (Input.GetKey(KeyCode.N) && PitchAngle < 45){ // 正向俯仰（限制滚动角度不大于 45度）
            Transform target = transform.Find("UAV").gameObject.transform;
            target.transform.Rotate(move_unit*10, 0, 0, Space.Self);
            PitchAngle += move_unit*10;

            //if(PitchAngle > 360){PitchAngle -= 360;}
        }
        if (Input.GetKey(KeyCode.M) && PitchAngle > -45)
        { // 反向俯仰（限制滚动角度不小于 -45度）
            Transform target = transform.Find("UAV").gameObject.transform;
            target.transform.Rotate(-move_unit * 10, 0, 0, Space.Self);
            PitchAngle -= move_unit * 10;

            //if (PitchAngle > 360) { PitchAngle -= 360; }
        }
    }

    /*
    每一轮去学习：
    动作：向前后左右移动
    奖励：-10：撞击建筑，+-0.1：离目的地越近/远
    */

    //void automove(){
    //    // 状态：前后左右传感器的状态（是否有障碍物）
    //    //bool front;
    //    //bool rear;
    //    //bool left;
    //    //bool right;

    //    //if(transform.position.x + move_unit ){
    //    //transform.Translate(0, 0, move_unit);

    //}


}
