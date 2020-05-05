using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    private GameObject target;
    public string targetName;
    public float speed;
    public float shootingInterval;
    public Sprite bulletSprite;
    private float lastShotTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(targetName);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaVector = target.transform.position - transform.position;
        if (transform.position != target.transform.position)
        {
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector3.up, deltaVector));
        }
        if (deltaVector.magnitude > speed * Time.deltaTime) // prevents ship from rapidly changing directions when it's over its target
        {
            //transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector3.up, deltaVector));
            transform.position += deltaVector / deltaVector.magnitude * speed * Time.deltaTime;
        }
        else // places ship at target's location if it is within the distance it travels in one tick
        {
            transform.position = target.transform.position;
        }

        if (Time.time > lastShotTime + shootingInterval)
        {
            Shoot(/*Vector2.SignedAngle(Vector3.up, deltaVector)*/transform.rotation.eulerAngles[2] + 90);
            lastShotTime = Time.time;
        }
    }

    void Shoot(float angle)
    {
        GameObject bullet = new GameObject("FollowShipBullet");
        Transform bulletTransform = bullet.GetComponent<Transform>();
        bulletTransform.position = transform.position;
        TempBullet bulletScript = bullet.AddComponent<TempBullet>();
        bulletScript.speed = 1f;
        bulletScript.lifespan = 3f;
        bulletScript.angle = angle;
        SpriteRenderer spriteRenderer = bullet.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = bulletSprite;
    }
}
