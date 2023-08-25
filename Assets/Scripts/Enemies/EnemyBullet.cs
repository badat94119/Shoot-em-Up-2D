using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyWhenOffScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);

        if (screenPosition.x <0 || screenPosition.x > mainCamera.pixelWidth ||
            screenPosition.y < 0 || screenPosition.y > mainCamera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
