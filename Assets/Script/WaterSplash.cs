using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    AudioNonInteractiveObject waterAudio;

    [SerializeField] float a, b;

    bool once = true;

    private void Awake()
    {
        waterAudio = GetComponent<AudioNonInteractiveObject>();
    }

    private void Update()
    {
        float y = Mathf.Lerp(a, b, WaterShape.blendShape/100);

        if(GameManager.playerController4.transform.position.y<y && once)
        {
            waterAudio.PlayAudioClip();
            once = false;
        }
        else if(GameManager.playerController4.transform.position.y > y)
        {
            once = true;
        }
    }

}
