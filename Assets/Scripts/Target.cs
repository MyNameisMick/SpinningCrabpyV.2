using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f; // ��ѧ���Ե�ͧ Target

    public void TakeDamage(float damage)
    {
        health -= damage; // Ŵ��ѧ���Ե��������������
        if (health <= 0f)
        {
            Die(); // ��Ҿ�ѧ���Ե��� ������¡�ѧ��ѹ Die
        }
    }

    void Die()
    {
        Destroy(gameObject); // ����� GameObject ����;�ѧ���Ե���
    }
}
