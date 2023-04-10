using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class About : MonoBehaviour
{
    // Start is called before the first frame update
    public ChangingOptions cmenu;
    public GameObject panel;
    //public Gameobject mainmenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cmenu.index==1 && (Input.GetButtonDown(Globals.ok)))
        {
            cmenu.menu.SetActive(false);
            panel.SetActive(true);
        }
    }
    
}
