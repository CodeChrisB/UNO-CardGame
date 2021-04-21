using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public Material[] cards;
    private int i;
    void Start()
    {
        LeanTween.delayedCall(0.5f, ChangeMaterial);
    }

    private void ChangeMaterial()
    {
        i++;
        gameObject.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = cards[i%4];
        LeanTween.delayedCall(1f, ChangeMaterial);

    }
}
