using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    
    public float jumpForce;
    
    public Transform cameraTransform;
    public Transform playerTransform;
    public float SmoothTime = 0.3f;
    
    private Vector3 velocity = Vector3.zero;
    private Vector3 Offset;
    private Rigidbody player;
    Vector3 jump = Vector3.up*10f;
        // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        
        
        Offset = cameraTransform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        //movement for the player character
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed*Time.deltaTime,0,0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
        
        //code for the camera to follow the player
        Vector3 targetPosition = playerTransform.position + Offset;
        //targetPosition = Vector3.Scale(targetPosition, new Vector3(1, .2f, 1));  
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, targetPosition, ref velocity, SmoothTime);
        
        transform.LookAt(playerTransform);
    }
}
