using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    AudioNonInteractiveObject waterAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waterAudio.PlayAudioClip();
        }
    }

    private void Awake()
    {
        var render = GetComponent<SkinnedMeshRenderer>();
        render.SetBlendShapeWeight(0, 100f);
        Mesh bakeMesh = new Mesh();
        render.BakeMesh(bakeMesh);
        var collider = GetComponent<MeshCollider>();
        collider.sharedMesh = bakeMesh;

        waterAudio = GetComponent<AudioNonInteractiveObject>();
    }

}
