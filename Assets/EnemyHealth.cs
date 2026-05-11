using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 3;
    int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(1);
            }

            Destroy(gameObject);
        }
    }
}