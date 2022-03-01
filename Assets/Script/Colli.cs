using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Colli : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 碰撞检测
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("building"))
        {
            Debug.Log("UAV 与 building 相撞而坠毁");

            // deactive/active other things
            //GameObject.Find("City").SetActive(flag);
            //GameObject.Find("Building").SetActive(flag);

            // Active Warning
            GameObject CanvasObj = GameObject.Find("Canvas");
            GameObject ImageObj = CanvasObj.transform.Find("Image").gameObject;
            ImageObj.SetActive(true);

            Invoke("DeactWarning", 2);
        }
    }

    void DeactWarning()
    {
        GameObject.Find("Canvas/Image").SetActive(false);

        // Destroy UAV must be behind 
        Destroy(this.gameObject);
    }

}
