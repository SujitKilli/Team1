using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Teleportation : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] teleportbuttons;
    public GameObject teleportmenu,garden,mountain,beach;
    public int teleindex = 0;
    public GlobalScript gs;
    private float lasttime;
    public GameObject character;
    void Start()
    {
        teleportbuttons = teleportmenu.GetComponentsInChildren<Button>();
        HighlightButton(teleindex);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("js10"))
        {
            //gs.UMenu.SetActive(false);
            teleportmenu.SetActive(true);
            teleportmenu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 20f;
            teleportmenu.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            teleportmenu.transform.SetParent(Camera.main.transform);
            character.GetComponent<CharacterMovement>().enabled = false;
        }
        if (teleportmenu.activeSelf == true)
            {
                if (Time.time - lasttime > 0.5f)
                {
                    if (Input.GetAxis("Vertical") > 0)
                    {
                        teleindex--;
                        if (teleindex < 0)
                        {
                            teleindex = teleportbuttons.Length - 1;
                        }
                        HighlightButton(teleindex);
                        lasttime = Time.time;
                    }
                    else if (Input.GetAxis("Vertical") < 0)
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
                if(teleindex==0 && Input.GetButtonDown("js1"))
                {
                teleportmenu.transform.SetParent(null);
                teleportmenu.SetActive(false);
                SceneManager.LoadScene("Room");
                }
                else if(teleindex==1 && Input.GetButtonDown("js1"))
                {
                teleportmenu.transform.SetParent(null);
                teleportmenu.SetActive(false);
                character.GetComponent<CharacterMovement>().enabled = true;
                    character.transform.position = garden.transform.position+new Vector3(0,12f,0);
                }
                else if (teleindex == 2 && Input.GetButtonDown("js1"))
                {
                teleportmenu.transform.SetParent(null);
                teleportmenu.SetActive(false);
                character.GetComponent<CharacterMovement>().enabled = true;
                    character.transform.position = beach.transform.position+new Vector3(0, 12f, 0);

                }
                else if (teleindex == 3 && Input.GetButtonDown("js1"))
                {
                teleportmenu.transform.SetParent(null);
                teleportmenu.SetActive(false);
                character.GetComponent<CharacterMovement>().enabled = true;
                 character.transform.position = mountain.transform.position+new Vector3(0, 40f, 10f);

                }
            }

    }
    public void HighlightButton(int index)
    {
        foreach (Button b in teleportbuttons)
        {
            b.image.color = Color.white;
        }
        teleportbuttons[index].image.color = Color.yellow;
    }
}
