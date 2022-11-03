using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private CharacterController controller;
    private Vector3 direction;
    private Vector3 lastDie;
    private float speedRun;
    public float maxSpeed;
    public Animator animator;
    private bool isSliding;

    [Header("Lane Movement")]
    [SerializeField] private int desiredLane = 1;
    [SerializeField] private float laneDistance = 4;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float Gravity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        if (speed < maxSpeed)
        {
            speed += 0.1f * Time.deltaTime;
        }
        
        direction.z = speed;
        

        if(controller.isGrounded)
        {
            if(SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else{
            direction.y += Gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }

        if(SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        else if(SwipeManager.swipeLeft){
            desiredLane--;
            if(desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if(transform.position == targetPosition)
            return;
        
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void FixedUpdate() 
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            Time.timeScale = 0;
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Obstacle")
    //     {
    //         PlayerManager.gameOver = true;
    //         Time.timeScale = 0;
    //     }
    // }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        yield return new WaitForSeconds(1.3f);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }
}
