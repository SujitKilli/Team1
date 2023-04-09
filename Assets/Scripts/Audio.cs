using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Audio : MonoBehaviour
{
    public bool Turn = false;
    public GameObject menu;
    public GameObject speaker;
    public AudioSource musicSource;
    public GameObject reticle;
    public CharacterController character;
    public Button[] buttons;
    public int index;
    public float lasttime;
    // Start is called before the first frame update
    void Start()
    {
        buttons=menu.GetComponentsInChildren<Button>();
        HighlightButton(index);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("js8"))
        {
            if(Turn == true && menu.activeSelf==false)
        {
    
            menu.SetActive(true);
            menu.transform.position=speaker.transform.position+new Vector3(0,0.2f,0);
            reticle.SetActive(false);
            character.enabled=false;
            
        }
        else if(menu.activeSelf==true){
            menu.SetActive(false);
            reticle.SetActive(true);
            character.enabled=true;
        }

        }
         
        if(menu.activeSelf==true){
            
                if (Time.time - lasttime > 0.5f)
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    index--;
                    if (index < 0)
                    {
                        index = buttons.Length - 1;
                    }
                    HighlightButton(index);
                    lasttime = Time.time;
                }
                else if (Input.GetAxis("Horizontal") > 0)
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
            if(index==0 && Input.GetButtonDown("js10")){
            musicSource.Play();
        }
        else if(index==1 && Input.GetButtonDown("js10")){
            musicSource.Pause();
        }
        else if(index==2 && Input.GetButtonDown("js10")){
            musicSource.Stop();
            menu.SetActive(false);
            reticle.SetActive(true);
            character.enabled=true;
        }

        }
        
        
    }
     public void OnPointEnter()
    {
        Debug.Log("Entered ");
        Turn=true;

    }
    public void OnPointerExit()
    {
        Debug.Log("Exit");
        Turn = false;
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

