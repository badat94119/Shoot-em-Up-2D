using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Controller>())
        {
            Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
