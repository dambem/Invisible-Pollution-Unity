﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiscript : MonoBehaviour
{
    public GameObject activeChecker1;
    public GameObject activeChecker2;
    public GameObject[] showObjects; 
    public GameObject objectHider;
    private bool found = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((activeChecker1.activeSelf || activeChecker2.activeSelf) && !found)
        {
            objectHider.SetActive(false);
            foreach (GameObject show in showObjects)
            {
                show.SetActive(true);
            }
            found = true;
        }
    }
}
