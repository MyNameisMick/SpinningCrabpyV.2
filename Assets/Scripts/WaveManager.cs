using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // ทำให้ WaveManager เป็น Singleton
    public static WaveManager instance;

    // ตัวแปรที่กำหนดลักษณะของคลื่น
    public float amplitude = 1f; // ความสูงของคลื่น
    public float length = 2f;    // ความยาวของคลื่น
    public float speed = 1f;     // ความเร็วของคลื่น
    public float offset = 0f;    // การเลื่อนตำแหน่งของคลื่น

    private void Awake()
    {
        // ตรวจสอบว่ามีอินสแตนซ์อยู่แล้วหรือไม่
        if (instance == null)
        {
            instance = this; // กำหนดอินสแตนซ์แรก
        }
        else if (instance != this)
        {
            
            Destroy(this); // ทำลายอินสแตนซ์ซ้ำ
        }
    }

    private void Update()
    {
        // อัปเดตค่า offset ตามเวลาและความเร็ว
        offset += Time.deltaTime * speed;
    }

    // ฟังก์ชันคำนวณความสูงของคลื่นที่ตำแหน่ง x
    public float GetWaveHeight(float x)
    {
        
        return amplitude * Mathf.Sin(x / length + offset);
    }
}
