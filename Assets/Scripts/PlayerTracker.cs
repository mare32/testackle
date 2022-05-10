using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform trackedObject;
    public float maxDistance = 10f;
    public float moveSpeed = 20f;
    public float updateSpeed = 10f;
    [Range(0, 10)]
    public float currentDistance = 5f;
    private string moveAxis = "Mouse ScrollWheel";
    private GameObject ahead;
    private MeshRenderer _renderer;
    public float hideDistance = 1.5f;
    void Start()
    {
        ahead = new GameObject("ahead");
        _renderer = trackedObject.gameObject.GetComponent<MeshRenderer>();
    }

    
    void LateUpdate()
    {
        ahead.transform.position = trackedObject.position + trackedObject.forward * (maxDistance * 0.25f);
        currentDistance += Input.GetAxisRaw(moveAxis) * moveSpeed * Time.deltaTime;
        currentDistance = Mathf.Clamp(currentDistance,0,maxDistance);
        transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + Vector3.up * currentDistance - trackedObject.forward * (currentDistance + maxDistance * 0.5f), updateSpeed * Time.deltaTime);
        //transform.LookAt(ahead.transform);
        _renderer.enabled = (currentDistance > hideDistance);
    }
}
