using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float bulletSpeed;
    public float shootingInterval;
    public Sprite bulletSprite;
    public float bulletLifespan;
    private float lastShotTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastShotTime + shootingInterval)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }
    void Shoot()
    {
        GameObject bullet = new GameObject("TurretBullet");
        Transform bulletTransform = bullet.GetComponent<Transform>();
        bulletTransform.position = transform.position;
        TempBullet bulletScript = bullet.AddComponent<TempBullet>();
        Rigidbody2D rigidbody = bullet.AddComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        CapsuleCollider2D capsuleCollider = bullet.AddComponent<CapsuleCollider2D>();
        capsuleCollider.isTrigger = true;
        rigidbody.isKinematic = true;
        bulletScript.sourceParentName = gameObject.transform.root.name;
        bulletScript.speed = bulletSpeed;
        bulletScript.lifespan = bulletLifespan;
        bulletScript.angle = transform.rotation.eulerAngles[2] + 90;
        SpriteRenderer spriteRenderer = bullet.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = bulletSprite;
    }
}
