using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f; // พลังชีวิตของ Target

    public void TakeDamage(float damage)
    {
        health -= damage; // ลดพลังชีวิตตามความเสียหาย
        if (health <= 0f)
        {
            Die(); // ถ้าพลังชีวิตหมด ให้เรียกฟังก์ชัน Die
        }
    }

    void Die()
    {
        Destroy(gameObject); // ทำลาย GameObject เมื่อพลังชีวิตหมด
    }
}
