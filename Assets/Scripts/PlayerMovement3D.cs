using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float baseSpeed = 6f;
    public float speed = 6f;
    public CharacterController controller;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule emission;

    private void Start()
    {
        speed = baseSpeed;
        ps = GetComponent<ParticleSystem>();
        emission = ps.emission;
        emission.enabled = false;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Move in a direction relative to camera
        if (direction.magnitude >= 0.1f)
        {
            //Move Towards Camera
            //float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        // Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // Velocity Reset after landing
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
     public IEnumerator ChangeSpeed(float speed,float durationInSeconds)
    {
        this.speed += speed;
        emission.enabled = true;
        yield return new WaitForSeconds(durationInSeconds);
        this.speed -= speed;
        if(this.speed == baseSpeed)
        emission.enabled = false;
    }
}
