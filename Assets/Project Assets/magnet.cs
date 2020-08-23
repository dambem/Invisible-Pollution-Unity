using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class magnet : MonoBehaviour
{
    bool inside;
    float radius = 5f;
    float force = 100f;
    Transform magnetObj;
    // Start is called before the first frame update
    void Start()
    {
        magnetObj = GameObject.Find("Magnet").GetComponent<Transform>();
        inside = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.GameObject.tag == "Magnet")
        {
            inside = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Magnet")
        {
            inside = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inside)
        {
            Vector3 magnetField = magnetObj.position - transform.position;
            float index = (radius - magnetField.magnitude) / radius;
            AddForce(force * magnetField * index);
        }
    }
}
