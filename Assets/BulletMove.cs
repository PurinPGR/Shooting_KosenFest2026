using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ƒvƒŒƒCƒ„[‚Ì’e ¨ “G
        if (CompareTag("PlayerBullet") && other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(1);

                if (GameManager.instance != null)
                {
                    GameManager.instance.AddScore(1);
                }
            }

            Destroy(gameObject);
        }

        // “G‚Ì’e ¨ ƒvƒŒƒCƒ„[
        if (CompareTag("EnemyBullet") && other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}