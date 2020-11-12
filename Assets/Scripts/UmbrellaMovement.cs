using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class UmbrellaMovement : MonoBehaviour
{
    public Transform player;
    public Transform umbrellaParent;
    public float rotationSpeed;
    
    private Vector3 _umbrellaRotationEuler;
    private Quaternion _umbrellaRotation;
    // Start is called before the first frame update
    void Start()
    {
        _umbrellaRotation = umbrellaParent.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        umbrellaParent.position = player.position;

        if (Input.GetKey(KeyCode.E))
        {

            _umbrellaRotationEuler.z -= 1*rotationSpeed;
            _umbrellaRotation.eulerAngles = _umbrellaRotationEuler;
            umbrellaParent.rotation = _umbrellaRotation;
        }
        if (Input.GetKey(KeyCode.Q))
        {

            _umbrellaRotationEuler.z += 1*rotationSpeed;
            _umbrellaRotation.eulerAngles = _umbrellaRotationEuler;
            umbrellaParent.rotation = _umbrellaRotation;
        }
    }
}
