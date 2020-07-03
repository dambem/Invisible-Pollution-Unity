using Leap.Unity;
using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class initialtravel : MonoBehaviour
{
    public Transform target;
    public float speed;
    public GameObject objectReference;
    public GameObject objectToMove;
    public Boolean pressed= false;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var interactionBehaviour = objectReference.GetComponent<InteractionBehaviour>();
        interactionBehaviour.OnContactBegin += () =>
        {
            pressed = true;
        };
        if (pressed)
        {
            float step = speed * Time.deltaTime;
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, target.position, step);
            if (transform.position == target.position)
            {
                pressed = false;
            }
        }
    }
}
