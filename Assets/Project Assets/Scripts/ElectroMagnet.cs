using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroMagnet : MonoBehaviour
{
    [Range(4.0f, 2000.0f)]
    public float MagnetForce;

    Magnet[] m_magnets;
    void OnValidate()
    {
        if (m_magnets == null)
        {
            return;
        }
        foreach(var m in m_magnets)
        {
            m.MagnetForce = MagnetForce
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_magnets = GetComponentsInChildren<Magnet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
