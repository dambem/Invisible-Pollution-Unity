using Leap.Unity;
using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class homeTravel : MonoBehaviour
{
    public Transform target;
    public float speed;
    public GameObject objectReference;
    public GameObject objectToMove;
    public GameObject[] objectsToHide;
    public Boolean pressed = false;
    public GameObject[] objectsToShow;

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
            float step = speed * Time.deltaTime;
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
