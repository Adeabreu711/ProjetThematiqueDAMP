using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Renderer hexagonRenderer;

    public ObstacleColorState state;

    public enum ObstacleColorState
    {
        red,
        blue,
        green
    }

    // Start is called before the first frame update
    void Start()
    {
        hexagonRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ObstacleColorChange();
    }

    void ObstacleColorChange()
    {
        if (state == ObstacleColorState.red)
        {
            hexagonRenderer.material.SetColor("_Color", Color.red);
            gameObject.tag = "Red";
        }

        if (state == ObstacleColorState.green)
        {
            hexagonRenderer.material.SetColor("_Color", Color.green);
            gameObject.tag = "Green";
        }

        if (state == ObstacleColorState.blue)
        {
            hexagonRenderer.material.SetColor("_Color", Color.blue);
            gameObject.tag = "Blue";
        }
    }
}
