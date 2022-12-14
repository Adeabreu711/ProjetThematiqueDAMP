using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine1 : MonoBehaviour
{
    public GameObject linePrefabs;
    public GameObject currentLine;

    public Transform cursor;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;

    // Start is called before the first frame update
    void Start()
    {
        CreateLine();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 tempFingerPos = cursor.position;

        if(Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count - 1]) > .1f)
        {
             UpdateLine(tempFingerPos);
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefabs, Vector2.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();

        fingerPositions.Add(cursor.position);
        fingerPositions.Add(cursor.position);

        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);

        edgeCollider.points = fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();
    }
}
