using Leap.Unity;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class fogging : MonoBehaviour { 

    public GameObject objectReference;
    public GameObject sliderObject;
    public GameObject UIToShow;
    public GameObject textObject;
    public GameObject submitbuttonObject;
    Button submitbutton;
    public GameObject resetbuttonObject;
    Button resetbutton;
    public GameObject[]  objectsToHideOnInitialClick;
    public GameObject[] objectsToShow;
    public GameObject homebuttonObject;
    Button homebutton;
    public GameObject[] objectsToColor;
    public GameObject homeLocation;
    public Color light = new Color(0.255f, 0.140f, 0.066f);
    public Color medium = new Color(0.255f, 0.242f, 0.117f);
    public Color high = new Color(0.255f, 0.060f, 0.056f);
    public Color bigdanger = new Color(0.026f, 0f, 0.006f);
    public Color safe = new Color(1f, 1f, 1f);
    Material material;
    Material colorMaterial;
    Color previousColor;
    Color currentColor;
    public Transform target;
    public float speed;
    bool homePressed = false;
    // Start is called before the first frame update
    void Start()
    {
        submitbutton = submitbuttonObject.GetComponent<Button>();
        submitbutton.onClick.AddListener(TaskOnClick);
        previousColor = safe;
        resetbutton = resetbuttonObject.GetComponent<Button>();
        resetbutton.onClick.AddListener(resetTask);
        homebutton = homebuttonObject.GetComponent<Button>();
        homebutton.onClick.AddListener(homeTask);
    }
    void resetTask()
    {
        SceneManager.LoadScene("MainScreen");
    }
    void homeTask()
    {
        UIToShow.SetActive(false);
        homePressed = true;
    }
    void TaskOnClick()
    {
        UIToShow.SetActive(true);
        foreach (GameObject objectToHide in objectsToHideOnInitialClick)
        {
            objectToHide.SetActive(false);
        }
    }
    string StringOnValue(float value)
    {
        if (value >= 0.2 && value < 0.4)
        {
            return "Light";
        }
        if (value >= 0.4 && value < 0.6)
        {
            return "Medium";
        }
        if (value >= 0.6 && value < 0.8)
        {
            return "High";
        }
        if (value >= 0.8 && value < 1)
        {
            return "Dangerous";
        }
        else
        {
            return "Safe";
        }
    }
    Color ColorOnValue(float value)
    {
        if (value >= 0.2 && value < 0.4)
        {
            return light;
        }
        if (value >= 0.4 && value < 0.6)
        {
            return medium;
        }
        if (value >= 0.6 && value < 0.8)
        {
            return high;
        }
        if (value >= 0.8 && value < 1)
        {
            return bigdanger;
        }   
        else
        {
            return safe;
        }
    }
    // Update is called once per frame
    void Update()
    {
        material = objectReference.GetComponent<Renderer>().sharedMaterial;
        Slider slider = sliderObject.GetComponent<Slider>();
        textObject.GetComponent<UnityEngine.UI.Text>().text = StringOnValue(slider.value);
        if (homePressed)
        {
            float step = speed * Time.deltaTime;
            Vector3 targetDirection = target.position - homeLocation.transform.position;
            homeLocation.transform.position = Vector3.MoveTowards(homeLocation.transform.position, target.position, step);
            if (Vector3.Distance(homeLocation.transform.position, target.position) < 0.1f)
            {
                homePressed = false;
                foreach (GameObject objectToShow in objectsToShow)
                {
                    objectToShow.SetActive(true);
                }

            }

        }

        foreach (GameObject objectToColor in objectsToColor)
        {            
            currentColor = ColorOnValue(slider.value);
            objectToColor.GetComponent<Image>().color = currentColor;
        }
        material.SetFloat("_Density", (1/slider.value)/2);
    }
}
