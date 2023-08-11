using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawner : MonoBehaviour
{
    public GameObject Bullet_Prefab;
    public Transform Barrel;

    public float TimeToStart;
    public float TimeBetween_Waves;
    public float bullet_Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeToStart -= Time.deltaTime;
        if (TimeToStart <= 0)
        {
            Spawn_Bullet();
            TimeToStart += TimeBetween_Waves;
        }
    }

    public void Spawn_Bullet()
    {
        GameObject g = Instantiate(Bullet_Prefab, Barrel.position, Quaternion.identity);
        g.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bullet_Speed);
    }
}
