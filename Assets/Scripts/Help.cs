using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    // Start is called before the first frame update
    public ChangingOptions cmenu;
    public GameObject helppanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(cmenu.ishelphighlighted==true && Input.GetButtonDown("js3"))
        {
            cmenu.menu.SetActive(false);
            cmenu.help.SetActive(false);
            helppanel.SetActive(true);
        }  
    }
}
