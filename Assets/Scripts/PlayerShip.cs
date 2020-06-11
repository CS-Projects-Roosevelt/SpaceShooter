using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float speed;
    public GameObject camera;
    private Vector2 velocity;
    public Sprite bulletSprite;
    private const float shotDelay = 0.5f;
    private float lastShotTime = -shotDelay;
    private int health = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        velocity = new Vector2(horizontalInput, verticalInput) * speed;
        float facingAngle = (Vector2.SignedAngle(Vector2.up, velocity) + 360) % 360; //last part makes sure the angle is positive (necessary for next line to work)
        velocity *= Mathf.Cos(((facingAngle + 45) % 90 - 45) * Mathf.PI / 180); //accounts for the fact that a 1,1 vector has greater magnitude than 1,0 (prevents player from going faster diagonally)
        if (velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, facingAngle)); //.lookat; .direction
        }
        transform.position += (Vector3)velocity * Time.deltaTime;

        camera.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        //shooting
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShotTime + shotDelay)
        {
            Shoot();
            lastShotTime = Time.time;
        }

        //health
        GameObject.Find("Canvas").GetComponent<UserInterface>().SetHealth(health);
    }

    private void Shoot()
    {
        GameObject bullet = new GameObject("PlayerBullet");
        Transform bulletTransform = bullet.GetComponent<Transform>();
        bulletTransform.position = transform.position;
        TempBullet bulletScript = bullet.AddComponent<TempBullet>();
        Rigidbody2D rigidbody = bullet.AddComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        CapsuleCollider2D capsuleCollider = bullet.AddComponent<CapsuleCollider2D>();
        capsuleCollider.isTrigger = true;
        rigidbody.isKinematic = true;
        bulletScript.sourceParentName = gameObject.transform.root.name;
        bulletScript.speed = velocity.magnitude + 25f;
        bulletScript.lifespan = 2f;
        bulletScript.angle = transform.rotation.eulerAngles[2] + 90;
        SpriteRenderer spriteRenderer = bullet.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = bulletSprite;
    }
    public void TakeDamage(int amount) {
        health -= amount;
    }
}
