using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
public class SoccerBall : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float force;
    public GameObject ball;
    public GameObject goal;
    public GameObject character;
    public Vector3 initialposition;
    public Vector3 maxdistance;
    public int score=0;
    public TextMeshProUGUI text;
    public TextMeshProUGUI chance,totaltext;
    public GameObject total,canvasmenu;
    public int chances = 3;
    public AudioSource source;
    void Start()
    {
        initialposition = ball.transform.position;
        maxdistance = goal.transform.position;
        //total.SetActive(false);
        source.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //ball.transform.SetParent(character.transform);
        if (Input.GetButtonDown("js1"))
        {
            //ball.transform.SetParent(null);
            Vector3 shoot = (this.transform.position- Camera.main.transform.position + Camera.main.transform.forward * 10).normalized;
            Debug.Log(shoot);
            //shoot.x = -shoot.x;
            GetComponent<Rigidbody>().AddForce(shoot * force+new Vector3(0,5f,0), ForceMode.Impulse);

        }
        if ((gameObject.transform.position).magnitude > maxdistance.magnitude)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.transform.position = initialposition;
            chances--;
            chance.text = chances.ToString();
        }
        if (chances == 0)
        {
            totaltext = total.GetComponentInChildren<TextMeshProUGUI>();
            totaltext.text = "Your total score is: " + score.ToString();
            canvasmenu.SetActive(false);
            total.SetActive(true);
            Invoke("Exit", 3f);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision occurs");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Soccergoal")
        {
            score++;
            text.text = score.ToString();
            source.Play();
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            chances--;
            chance.text = chances.ToString();
            ball.transform.position = initialposition;

        }
    }
    public void Exit()
    {
#if UNITY_EDITOR
                         UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
