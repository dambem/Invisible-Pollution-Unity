using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity;
using Leap.Unity.Interaction;
using System.Diagnostics;
using System.Reflection;

public class sliderPortion : MonoBehaviour
{
    public string location = "Sheffield";
    public float pm2 = 20;
    public float pm10 = 20;
    public GameObject[] objectsToHide;
    public GameObject[] objectsToShow;
    public GameObject submitButton;
    public InteractionSlider leapSlider;
    public UnityEngine.UI.Text cigaretteAmount;
    public UnityEngine.UI.Text chosenValue;
    public UnityEngine.UI.Text actualValue;
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
        interactionBehaviour1 = submitButton.GetComponent<InteractionButton>();

        interactionBehaviour1.OnPress += Submit;

        float sliderVal = leapSlider.HorizontalSliderValue;
        float cigarettes = CalculateCigarettes(sliderVal);
        cigaretteAmount.text = cigarettes.ToString();
        if (submit)
        {
            foreach (GameObject objecttoHide in objectsToHide)
            {
                objecttoHide.SetActive(false);
            }
            foreach (GameObject objecttoshow in objectsToShow)
            {
                objecttoshow.SetActive(true);
            }

        }
    }

    float CalculateCigarettes(float pm2val)
    {
        float base_level = 22.0f;
        float pm2_per_week = (pm2val * 7.0f) / base_level;
        return (Mathf.Round(pm2_per_week));
    }
}
