using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        Debug.Log("Player HP: " + currentHP);

        if (currentHP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("ゲームオーバー");
        }
    }
}