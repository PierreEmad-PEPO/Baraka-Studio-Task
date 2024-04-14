using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fpsText;

    float frameCount = 0;
    float nextUpdate = 0.0f;
    float fps = 0.0f;
    float updateRate = 4.0f;

    private void Start()
    {
        nextUpdate = Time.time;
    }

    void Update()
    {
        frameCount++;
        if (Time.time > nextUpdate)
        {
            nextUpdate += 1.0f / updateRate;
            fps = frameCount * updateRate;
            fpsText.text = (int)fps + " FPS";
            frameCount = 0;
        }

    }

}
