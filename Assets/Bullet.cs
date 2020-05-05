using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("AutoDelete");
    }

    //moves backwards at a constant speed
    private void Update()
    {
        rb.velocity = Vector3.up * speed;
        Debug.Log(rb.velocity);
    }

    IEnumerator AutoDelete()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
