using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelClose : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public ChangingOptions cmenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.activeSelf == true && Input.GetButtonDown("js1"))
        {
            
                //Debug.Log("Close");
                panel.SetActive(false);
                cmenu.menu.SetActive(true);
            
               
        }
    }
}
