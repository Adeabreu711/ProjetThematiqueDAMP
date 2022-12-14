using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Pointeur : MonoBehaviour
{
    public Transform playerPosition;

    public Vector3 offset;

    public float ratio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vInput = Input.GetAxis("Vertical") * ratio;

        Vector2 curseurDeplacement = new Vector2(playerPosition.position.x +5, playerPosition.position.y);
        



        /* Vector3 defaultPosition = playerPosition.position + offset;
        Vector3 newPosition = new Vector3(defaultPosition.x, defaultPosition.y + vInput, defaultPosition.z);

        //Vector3 finalPosition = defaultPosition + ; */

        transform.position = curseurDeplacement;
    }
}
