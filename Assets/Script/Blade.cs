using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public int rotatingSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = 30f * Time.deltaTime;
        transform.Rotate(0, rotatingSpeed * angle, 0, Space.Self);
    }
}
