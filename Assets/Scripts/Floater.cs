using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody; // อ้างอิงถึง Rigidbody ของวัตถุ
    public float depthBeforeSubmerged = 1f; // ระยะจมก่อนที่แรงยกตัวจะเริ่มทำงาน
    public float displacementAmount = 3f; // ปริมาณแรงยกตัว
    public int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    private void FixedUpdate()
    {
        rigidBody.AddForceAtPosition(Physics.gravity / floaterCount,transform.position,ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x) + WaveManager.instance.transform.position.y;
        // ตรวจสอบว่าตำแหน่ง Y ของวัตถุอยู่ใต้น้ำหรือไม่
        if (transform.position.y < waveHeight)
        {
            // คำนวณตัวคูณแรงยกตัวโดยใช้ตำแหน่งที่จม
            float displacementMultiplier = Mathf.Clamp01((waveHeight -transform.position.y) / depthBeforeSubmerged) * displacementAmount;

            // เพิ่มแรงยกตัวในแนวแกน Y
            rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f),transform.position, ForceMode.Acceleration);
            rigidBody.AddForce(displacementMultiplier* -rigidBody.velocity*waterDrag*Time.fixedDeltaTime,ForceMode.VelocityChange);
            rigidBody.AddTorque(displacementMultiplier * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
