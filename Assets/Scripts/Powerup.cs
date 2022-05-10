using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] public PlayerMovement3D playerMovement;
    [SerializeField] public float boostValue = 2f;
    [SerializeField] public float durationInSeconds = 3f;
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
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(playerMovement.ChangeSpeed(boostValue,durationInSeconds));
            this.transform.position = new Vector3(Random.Range(9000,10000), Random.Range(9000, 10000), Random.Range(9000, 10000));
            StartCoroutine(SelfDestruct());
        }
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(durationInSeconds + 1f);
        Destroy(this.gameObject);
    }
}
