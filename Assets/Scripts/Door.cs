using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject doormenu,door1,door2;
    public Transform hinge1,hinge2;
    public TextMeshProUGUI doorText;
    private bool isDoorOpen = false;
    void Start()
    {
        doorText.text = "Open door";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(Globals.x)){
            if(Globals.isInDoor && !doormenu.activeSelf){
                if(isDoorOpen) doorText.text = "Close door";
                else doorText.text = "Open door";
                if(!doormenu.activeSelf){
                    doormenu.transform.position = Camera.main.transform.forward*20f + Camera.main.transform.position;
                    doormenu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
                    doormenu.SetActive(true);
                }
            }
            else if(doormenu.activeSelf){
                doormenu.SetActive(false);
            }
        }
        if(Globals.isInDoorBtn && Input.GetButtonDown(Globals.ok)){
            if(!isDoorOpen){
                doormenu.SetActive(false);
                isDoorOpen = true;
                door1.transform.RotateAround(hinge1.position, Vector3.up, -90f);
                door2.transform.RotateAround(hinge2.position, Vector3.up, 90f);
            }
            else{
                doormenu.SetActive(false);
                isDoorOpen = false;
                door1.transform.RotateAround(hinge1.position, Vector3.up, 90f);
                door2.transform.RotateAround(hinge2.position, Vector3.up, -90f);
            }
        }
    }
}
