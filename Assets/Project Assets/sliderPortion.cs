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
    public ParticleSystem system;
    public GameObject submitButton;
    public InteractionSlider leapSlider;
    public TextMesh cigaretteAmount;
    public TextMesh mortalityReduction;
    public TextMesh chosenValue;
    public TextMesh actualValue;
    public TextMesh actualReduction;
    public Color light = new Color(0.255f, 0.140f, 0.066f);
    public Color medium = new Color(0.255f, 0.242f, 0.117f);
    public Color high = new Color(0.255f, 0.060f, 0.056f);
    public Color bigdanger = new Color(0.026f, 0f, 0.006f);
    public Color safe = new Color(1f, 1f, 1f);
    bool submit = false;
    public GameObject sliderColor;
    public Material foggingMat;
    public GameObject fogger;
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

        //foggingMat.SetFloat("_Density", densityCalc(sliderVal));
        if (sliderVal >= 10)
        {
            system.Emit(new ParticleSystem.EmitParams() { position = UnityEngine.Random.onUnitSphere, startColor = Color.black, startSize = (sliderVal / 200f) }, 1); ;

        }

        cigaretteAmount.text = cigarettes.ToString() + " Cigarettes Per Week";
        mortalityReduction.text = lifeSpan(sliderVal, sliderVal) + " Months that could be gained if adhering to WHO standards";
        fogger.SetActive(true);
        if (submit)
        {
            foreach (GameObject objecttoHide in objectsToHide)
            {
                objecttoHide.SetActive(false);
            }
            chosenValue.text = cigarettes.ToString() + " Cigarettes Per Week";
            actualValue.text = CalculateCigarettes(pm2) + " Cigarettes Per Week";
            actualReduction.text = lifeSpan(pm10, pm2) + " Months that could be gained \n if adhering to WHO standards";
            foreach (GameObject objecttoshow in objectsToShow)
            {
                objecttoshow.SetActive(true);
            }
            submit = false;

        }
    }
    float lifeSpan(float PM10, float PM2)
    {
        float validPM10 = 20f;
        float validPM2 = 12f;
        float PM10inc = (PM10 - validPM10) / 10.0f;
        float PM2inc = (PM2 - validPM2) / 10.0f;
        if (PM10inc < 0.0f && PM2inc < 0.0f)
        {
            return (0.0f);
        }
        else
        {
            return (Mathf.Round((PM10inc * 7.0f) + (PM2inc * 12.0f)));
        }
    }
    float densityCalc(float sliderVal)
    {
        return ((-2f * (sliderVal / 100f)) + 2);
    }
    Color ColorOnValue(float value)
    {
        if (value >= 20 && value < 40)
        {
            return light;
        }
        if (value >= 40 && value < 60)
        {
            return medium;
        }
        if (value >= 60 && value < 80)
        {
            return high;
        }
        if (value >= 80 && value < 100)
        {
            return bigdanger;
        }
        else
        {
            return safe;
        }
    }
    float CalculateCigarettes(float pm2val)
    {
        float base_level = 22.0f;
        float pm2_per_week = (pm2val * 7.0f) / base_level;
        return (Mathf.Round(pm2_per_week));
    }
}
