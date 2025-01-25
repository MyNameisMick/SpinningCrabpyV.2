using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.MaterialProperty;
using System.Collections;
//using DG.Tweening;

public class RotaeWash : MonoBehaviour
{
    // ความเร็วปัจจุบัน
    public float currentRotationSpeed = 0f;

    // ความเร็วสูงสุด
    public float maxRotationSpeed = 300f;

    // อัตราการเปลี่ยนแปลงความเร็ว (การเร่ง/ลด)
    public float transitionRate = 50f;

    // สถานะการหมุน (-1: ถอยหลัง, 0: หยุด, 1: ไปข้างหน้า)
    [Range(-1, 1)] // เพิ่ม Slider ใน Inspector
    public int spinDirection = 0;

    // ใช้จัดการการหยุดและสุ่ม
    private bool isStopped = false;

    void Start()
    {
        // เริ่ม Coroutine ควบคุมเวลา
        StartCoroutine(ControlRotationCycle());
    }

    void Update()
    {
        if (!isStopped)
        {
            // คำนวณเป้าหมายความเร็วจากทิศทาง
            float targetSpeed = spinDirection * maxRotationSpeed;

            // ค่อยๆ เปลี่ยน currentRotationSpeed ให้เข้าใกล้ targetSpeed
            currentRotationSpeed = Mathf.MoveTowards(
                currentRotationSpeed, // ค่าเริ่มต้น
                targetSpeed,          // ค่าเป้าหมาย
                transitionRate * Time.deltaTime // อัตราการเปลี่ยนแปลง
            );
            //Debug.Log("หมุน!!");
            // หมุนวัตถุตามแกน Y ด้วยความเร็วปัจจุบัน
            transform.Rotate(Vector3.forward * currentRotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator ControlRotationCycle()
    {
        while (true)
        {
            // รอ 5–20 วินาที
            float randomWaitTime = Random.Range(5f, 20f);
            yield return new WaitForSeconds(randomWaitTime);

            // หยุดหมุน
            spinDirection = 0;
            isStopped = true;
            Debug.Log("นิ่งไว้");
            // รอ 3–5 วินาทีในสถานะหยุด
            float stopTime = Random.Range(3f, 5f);
            yield return new WaitForSeconds(stopTime);
            if(transitionRate <= 70 && maxRotationSpeed <=100)
            {
                transitionRate += 3;
                maxRotationSpeed += 5;
            }
            
            // สุ่มค่า spinDirection -1 หรือ 1
            spinDirection = Random.Range(0, 2) == 0 ? -1 : 1;
            isStopped = false;
        }
    }
}

