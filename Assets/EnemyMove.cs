using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 3f;
    public float moveRange = 3f;

    float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * moveRange;
        transform.position = new Vector3(startX + x, transform.position.y, 0);
    }
}