using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNAKE : MonoBehaviour
{
    private Vector2 direction = Vector2.right;

    private List<Transform> segments;
    public Transform segmentsPrefab;

    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(transform);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
    }

    private void FixedUpdate()
    {
        for(int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x) + direction.x, Mathf.Round(transform.position.y) + direction.y, 0);
    }

    private void grow()
    {
        Transform segment = Instantiate(segmentsPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
    private void resetgame()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(transform);

        transform.position = Vector3.zero;
               
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food")
        {
            grow();
        }
        else if (collision.tag == "obs")
        {
            resetgame();
        }
    }
}
