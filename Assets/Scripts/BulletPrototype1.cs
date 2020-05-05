using UnityEngine;
using System.Collections;
public class BulletPrototype1 : MonoBehaviour
{
    public float maxSpeed = 25f;
    public Rigidbody2D bullet;
    public float[] xPositions;
    public float[] yPositions;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            /*
             * Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
            bulletInstance.velocity = transform.forward * maxSpeed;
            */
            int randX = Random.Range(0, xPositions.Length);
            int randY = Random.Range(0, yPositions.Length);
            Vector3 randPosition = new Vector3(xPositions[randX], yPositions[randY], transform.position.z);

            Instantiate(bullet, randPosition, Quaternion.identity);
        }
    }
}