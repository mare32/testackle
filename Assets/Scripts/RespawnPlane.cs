using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlane : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided");
        if (other.tag == "Player")
        {
            //Debug.Log("Collided with a game object with the tag Player");
            //Debug.Log(other.transform.position);
            other.transform.position = new Vector3(136.8f, 4.9f, -98f);
            //Debug.Log(other.transform.position);
            //Debug.Log("After transforming");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Collided");
        if (other.tag == "Player")
        {
            //Debug.Log("Collided with a game object with the tag Player");
            //Debug.Log(other.transform.position);
            other.transform.position = new Vector3(136.8f, 4.9f, -98f);
            //Debug.Log(other.transform.position);
            //Debug.Log("After transforming");
        }
        else if(other.tag == "Camera")
        {
            player.transform.position = new Vector3(136.8f, 4.9f, -98f);
        }
    }
}
