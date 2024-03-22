using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCai : MonoBehaviour
{
    Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    IEnumerator cair()
    {
        yield return new WaitForSeconds(0.3f);
        rig.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(cair());
        }
    }
}
