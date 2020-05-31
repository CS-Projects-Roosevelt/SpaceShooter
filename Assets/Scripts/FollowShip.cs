using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    private GameObject target;
    public string targetName;
    public float speed;
    public float shootingInterval;
    public float distanceToMaintain;
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
        if (deltaVector.magnitude > speed * Time.deltaTime + distanceToMaintain) // prevents ship from rapidly changing directions when it's over its target & from getting too close
        {
             transform.position += deltaVector / deltaVector.magnitude * speed * Time.deltaTime;
        }
        else // places ship at target's location if it is within the distance it travels in one tick
        {
               transform.position += deltaVector / deltaVector.magnitude * Mathf.Max(deltaVector.magnitude - distanceToMaintain, 0); //Mathf.max prevents ship from backing away when target gets too close
        }

        if (Time.time > lastShotTime + shootingInterval)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject bullet = new GameObject("FollowShipBullet");
        Transform bulletTransform = bullet.GetComponent<Transform>();
        bulletTransform.position = transform.position;
        TempBullet bulletScript = bullet.AddComponent<TempBullet>();
        bulletScript.speed = 15f;
        bulletScript.lifespan = 3f;
        bulletScript.angle = transform.rotation.eulerAngles[2] + 90;
        SpriteRenderer spriteRenderer = bullet.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = bulletSprite;
    }
}
