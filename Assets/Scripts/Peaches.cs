using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Peaches : MonoBehaviour
{
    private Outline myoutline;
    public GameObject mesageObj;
    public TextMeshProUGUI msgTxt;
    // Start is called before the first frame update
    void Start()
    {
        myoutline = GetComponent<Outline>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(myoutline.enabled && Input.GetButtonDown(Globals.x)){
            if(Globals.invCounter == Globals.inventoryLimit){
                msgTxt.text  = "Inventory full!!";
                mesageObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward*6f;
                mesageObj.transform.LookAt(Camera.main.transform);
                mesageObj.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
                mesageObj.SetActive(true);
                StartCoroutine(HideIM());
            }
            else StartCoroutine(StoreFruit());
        }
    }

    IEnumerator StoreFruit(){
        GetComponentInParent<PeachTree>().createChildFruits();
        gameObject.transform.SetParent(null);
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = 2f;
        rb.useGravity = true;
        yield return new WaitForSeconds(4);
        Destroy(rb);
        Globals.invCounter++;
        Globals.inventory.Add(gameObject);
        gameObject.SetActive(false);
    }

    IEnumerator HideIM() {
        yield return new WaitForSeconds(3);
        mesageObj.SetActive(false);
    }
}
