using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitScript : MonoBehaviour
{  
    private Outline myoutline;
    private bool inflag = false; 
    public GameObject sitmenu; 
    void Start()
    {
        myoutline = GetComponent<Outline>();     
    }

    void Update()
    {
        if(Input.GetButtonDown(Globals.x)){
            if(myoutline.enabled && !sitmenu.activeSelf && !inflag){
                Globals.sitter = gameObject;
                inflag = true;
                Vector3 towardsCamera = (Camera.main.transform.position - gameObject.transform.position).normalized;
                sitmenu.SetActive(true);
                sitmenu.transform.position = gameObject.transform.position + towardsCamera*9f + new Vector3(0,10f,0);
                sitmenu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            }
            else if(sitmenu.activeSelf && inflag){
                Globals.sitter = null;
                inflag = false;
                sitmenu.SetActive(false);
            }
        }
        if(!sitmenu.activeSelf) inflag = false;
    }
}
