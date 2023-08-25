using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Bullet_Prefab;
    public Transform Barrel;

    public float timeToFire;
    public float fireRate;
    public float bullet_Speed;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void Fire()
    {
        GameObject g = Instantiate(Bullet_Prefab, Barrel.position, Quaternion.identity);
        g.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bullet_Speed);
    }
}
