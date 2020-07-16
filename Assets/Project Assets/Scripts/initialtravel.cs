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
    public float rotspeed = 1.0f;
    public GameObject objectReference;
    public GameObject objectToMove;
    public GameObject[] objectsToHide;
    public Boolean pressed= false;
    public GameObject[] objectsToShow;
    public GameObject rotateTowards;
    
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void makePress()
    {
        pressed = true;
    }
    // Update is called once per frame
    void Update()
    {
        var interactionBehaviour = objectReference.GetComponent<InteractionButton>();
        interactionBehaviour.OnPress += makePress;

        if (pressed)
        {
            Vector3 targetDirection = target.position - objectToMove.transform.position;
            float rotStep = rotspeed * Time.deltaTime;
            float step = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(objectToMove.transform.forward, targetDirection, rotStep, 0.0f);
            objectToMove.transform.rotation = Quaternion.LookRotation(newDirection);
            foreach (GameObject objectToHide in objectsToHide)
            {
                objectToHide.SetActive(false);
            }
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, target.position, step);

            if (Vector3.Distance(objectToMove.transform.position, target.position) < 0.1f)
            {
                pressed = false;
                foreach (GameObject objectToShow in objectsToShow)
                {

                    objectToShow.SetActive(true);
                }

            }
        }
    }
    
    
}
