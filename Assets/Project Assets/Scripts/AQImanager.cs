using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Diagnostics;

public class AQImanager : MonoBehaviour
{
    public sliderPortion slider1;
    public sliderPortion slider2;
    public sliderPortion slider3;
    public int AQI = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fetchAQI());
        AirQualityObject = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator fetchAQI()
    {
        UnityEngine.Debug.Log("Fetching AQI");
        UnityWebRequest www = UnityWebRequest.Get("http://api.waqi.info/feed/Sheffield/?token=3d23ae70180b539813cf9dbc45744037d482065d");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            UnityEngine.Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            string jsonString = www.downloadHandler.text;
            json = JsonUtility.FromJson(jsonString);
            UnityEngine.Debug.Log(json);


        }
        UnityWebRequest www2 = UnityWebRequest.Get("http://api.waqi.info/feed/Los%20Angeles/?token=3d23ae70180b539813cf9dbc45744037d482065d");
        yield return www2.SendWebRequest();

        if (www2.isNetworkError || www2.isHttpError)
        {
            UnityEngine.Debug.Log(www2.error);
        }
        else
        {
            // Show results as text
            string jsonString = www.downloadHandler.text;

        }
        UnityWebRequest www3 = UnityWebRequest.Get("http://api.waqi.info/feed/Delhi/?token=3d23ae70180b539813cf9dbc45744037d482065d");
        yield return www3.SendWebRequest();

        if (www3.isNetworkError || www3.isHttpError)
        {
            UnityEngine.Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            string jsonString = www.downloadHandler.text;

        }
    }


    }
