using UnityEngine;
using UnityEngine.UI; // สำหรับ Text
using TMPro; // ถ้าใช้ TextMeshPro
using System; // สำหรับ Action

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // เวลาถอยหลังเริ่มต้น (วินาที)
    public TextMeshProUGUI countdownText; // Text UI ธรรมดา
    // public TextMeshProUGUI countdownText; // ใช้แทนถ้าเป็น TextMeshPro

    public SceneChanger SceneChanger; // Event สำหรับเรียกเมื่อเวลาหมด

    private float timeLeft;

    void Start()
    {
        timeLeft = countdownTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime; // ลดเวลาตามเวลาจริง
            countdownText.text = "Laundry finished in : " + Mathf.Ceil(timeLeft).ToString(); // แสดงเวลาที่เหลือแบบปัดขึ้น
        }
        else
        {
            SceneChanger.ChangeScene();
        }
    }
}