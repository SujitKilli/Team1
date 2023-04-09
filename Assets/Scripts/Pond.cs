using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts) {
            if(script.GetType().Name == "LowPolyWater"){
                script.enabled = false;
                script.enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
