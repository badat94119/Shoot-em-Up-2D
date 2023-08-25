using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject Bullet_Prefab;

    public Transform Barrel;

    private float fireRate;
    private float timeToFire;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = Random.Range(5.0f, 15.0f);
        timeToFire = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToFire -= Time.deltaTime;
        if (timeToFire <= 0)
        {
            Fire();
            timeToFire += fireRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            Destroy(collision.gameObject);
        }
    }

    public void Fire()
    {
        GameObject g = Instantiate(Bullet_Prefab, Barrel.position, Quaternion.identity);
        g.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 100f);
    }
}
