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
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(136.8f, 4.9f, -98f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(136.8f, 4.9f, -98f);
        }
        else if(other.tag == "Camera")
        {
            player.transform.position = new Vector3(136.8f, 4.9f, -98f);
        }
    }
}
