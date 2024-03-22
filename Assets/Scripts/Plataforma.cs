using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform PontoA;
    public Transform PontoB;
    public float Speed;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = PontoB.position;
        transform.position = targetPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        if(distance < 0.1f)
        {
            if(targetPosition == PontoA.position )
            {
                targetPosition = PontoB.position;
            }
            else
            {
                targetPosition = PontoA.position;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
