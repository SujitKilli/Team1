using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalScript : MonoBehaviour
{
    private CharacterMovement cm;
    public GameObject reticle,UMenu;
    public List<GameObject> boundaries = new List<GameObject>();
    public List<Button> GlobalBtns = new List<Button>();
    public TextMeshProUGUI speedText;
    private int ind = 0,speed = 2;
    private bool nextAxInp = true;
    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CharacterMovement>();  
        foreach (GameObject b in boundaries) {
            Globals.boundaries.Add(b);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.sat  || Globals.boatsat || Globals.isglobalVisible || Globals.isFly) Globals.hideOutline = true;
        else Globals.hideOutline = false;
        if(Input.GetButtonDown(Globals.b) && Globals.sat){
            Globals.sat = false;
            cm.enabled = true;
            reticle.transform.localScale = new Vector3(1,1,1);
        }
        if(Input.GetButtonDown(Globals.b) && Globals.boatsat){
            Globals.boatsat = false;
            Globals.boatSitter.GetComponent<WaterFloat>().enabled = true;
            Globals.boatSitter = null;
            reticle.transform.localScale = new Vector3(1,1,1);
            Globals.ToggleBoundaries(false);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,Globals.ypos,Camera.main.transform.position.z);
        }
        if(Input.GetButtonDown(Globals.globalMenu) && !Globals.boatsat && !Globals.sat){
            if(!Globals.isglobalVisible){
                ind = 0;
                highlight(0);
                Globals.isglobalVisible = true;
                reticle.transform.localScale = new Vector3(0,0,0);
                UMenu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 20f;
                UMenu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
                UMenu.transform.SetParent(Camera.main.transform);
                UMenu.SetActive(true);
                cm.enabled = false;
            }
            else{
                closeGlobalMenu();
            }
        }

        if (Globals.isglobalVisible){
            if(nextAxInp){
                if(Input.GetAxis(Globals.ver) > 0){
                    nextAxInp = false;
                    StartCoroutine(ReEnableAxes());
                    ind++;
                    if(ind==6) ind = 0;
                    highlight(ind);
                }
                else if(Input.GetAxis(Globals.ver) < 0){
                    nextAxInp = false;
                    StartCoroutine(ReEnableAxes());
                    ind--;
                    if(ind==-1) ind = 5;
                    highlight(ind);
                }
            }
            if(Input.GetButtonDown(Globals.ok)){
                if(ind == 0){
                    toggleSpeed();
                }
                else if(ind == 1){
                    flyHigh();
                }
                else if(ind == 2){

                }
                else if(ind == 3){

                }
                else if(ind == 4){

                }
                else Application.Quit();
            }
        }

        if(Globals.isFly){
            transform.position+= new Vector3(transform.position.x,100f,transform.position.z);
        }
    }

    private void flyHigh(){
        Globals.isFly = true;
        UMenu.transform.SetParent(null);
        Globals.isglobalVisible = false;
        UMenu.SetActive(false);
        transform.position+= new Vector3(0f,100f,0f);
        cm.enabled = true;
    }

    private void toggleSpeed()
    {
        speed = (speed + 1) % 3;
        if (speed == 0)
        {
            cm.speed = 20f;
            speedText.text = "Speed : Low";
        }
        else if(speed == 1)
        {
            cm.speed = 35f;
            speedText.text = "Speed : Medium";
        }
        else
        {
            cm.speed = 50f;
            speedText.text = "Speed : High";
        }
    }

    private void highlight(int ind){
        foreach(Button obj in GlobalBtns){
            obj.GetComponent<Image>().color = Color.white;
        }
        GlobalBtns[ind].GetComponent<Image>().color = Color.yellow;
    }

    private void closeGlobalMenu(){
        UMenu.transform.SetParent(null);
        Globals.isglobalVisible = false;
        reticle.transform.localScale = new Vector3(1,1,1);
        UMenu.SetActive(false);
        cm.enabled = true;
    }

    IEnumerator ReEnableAxes() {
        yield return new WaitForSeconds(0.3f);
        nextAxInp = true;
    }

    
}
