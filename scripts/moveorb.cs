using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveorb : MonoBehaviour
{
    // Adds Moving control Keys in component
    public KeyCode moveL;
    public KeyCode moveR;

    
    public float horizVel = 0; // how fast it changes before being stopped
    public int laneNum = 2;  // Keep inside right and left border
    public string controllocked = "n"; // to lock the keys until the lane change is complete
    
    public Transform boomObj;

    static public bool isDead = false;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update position of the orb every frame
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.verVel, 4);

        // Input to Change to left and right lane
        if ((Input.GetKeyDown(moveL)) && (laneNum > 1) && (controllocked == "n"))
        {
            horizVel = -3.5f;
            StartCoroutine (stopSlide());
            laneNum -= 1;
            controllocked = "y";
        }
        else if ((Input.GetKeyDown(moveR)) && (laneNum < 3) && (controllocked == "n"))
        {
            horizVel = 3.5f;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controllocked = "y";
        }

    }

    // For collision
    private void OnCollisionEnter(Collision other)
    {
        // For obstacles
        if(other.gameObject.tag == "Lethal")
        {
            Destroy(gameObject);
            GM.zVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            isDead = true;
            gameOver.SetActive(true); // Add a GameOver Scene
            

        }
        
        // For powerups
        if (other.gameObject.name == "Capsule")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GM.coinTotal++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "DownRampBottomTrigger")
        {
            GM.verVel = 0;
        }

        if (other.gameObject.name == "DownRampTopTrigger")
        {
            GM.verVel = -1.7f;
        }

        if (other.gameObject.name == "RampBottomTrigger")
        {
            GM.verVel = 1.7f;
        }

        if (other.gameObject.name == "RampTopTrigger")
        {
            GM.verVel = 0;
        }
    }


    // Once you go left/right, stop after you reach left or right border
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.25f);
        horizVel = 0;
        controllocked = "n";
    }
}
