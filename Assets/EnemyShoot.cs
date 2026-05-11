using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    float timer = 0f;
    float machineGunTimer = 0f;
    bool isMachineGun = false;
    int machineGunCount = 0;
    void Update()
    {
        timer += Time.deltaTime;
        machineGunTimer += Time.deltaTime;

        float interval = 0.5f;

        if (GameManager.instance != null)
        {
            int score = GameManager.instance.score;

            if (score <= 10)
            {
                interval = 1.0f;
            }
            else
            {
                interval = 0.3f;
            }

            // スコア11以上でマシンガン解放
            if (score >= 11 && machineGunTimer >= 5f)
            {
                isMachineGun = true;
                machineGunCount = 0;
                machineGunTimer = 0f;
            }
        }

        // 通常射撃
        if (!isMachineGun && timer >= interval)
        {
            Shoot();
            timer = 0f;
        }

        // マシンガン処理
        if (isMachineGun)
        {
            if (timer >= 0.1f)
            {
                Shoot();
                timer = 0f;
                machineGunCount++;

                if (machineGunCount >= 15)
                {
                    isMachineGun = false;
                }
            }
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}