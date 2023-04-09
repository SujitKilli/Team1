using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanelClose : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject helppanel;
    public ChangingOptions cmenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (helppanel.activeSelf == true && Input.GetButtonDown("js1"))
        {

            //Debug.Log("Close");
            helppanel.SetActive(false);
            cmenu.menu.SetActive(true);
            cmenu.help.SetActive(true);


        }
    }
}
