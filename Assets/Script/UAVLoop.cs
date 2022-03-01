using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAVLoop : MonoBehaviour
{
    // 保证场景中始终有一个 UAV（UAV 不断由 prefab 生成）
    public GameObject UAV_Prefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("OverheadCamera").GetComponent<Camera>().enabled = true;
        // 初始时先创建一个 UAV（场景中的 UAV prefab 只用来测试，在运行时不勾选）
        GameObject UAV = Instantiate(UAV_Prefab);
    }

    // Update is called once per frame
    void Update()
    {
        // 为 null，即找不到一个 UAV 时，就创建一个
        if (GameObject.Find("UAV") == null)
        {
            GameObject UAV = Instantiate(UAV_Prefab);
        }
    }
}
