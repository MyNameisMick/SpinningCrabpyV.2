using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerBywall : MonoBehaviour
{
    public string name_scene;
    private void OnTriggerEnter(Collider other)
    {
        // เช็คว่า object ที่ชนมี tag เป็น "Wall" หรือไม่
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(name_scene); // เปลี่ยนไปยัง Scene ที่กำหนด
            Debug.Log("Player เข้าชน Wall ");
        }
    }
    
    
}
