using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Follow : MonoBehaviour
{
    public Transform parent;

    private Vector3 pointingTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointingTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.back * Camera.main.transform.position.z);
        transform.LookAt(pointingTarget, Vector3.up);
        
    }
}
