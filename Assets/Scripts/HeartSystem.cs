using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public int heartCount;
    public Sprite heartContainer;
    public Image[] heartImage;

    public SceneChanger SceneChanger;

    void Update()
    {
        if (heartCount == 0)
        {
            SceneChanger.ChangeScene();
        }

        if (heartCount < 1)
        {
            heartImage[0].sprite = heartContainer;
        }
        else if (heartCount < 2)
        {
            heartImage[1].sprite = heartContainer;
        }
        else if (heartCount < 3)
        {
            heartImage[2].sprite = heartContainer;
        }
    }

    public void TakeDamage()
    {
        heartCount--;
    }
}
