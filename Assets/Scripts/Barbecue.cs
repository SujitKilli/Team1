using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barbecue : MonoBehaviour
{
    private Outline myoutline;
    public GameObject bbqmenu,bbqplate,mesageObj;
    public TextMeshProUGUI msgTxt;
    private List<GameObject> bbq = new List<GameObject>();
    private int invLimit = 10;
    public GameObject chickRaw, chickRoasted, fishRaw, fishRoasted, steakRaw, steakRoasted;

    void Start()
    {
        myoutline = GetComponent<Outline>();
    }

    void Update()
    {
        if(Input.GetButtonDown(Globals.x)){
            if(myoutline.enabled && !bbqmenu.activeSelf){
                Vector3 towardsCamera = (Camera.main.transform.position - gameObject.transform.position).normalized;
                bbqmenu.SetActive(true);
                bbqmenu.transform.position = gameObject.transform.position + towardsCamera*9f + new Vector3(0,4f,0);
                bbqmenu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            }
            else if(bbqmenu.activeSelf){
                bbqmenu.SetActive(false);
            }
        }
        if(Input.GetButtonDown(Globals.ok) && bbqmenu.activeSelf){
            if(Globals.invCounter == Globals.inventoryLimit){
                msgTxt.text  = "Inventory full!!";
                mesageObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward*6f;
                mesageObj.transform.LookAt(Camera.main.transform);
                mesageObj.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
                mesageObj.SetActive(true);
                StartCoroutine(HideIM());
            }
            else bakeMeat(Globals.isChicken,Globals.isSteak,Globals.isFish);
        }
        if(!bbqmenu.activeSelf){
            Globals.isChicken = false;
            Globals.isFish = false;
            Globals.isSteak = false;
        }
    }

    private void bakeMeat(bool c,bool s,bool f){
        Globals.invCounter++;
        if(c){
            GameObject chicken = Instantiate(chickRaw,bbqplate.transform.position + new Vector3(Random.Range(-3f, 3f),0.5f,Random.Range(-2.5f, 2.5f)), Quaternion.identity);
            chicken.transform.localScale = chicken.transform.localScale*2f;
            StartCoroutine(TransformToIV(chicken,chickRoasted,"chickenbbq"));
            msgTxt.text = "Chicken added to barbeque";
        } 
        else if(f){
            GameObject fish = Instantiate(fishRaw,bbqplate.transform.position + new Vector3(Random.Range(-3f, 3f),0.5f,Random.Range(-2.5f, 2.5f)), Quaternion.identity);
            fish.transform.localScale = fish.transform.localScale*2f;
            StartCoroutine(TransformToIV(fish,fishRoasted,"fishbbq"));
            msgTxt.text = "Fish added to barbeque";
        }
        else if(s){
            GameObject steak = Instantiate(steakRaw,bbqplate.transform.position + new Vector3(Random.Range(-3f, 3f),0.5f,Random.Range(-2.5f, 2.5f)), Quaternion.identity);
            steak.transform.localScale = steak.transform.localScale*2f;
            StartCoroutine(TransformToIV(steak,steakRoasted,"steakbbq"));
            msgTxt.text = "Steak added to barbeque";
        }
        mesageObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward*6f;
        mesageObj.transform.LookAt(Camera.main.transform);
        mesageObj.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        mesageObj.SetActive(true);
        StartCoroutine(HideIM());
        bbqmenu.SetActive(false);
    }

    IEnumerator HideIM() {
        yield return new WaitForSeconds(3);
        mesageObj.SetActive(false);
    }

    IEnumerator TransformToIV(GameObject raw, GameObject cooked,string tag){
        yield return new WaitForSeconds(15);
        Destroy(raw);
        GameObject bbqed = Instantiate(cooked,new Vector3(0,0,0), Quaternion.identity);
        bbqed.transform.localScale = bbqed.transform.localScale*2f;
        bbqed.SetActive(false);
        bbqed.tag = tag;
        BoxCollider boxCollider = bbqed.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(2f, 2f, 2f);
        Globals.invCounter++;
        Globals.inventory.Add(bbqed);
        msgTxt.text = "Food added to Inventory";
        mesageObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward*6f;
        mesageObj.transform.LookAt(Camera.main.transform);
        mesageObj.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        mesageObj.SetActive(true);
        StartCoroutine(HideIM());
    }
}
