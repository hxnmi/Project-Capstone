using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    [SerializeField] private float speed;

    [Header("Lane Movement")]
    [SerializeField] private int desiredLane = 1;
    [SerializeField] private float laneDistance;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float Gravity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = speed;

        if(controller.isGrounded){
            direction.y = -1;
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                Jump();
            }
        }else{
            direction.y += Gravity * Time.deltaTime;
        }
        

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            desiredLane++;
            if(desiredLane == 3){
                desiredLane = 2;
            }
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            desiredLane--;
            if(desiredLane == -1){
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0){
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2){
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);

        // transform.position = targetPosition;

        Debug.Log(transform.position);
    }

    private void FixedUpdate() {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump(){
        direction.y = jumpForce;
    }
}
