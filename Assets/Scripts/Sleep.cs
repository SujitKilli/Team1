using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    public GameObject character;
    public bool insleep;
    public GameObject menu;
    public GameObject bed,roof;
    public GameObject reticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("js8")){
            if(insleep==true && menu.activeSelf==false){
            reticle.SetActive(false);
            menu.SetActive(true);
            menu.transform.position=bed.transform.position+new Vector3(0,2,0);
            menu.transform.LookAt(Camera.main.transform.position);
            menu.transform.Rotate(0,180,0);
            }

            else if(menu.activeSelf==true){
                menu.SetActive(false);
                reticle.SetActive(true);
            }
            }
        if(menu.activeSelf==true && Input.GetButtonDown("js1")){
            character.transform.position = bed.transform.position;
            Debug.Log(character.transform.position);
            character.transform.LookAt(roof.transform.position);
            menu.SetActive(false);
            reticle.SetActive(true);
        }

        
    }
    public void Enter(){
        insleep=true;

    }
    public void Exit(){
    insleep=false;
    }
}
