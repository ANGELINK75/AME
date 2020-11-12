using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed;

    public float grabReach;
    public float jumpForce;

    public Transform cameraTransform;
    public Transform playerTransform;
    public float SmoothTime;

    private bool flag;
    private Vector3 velocity = Vector3.zero;
    private Vector3 Offset;
    private Rigidbody player;
    Vector3 jump = Vector3.up * 10f;
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
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!flag)
            {
                if (FindClosestObjectWithinRadius(grabReach))
                {
                    CustomTags objectToMove = FindClosestObjectWithinRadius(grabReach).GetComponent<CustomTags>() as CustomTags;
                    objectToMove.Rename(0, "selected");
                    Debug.Log(objectToMove.GetAtIndex(0));
                    flag = true;
                }
            }
            else
            {
                if (FindClosestObjectWithinRadius(grabReach))
                {
                    CustomTags objectToMove = FindClosestObjectWithinRadius(grabReach).GetComponent<CustomTags>() as CustomTags;
                    objectToMove.Rename(0, "unselected");
                    Debug.Log(objectToMove.GetAtIndex(0));
                    flag = false;
                }
            }
            

        }
        //code for the camera to follow the player
        Vector3 targetPosition = playerTransform.position + Offset;
        //targetPosition = Vector3.Scale(targetPosition, new Vector3(1, .2f, 1));  
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, targetPosition, ref velocity, SmoothTime);

        transform.LookAt(playerTransform);
    }

    public GameObject FindClosestObjectWithinRadius(float distance)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Grabbable");
        GameObject closest = null;
        
        Vector3 position = transform.position;
        if(gos.Length == 0)
        {
            return null;
        }
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
