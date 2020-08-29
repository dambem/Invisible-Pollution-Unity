using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Leap.Unity;
using Leap.Unity.Interaction;
using System.Diagnostics;
using System.Reflection;

public class submitButton : MonoBehaviour
{
    public GameObject resetButton;
    bool submit = false;
    InteractionButton interactionBehaviour1;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Submit()
    {
        submit = true; 
    }
    // Update is called once per frame
    void Update()
    {
        interactionBehaviour1 = resetButton.GetComponent<InteractionButton>();
        interactionBehaviour1.OnPress += Submit;
        
        if (submit)
        {
            SceneManager.LoadScene("MainScreen");
        }

    }
}
