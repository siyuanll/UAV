using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = 10f * Time.deltaTime;
        //this.transform.Translate(0, 1f, 0);
       transform.Rotate(0,angle,0,Space.Self);
       
        
    }
}
