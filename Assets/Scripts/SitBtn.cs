using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitBtn : MonoBehaviour
{
    private bool isEnter = false;
    public GameObject sitmenu,character,reticle; 
    private CharacterMovement cm;
    void Start()
    {
        cm = character.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnter && Globals.sitter != null && Input.GetButtonDown(Globals.ok)){
            Globals.sat = true;
            Camera.main.transform.position = new Vector3(Globals.sitter.transform.position.x,Camera.main.transform.position.y,Globals.sitter.transform.position.z);
            Camera.main.transform.position+= Globals.sitter.transform.forward;
            Globals.sitter = null;
            cm.enabled = false;
            sitmenu.SetActive(false);
            reticle.transform.localScale = new Vector3(0,0,0);
        }
    }

    public void OnPointerEnter()
    {
        isEnter = true;
    }

    public void OnPointerExit()
    {
        isEnter = false;
    }
}
