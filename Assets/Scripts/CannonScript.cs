using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public Rigidbody[] projectilePrefab; // Prefab กระสุน
    public float[] spawnRates;           // อัตราการเกิดกระสุนแต่ละประเภท (รวมกันต้องได้ 1 หรือ 100%)
    public Transform spawnPoint;         // จุดที่ยิงกระสุน
    public float shootForce = 1000f;     // แรงยิงกระสุน
    public float shootInterval = 3f;     // ระยะเวลาระหว่างการยิง (3 วินาที)
    public float Destroy_wait = 10f;     // ระยะเวลาก่อนที่กระสุนจะถูกทำลาย

    void Start()
    {
        // ตรวจสอบว่าจำนวน projectilePrefab และ spawnRates ตรงกัน
        if (projectilePrefab.Length != spawnRates.Length)
        {
            Debug.LogError("Projectile Prefab and Spawn Rates arrays must have the same length!");
            return;
        }

        // ยิงกระสุนทุกๆ shootInterval วินาที
        InvokeRepeating("Shoot", 0f, shootInterval);
    }

    void Shoot()
    {
        if (projectilePrefab != null && spawnPoint != null)
        {
            // เลือกกระสุนโดยสุ่มตามอัตรา spawnRates
            int selectedIndex = GetRandomIndexByRates(spawnRates);
            if (selectedIndex < 0 || selectedIndex >= projectilePrefab.Length)
            {
                Debug.LogError("Invalid index selected!");
                return;
            }

            // สร้างกระสุนที่ spawnPoint
            Rigidbody projectileInstance = Instantiate(projectilePrefab[selectedIndex], spawnPoint.position, spawnPoint.rotation);

            // เพิ่มแรงให้กระสุน
            projectileInstance.AddForce(spawnPoint.forward * shootForce);

            // ตั้งให้กระสุนหายไปหลัง Destroy_wait วินาที
            Destroy(projectileInstance.gameObject, Destroy_wait);
        }
        else
        {
            Debug.LogWarning("Projectile Prefab or Spawn Point is not assigned.");
        }
    }

    int GetRandomIndexByRates(float[] rates)
    {
        float total = 0;
        foreach (float rate in rates)
        {
            total += rate;
        }

        float randomValue = Random.Range(0, total);
        float cumulative = 0;

        for (int i = 0; i < rates.Length; i++)
        {
            cumulative += rates[i];
            if (randomValue < cumulative)
            {
                return i;
            }
        }

        return -1; // หากล้มเหลวในการสุ่ม
    }
}
