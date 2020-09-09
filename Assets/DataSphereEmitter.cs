using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class DataSphereEmitter : MonoBehaviour
{
    public ParticleSystem system;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        system.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = Color.black }, 1); ;
    }
}
