using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fishes : MonoBehaviour
{
    private Outline myoutline;
    public GameObject mesageObj,parentPond,fishingrodprefab;
    public TextMeshProUGUI msgTxt;
    private GameObject localfishingrod;
    // Start is called before the first frame update
    void Start()
    {
        myoutline = GetComponent<Outline>();
        localfishingrod = Instantiate(fishingrodprefab);
        localfishingrod.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(myoutline.enabled){
            localfishingrod.SetActive(true);
            localfishingrod.transform.position = Camera.main.transform.position + Camera.main.transform.forward*7f;
            localfishingrod.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            localfishingrod.transform.SetParent(Camera.main.transform);
            localfishingrod.transform.localPosition+= new Vector3(3f,0f,0f);
            localfishingrod.transform.SetParent(null);
        }
        else{
            localfishingrod.SetActive(false);
        }
        if(myoutline.enabled && Input.GetButtonDown(Globals.x)){
            if(Globals.invCounter == Globals.inventoryLimit){
                msgTxt.text  = "Inventory full!!";
                mesageObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward*6f;
                mesageObj.transform.LookAt(Camera.main.transform);
                mesageObj.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
                mesageObj.SetActive(true);
                StartCoroutine(HideIM());
            }
            else StoreFish();
        }
        
    }

    private void StoreFish(){
        localfishingrod.SetActive(false);
        parentPond.GetComponent<FishPond>().createFish();
        gameObject.SetActive(false);
        Globals.invCounter++;
        Globals.inventory.Add(gameObject);
    }

    IEnumerator HideIM() {
        yield return new WaitForSeconds(3);
        mesageObj.SetActive(false);
    }
}
