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
            character.transform.position = Globals.sitter.transform.position+new Vector3(0, 12f, 0);
            Globals.sitter = null;
            sitmenu.SetActive(false);
            reticle.transform.localScale = new Vector3(0,0,0);
            cm.enabled = false;
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
