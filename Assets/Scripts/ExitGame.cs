using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitGameButton()
    {
        Debug.Log("ออกเกม");
        UnityEditor.EditorApplication.isPlaying = false;

            // สำหรับการรันใน Build จริง
            Application.Quit();

    }
}
