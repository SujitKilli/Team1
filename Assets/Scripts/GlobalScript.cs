using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GlobalScript : MonoBehaviour
{
    public Button[] teleportbuttons;
    public GameObject teleportmenu,garden,mountain,beach,invMenu,helpMenu;
    private CharacterMovement cm;
    private CharacterController charCntrl;
    public GameObject reticle,UMenu,rain;
    public List<GameObject> boundaries = new List<GameObject>();
    public List<Button> GlobalBtns = new List<Button>();
    public List<Button> invBtns = new List<Button>();
    public TextMeshProUGUI speedText,weatherText;
    private int ind = 0,speed = 2,weather = 0,teleindex = 0,invInd = 0,countim = 0;
    private bool nextAxInp = true;
    public float flyMoveSpeed = 0.1f;
    public Material Morning,Night,Cloudy,Sunset;
    private float lasttime;
    public Sprite Apple,Chickenbbq,Fish,Fishbbq,Pear,Steakbbq;
    private bool isGrabbed = false;
    private GameObject grabbedObj = null;
    // Start is called before the first frame update
    void Start()
    {
        teleportbuttons = teleportmenu.GetComponentsInChildren<Button>();
        HighlightButton(teleindex);
        RenderSettings.skybox = Morning;
        cm = GetComponent<CharacterMovement>();
        charCntrl = GetComponent<CharacterController>();  
        foreach (GameObject b in boundaries) {
            Globals.boundaries.Add(b);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabbed && Input.GetButtonDown(Globals.x)){
             isGrabbed = false;
             grabbedObj.transform.SetParent(null);
             grabbedObj = null;
        }

        if(isGrabbed && Input.GetButtonDown(Globals.b)){
            StartCoroutine(DropObj());
        }

        if(Globals.isHelp){
            if(Input.GetButtonDown(Globals.b)){
                closeHelp();
            }
        }

        if(Globals.isInv){
            if(Input.GetButtonDown(Globals.globalMenu)){
                closeInventory();
            }
            else if (Input.GetButtonDown(Globals.ok))
            {
                if (invInd < countim)
                {
                    grabbedObj = Globals.inventory[invInd];
                    Globals.inventory.RemoveAt(invInd);
                    Globals.invCounter--;
                    grabbedObj.SetActive(true);
                    isGrabbed = true;
                    grabbedObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10f;
                    grabbedObj.transform.SetParent(Camera.main.transform);
                }
                closeInventory();
            }
            else if(nextAxInp){
                if (Input.GetAxis(Globals.hor) < 0){
                    nextAxInp = false;
                    StartCoroutine(ReEnableAxes());
                    invInd--;
                    if(invInd==-1) invInd = 2;
                    highlightInv(invInd);
                }       
                else if(Input.GetAxis(Globals.hor) > 0){
                    nextAxInp = false;
                    StartCoroutine(ReEnableAxes());
                    invInd++;
                    if(invInd==3) invInd = 0;
                    highlightInv(invInd);
                }           
            }
        }

        if(Globals.isFly){
            if(Input.GetButtonDown(Globals.b)){
                Globals.isFly = false;
                reticle.transform.localScale = new Vector3(1,1,1);
                cm.enabled = true;
            }
            else{
                float horComp = Input.GetAxis("Horizontal");
                float vertComp = Input.GetAxis("Vertical");

                if (cm.joyStickMode)
                {
                    horComp = Input.GetAxis("Vertical");
                    vertComp = Input.GetAxis("Horizontal") * -1;
                }

                Vector3 moveVect = Vector3.zero;
                Vector3 cameraLook = Camera.main.transform.forward;
                cameraLook.y = 0;
                cameraLook = cameraLook.normalized;

                Vector3 forwardVect = cameraLook;
                Vector3 rightVect = Vector3.Cross(forwardVect, Vector3.up).normalized * -1;

                moveVect += rightVect * horComp;
                moveVect += forwardVect * vertComp;

                moveVect *= (cm.speed*flyMoveSpeed);
                transform.position+= new Vector3(moveVect.x,0f,moveVect.z);
            }
        }

        if(Globals.isTeleport){
            if(Input.GetButtonDown(Globals.globalMenu)){
                closeTeleportMenu();
            }
            else {
                if (Time.time - lasttime > 0.5f)
                {
                    if (Input.GetAxis(Globals.ver) > 0)
                    {
                        teleindex--;
                        if (teleindex < 0)
                        {
                            teleindex = teleportbuttons.Length - 1;
                        }
                        HighlightButton(teleindex);
                        lasttime = Time.time;
                    }
                    else if (Input.GetAxis(Globals.ver) < 0)
                    {
                        teleindex++;
                        if (teleindex >= teleportbuttons.Length)
                        {
                            teleindex = 0;
                        }
                        HighlightButton(teleindex);
                        lasttime = Time.time;
                    }
                }
                if(teleindex==0 && Input.GetButtonDown(Globals.ok))
                {
                    Globals.isTeleport = false;
                    reticle.transform.localScale = new Vector3(1,1,1);
                    teleportmenu.transform.SetParent(null);
                    teleportmenu.SetActive(false);
                    GetComponent<CharacterMovement>().enabled = true;
                    SceneManager.LoadScene("Room");
                }
                else if(teleindex==1 && Input.GetButtonDown(Globals.ok))
                {
                    Globals.isTeleport = false;
                    reticle.transform.localScale = new Vector3(1,1,1);
                    teleportmenu.transform.SetParent(null);
                    teleportmenu.SetActive(false);
                    GetComponent<CharacterMovement>().enabled = true;
                    transform.position = garden.transform.position+new Vector3(0,12f,0);
                }
                else if (teleindex == 2 && Input.GetButtonDown(Globals.ok))
                {
                    Globals.isTeleport = false;
                    reticle.transform.localScale = new Vector3(1,1,1);
                    teleportmenu.transform.SetParent(null);
                    teleportmenu.SetActive(false);
                    GetComponent<CharacterMovement>().enabled = true;
                    transform.position = beach.transform.position+new Vector3(0, 12f, 0);
                }
                else if (teleindex == 3 && Input.GetButtonDown(Globals.ok))
                {
                    Globals.isTeleport = false;
                    reticle.transform.localScale = new Vector3(1,1,1);
                    teleportmenu.transform.SetParent(null);
                    teleportmenu.SetActive(false);
                    GetComponent<CharacterMovement>().enabled = true;
                    transform.position = mountain.transform.position+new Vector3(0, 40f, 10f);
                }
            }
        }

        if(Globals.sat  || Globals.boatsat || Globals.isglobalVisible || Globals.isFly || Globals.isTeleport || Globals.isInv || Globals.isHelp) Globals.hideOutline = true;
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
        if(Input.GetButtonDown(Globals.globalMenu) && !Globals.boatsat && !Globals.sat && !Globals.isFly && !Globals.isTeleport && !Globals.isInv && !Globals.isHelp){
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
                if(Input.GetAxis(Globals.ver) < 0){
                    nextAxInp = false;
                    StartCoroutine(ReEnableAxes());
                    ind++;
                    if(ind==7) ind = 0;
                    highlight(ind);
                }
                else if(Input.GetAxis(Globals.ver) > 0){
                    nextAxInp = false;
                    StartCoroutine(ReEnableAxes());
                    ind--;
                    if(ind==-1) ind = 6;
                    highlight(ind);
                }
            }
            if(Input.GetButtonDown(Globals.ok)){
                if(ind == 0){
                    openHelp();
                }
                else if(ind == 1){
                    toggleSpeed();
                }
                else if(ind == 2){
                    flyHigh();
                }
                else if(ind == 3){
                    openInventory();
                }
                else if(ind == 4){
                    toggleWeather();
                }
                else if(ind == 5){
                    openTeleport();
                }
                else Application.Quit();
            }
        }
    }

    private void openHelp(){
        UMenu.transform.SetParent(null);
        Globals.isglobalVisible = false;
        Globals.isHelp = true;
        UMenu.SetActive(false);
        helpMenu.SetActive(true);
        helpMenu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 20f;
        helpMenu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        helpMenu.transform.SetParent(Camera.main.transform);
    }

    private void closeHelp(){
        helpMenu.transform.SetParent(null);
        Globals.isHelp = false;
        reticle.transform.localScale = new Vector3(1,1,1);
        helpMenu.SetActive(false);
        cm.enabled = true;
    }

    private void openTeleport(){
        teleindex = 0;
        HighlightButton(0);
        UMenu.transform.SetParent(null);
        Globals.isglobalVisible = false;
        Globals.isTeleport = true;
        UMenu.SetActive(false);
        teleportmenu.SetActive(true);
        teleportmenu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 14f;
        teleportmenu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        teleportmenu.transform.SetParent(Camera.main.transform);
    }

    private void openInventory(){
        invInd = 0;
        highlightInv(0);
        countim = Globals.inventory.Count;
        Debug.Log(countim);
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                if (i < countim) invBtns[i].image.sprite = getSpriteForGO(Globals.inventory[i]);
                else invBtns[i].image.sprite = null;
            }
            else if (i == 1)
            {
                if (i < countim) invBtns[i].image.sprite = getSpriteForGO(Globals.inventory[i]);
                else invBtns[i].image.sprite = null;
            }
            else if (i == 2)
            {
                if (i < countim) invBtns[i].image.sprite = getSpriteForGO(Globals.inventory[i]);
                else invBtns[i].image.sprite = null;
            }
        }
        UMenu.transform.SetParent(null);
        Globals.isglobalVisible = false;
        Globals.isInv = true;
        UMenu.SetActive(false);
        invMenu.SetActive(true);
        invMenu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 20f;
        invMenu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        invMenu.transform.SetParent(Camera.main.transform);
    }

    private Sprite getSpriteForGO(GameObject g)
    {
        if (g.tag == "apple") return Apple;
        else if (g.tag == "peach") return Pear;
        else if (g.tag == "fish") return Fish;
        else if (g.tag == "fishbbq") return Fishbbq;
        else if (g.tag == "chickenbbq") return Chickenbbq;
        else if (g.tag == "steakbbq") return Steakbbq;
        return null;
    }

    private void flyHigh(){
        UMenu.transform.SetParent(null);
        Globals.isglobalVisible = false;
        UMenu.SetActive(false);
        transform.position= new Vector3(transform.position.x,120f,transform.position.z);
        //Globals.ToggleBoundaries(true);
        Globals.isFly = true;
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

    private void toggleWeather(){
        weather = (weather + 1)%5;
        if (weather == 0)
        {
            rain.SetActive(false);
            RenderSettings.skybox = Morning;
            weatherText.text = "Morning";
        }
        else if(weather == 1)
        {
            rain.SetActive(false);
            RenderSettings.skybox = Night;
            weatherText.text = "Night";
        }
        else if(weather == 2)
        {
            rain.SetActive(false);
            RenderSettings.skybox = Sunset;
            weatherText.text = "Sunset";
        }
        else if(weather == 3){
            rain.SetActive(false);
            RenderSettings.skybox = Cloudy;
            weatherText.text = "Cloudy";
        }
        else{
            rain.SetActive(true);
            RenderSettings.skybox = Cloudy;
            weatherText.text = "Rain";
        }
    }

    private void highlight(int ind){
        foreach(Button obj in GlobalBtns){
            obj.GetComponent<Image>().color = Color.white;
        }
        GlobalBtns[ind].GetComponent<Image>().color = Color.yellow;
    }

    private void closeGlobalMenu(){
        ind = 0;
        highlight(0);
        UMenu.transform.SetParent(null);
        Globals.isglobalVisible = false;
        reticle.transform.localScale = new Vector3(1,1,1);
        UMenu.SetActive(false);
        cm.enabled = true;
    }

    public void closeTeleportMenu(){
        teleindex = 0;
        HighlightButton(teleindex);
        teleportmenu.transform.SetParent(null);
        Globals.isTeleport = false;
        reticle.transform.localScale = new Vector3(1,1,1);
        teleportmenu.SetActive(false);
        cm.enabled = true;
    }

    public void closeInventory(){
        invInd = 0;
        highlightInv(invInd);
        invMenu.transform.SetParent(null);
        Globals.isInv = false;
        reticle.transform.localScale = new Vector3(1,1,1);
        invMenu.SetActive(false);
        cm.enabled = true;
    }

    IEnumerator ReEnableAxes() {
        yield return new WaitForSeconds(0.2f);
        nextAxInp = true;
    }

    IEnumerator DropObj() {
        isGrabbed = false;
        grabbedObj.transform.SetParent(null);
        Rigidbody rb = grabbedObj.AddComponent<Rigidbody>();
        rb.mass = 2f;
        rb.useGravity = true;
        grabbedObj = null;
        yield return new WaitForSeconds(5f);
        Destroy(rb);
    }

    public void HighlightButton(int index)
    {
        foreach (Button b in teleportbuttons)
        {
            b.image.color = Color.white;
        }
        teleportbuttons[index].image.color = Color.yellow;
    }

    public void highlightInv(int ind){
        foreach (Button b in invBtns)
        {
            b.image.color = Color.white;
        }
        invBtns[ind].image.color = Color.yellow;
    }
}
