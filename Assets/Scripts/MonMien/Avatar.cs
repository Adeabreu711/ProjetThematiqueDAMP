using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CameraFollow;

public class Avatar : MonoBehaviour
{
    Vector2 avatarMove;
    public float maxSpeed;

    Rigidbody2D avatarRB;

    public float speed;

    Renderer capsuleRenderer;

    public ColorState state;

    public enum ColorState
    {
        red,
        blue,
        green
    }

    // Start is called before the first frame update
    void Start()
    {
        avatarRB = GetComponent<Rigidbody2D>();

        capsuleRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        ColorChange();
    }

    void Move()
    {
        avatarMove = Vector2.right * speed;

        if (avatarRB.velocity.x <= maxSpeed && avatarRB.velocity.y <= maxSpeed)
        {
            avatarRB.AddForce(avatarMove, ForceMode2D.Force);
            Debug.Log(avatarRB.velocity);
        }
 

    }

    void ColorChange()
    {
        if (state == ColorState.red)
        {
            capsuleRenderer.material.SetColor("_Color", Color.red);
            gameObject.tag = "Red";
        }

        if (state == ColorState.green)
        {
            capsuleRenderer.material.SetColor("_Color", Color.green);
            gameObject.tag = "Green";
        }

        if (state == ColorState.blue)
        {
            capsuleRenderer.material.SetColor("_Color", Color.blue);
            gameObject.tag = "Blue";
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == gameObject.tag)
        {
            Destroy(gameObject);
        }

    }
}
