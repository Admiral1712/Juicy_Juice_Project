using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private ParticleSystem _ps;

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    internal void PlayHit()
    {
        _ps.Play();
    }
}
