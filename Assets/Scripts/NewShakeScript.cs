using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NewShakeScript : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    void Start()
    {
        if (virtualCamera != null)
        {
            noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }

    public void ShakeScreen(float amplitudeGain, float frequencyGain, float shakeTime)
    {
        if (noise != null)
        {
            noise.m_AmplitudeGain = amplitudeGain;
            noise.m_FrequencyGain = frequencyGain;
            Invoke("StopShake", shakeTime);
        }
    }

    private void StopShake()
    {
        if (noise != null)
        {
            noise.m_AmplitudeGain = 0f;
            noise.m_FrequencyGain = 0f;
        }
    }
}
