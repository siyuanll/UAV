using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUAV : MonoBehaviour
{
    // public bool destroy = false;

    float move_unit = 0.5f; // 一步走多远
    Vector3 init_pos = new Vector3(0, 0, 0); // 初始位置
    
    // Start is called before the first frame update
    void Start()
    {
        init_pos = transform.position; // 记录初始位置
    }

    // Update is called once per frame
    void Update()
    {
        key_control();
        mouse_control_move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.Equals("building"))
        {
            Debug.Log("UAV 与 building 相撞而坠毁");
            Destroy(this.gameObject);
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
        }
        if(Input.GetKey(KeyCode.D)){ // D 向右
            transform.Rotate(0, move_unit*10, 0, Space.Self);
        }
        if(Input.GetKey(KeyCode.U)){  // U 向上
            transform.Translate(0, move_unit, 0);
        }
        if(Input.GetKey(KeyCode.I)){  // I 向下
            transform.Translate(0, -move_unit, 0);
        }
        if(Input.GetKey(KeyCode.J)){    // 左右转
            Transform target = transform.Find("UAV").gameObject.transform;
            target.transform.Rotate(0, 0, move_unit*10, Space.Self);
        }
        if(Input.GetKey(KeyCode.K)){    // 前后转
            Transform target = transform.Find("UAV").gameObject.transform;
            target.transform.Rotate(move_unit*10, 0, 0, Space.Self);
        }
    }

    void mouse_control_move() // 鼠标右键按下，无人机瞬移回原位
    {
        if(Input.GetMouseButtonDown(1)){
            transform.position = init_pos;
        }
    }

}
