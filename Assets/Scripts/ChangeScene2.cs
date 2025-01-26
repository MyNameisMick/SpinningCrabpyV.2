using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2 : MonoBehaviour
{
    public string name_scene2;
    public void ChangeScene()
    {
        SceneManager.LoadScene(name_scene2); // เปลี่ยนไปยัง Scene ที่กำหนด
    }
}
