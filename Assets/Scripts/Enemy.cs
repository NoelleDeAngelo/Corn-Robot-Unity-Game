using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float moveDistance;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingToStart = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + (moveDirection * moveDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if(movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime );
            if(transform.position == startPos)
            {
                movingToStart = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos , speed * Time.deltaTime);
            if(transform.position == targetPos)
            {
                movingToStart = true;
            }
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GameOver();
        }
    }

}
