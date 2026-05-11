using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float boostSpeed = 10f;
    public float boostDuration = 1.5f;
    public float cooldownTime = 3f;

    public GameObject bulletPrefab;

    float currentSpeed;
    bool isBoosting = false;
    bool isCooldown = false;

    float boostEndTime;
    float cooldownEndTime;

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        // 横移動
        float x = Input.GetAxis("Horizontal");
        transform.Translate(x * currentSpeed * Time.deltaTime, 0, 0);

        // 画面外に出ないようにする
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f);
        transform.position = pos;

        // 弾発射（スペース）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }

        // ブースト開始（Bキー）
        if (Input.GetKeyDown(KeyCode.B) && !isBoosting && !isCooldown)
        {
            isBoosting = true;
            currentSpeed = boostSpeed;
            boostEndTime = Time.time + boostDuration;
        }

        // ブースト終了
        if (isBoosting && Time.time >= boostEndTime)
        {
            isBoosting = false;
            currentSpeed = normalSpeed;

            isCooldown = true;
            cooldownEndTime = Time.time + cooldownTime;
        }

        // クールタイム終了
        if (isCooldown && Time.time >= cooldownEndTime)
        {
            isCooldown = false;
        }
    }
}