using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBullet : MonoBehaviour
{
    public float speed;
    public float lifespan; // in seconds
    public float angle;
    public string sourceParentName;
    private Vector3 movementVector;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = new Vector3(Mathf.Cos(angle * Mathf.PI / 180), Mathf.Sin(angle * Mathf.PI / 180)); // magnitude 1
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector3.up, movementVector));
        movementVector *= speed;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementVector * Time.deltaTime;
        if (Time.time > startTime + lifespan)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.root.name != sourceParentName)
        {
            Destroy(gameObject);
        }
    }
}
