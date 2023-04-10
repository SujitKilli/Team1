using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fan_Rotation : MonoBehaviour {
    //public bool isRotating = false;
    public bool TurnOn = false;
    public float speed = 500;
    public GameObject fanmenu,fan;
     public GameObject reticle;
    public CharacterController character;
    public Button[] buttons;
    public int index=0;
    public float lasttime;
    private bool isFanOn = false;
    void Start(){
        fanmenu.SetActive(false);
        buttons=fanmenu.GetComponentsInChildren<Button>();

    }

    void Update () {

        if(isFanOn){
               fan.transform.Rotate((new Vector3(0, 1, 0)) * Time.fixedDeltaTime * speed); 
        }

        if (Input.GetButtonDown("js8")) // Check if button "js8" is pressed
        {
            if(TurnOn == true && fanmenu.activeSelf==false)
        {
    
            fanmenu.SetActive(true);
            fanmenu.transform.position=fan.transform.position+new Vector3(0,0.2f,0);
            reticle.SetActive(false);
            character.enabled=false;
            
        }
        else if(fanmenu.activeSelf==true){
            fanmenu.SetActive(false);
            reticle.SetActive(true);
            character.enabled=true;
        }
        }
        if(fanmenu.activeSelf==true){
             if (Time.time - lasttime > 0.5f)
            {
                if (Input.GetAxis("Vertical") >0)
                {
                    index--;
                    if (index < 0)
                    {
                        index = buttons.Length - 1;
                    }
                    HighlightButton(index);
                    lasttime = Time.time;
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    index++;
                    if (index >=buttons.Length)
                    {
                        index = 0;
                    }
                    HighlightButton(index);
                    lasttime = Time.time;
                }
            }
            if(index==0 && Input.GetButton("js10")){
                isFanOn = true;
                fanmenu.SetActive(false);
            reticle.SetActive(true);
            character.enabled=true;

            }
            else if(index==1 && Input.GetButtonDown("js10")){
                isFanOn = false;
                fanmenu.SetActive(false);
                reticle.SetActive(true);
                character.enabled=true;
            }
        }
    }
    public void OnEnter(){
        TurnOn=true;

    }
    public void OnExit(){
        TurnOn=false;
    }
    public void HighlightButton(int index)
    {
        foreach (Button b in buttons)
        {
            b.image.color = Color.white;
        }
        buttons[index].image.color = Color.yellow;
        
    }
            
	
}





