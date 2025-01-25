using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string name_scene;
    public void ChangeScene()
    {
        SceneManager.LoadScene(name_scene); // เปลี่ยนไปยัง Scene ที่กำหนด
    }
}