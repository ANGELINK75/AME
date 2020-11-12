using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private float speed = 2.8f;
    private CustomTags taggedObject;
    // Start is called before the first frame update
    void Start()
    {
       taggedObject =  GetComponent<CustomTags>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taggedObject.GetAtIndex(0).Equals("selected"))
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
        }
    }
}
