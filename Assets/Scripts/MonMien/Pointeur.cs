using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Pointeur : MonoBehaviour
{
    public Transform playerPosition;

    public Vector3 startPosition;

    public float speedForward;
    public float speedVertical;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vInput = Input.GetAxis("Vertical") * speedVertical;        

        transform.position = transform.position + transform.up * speedForward * Time.deltaTime;
        //transform.position = transform.position + transform.up * vInput;

    }
}
