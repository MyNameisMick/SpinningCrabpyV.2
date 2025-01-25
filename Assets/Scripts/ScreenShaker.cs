using System.Collections;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    //Transform target;
    //Vector3 initialPos;
    //float shakeDuration = 0f;
    //bool isShaking = false;

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    target = GetComponent<Transform>();
    //    initialPos = transform.localPosition;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if(shakeDuration > 0 && !isShaking)
    //    {
    //        StartCoroutine(DoShake());
    //    }
    //}

    //public void Shake(float duration)
    //{
    //    if(duration > 0)
    //    {
    //        shakeDuration += duration;
    //    }
    //}

    //IEnumerator DoShake()
    //{
    //    isShaking = true;
    //    var startTime = Time.realtimeSinceStartup;

    //    while(Time.realtimeSinceStartup < startTime + shakeDuration)
    //    {
    //        var randomPoint = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), initialPos.z);
    //        target.localPosition = randomPoint;
    //        yield return null;
    //    }

    //    shakeDuration = 0f;
    //    target.localPosition = initialPos;
    //    isShaking = false;
    //}

    [SerializeField]
    float shakeduration = 0.1f;

    [SerializeField]
    float shakeAmount = 0.2f;
    bool isShaking = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShakeIt();
        }
    }

    public void ShakeIt()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        if (isShaking)
        {
            yield return null;
        }

        isShaking = true;
        Vector3 originPos = transform.localPosition;

        float elapsed = 0.0f;
        
        while(elapsed < shakeduration)
        {
            float x = Random.Range(-1f, 1f) * shakeAmount;
            float y = Random.Range(-1f, 1f) * shakeAmount;

            transform.localPosition = new Vector3(originPos.x + x, originPos.y + y, originPos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originPos;
        isShaking = false;
    }
}
