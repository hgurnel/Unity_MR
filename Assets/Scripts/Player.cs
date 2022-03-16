using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ----- ATTRIBUTES -----

    private Color initColorPlayer;
    private Transform initTransformPlayer;
    private Vector3 currentPosPlayer;

    private Vector3 currentPosCamera;

    // ----- METHODS -----

    // Start is called before the first frame update
    void Start()
    {
        // Get player initial (color, transform) for later, when we press the button to reset its configuration
        initColorPlayer = gameObject.GetComponent<MeshRenderer>().material.color;
        initTransformPlayer = transform;       
    }

    // Update is called once per frame
    void Update()
    {
        // Change color of Player based on distance to camera
        float distance = DistancePlayerCam();
        gameObject.GetComponent<MeshRenderer>().material.color = TestDistanceForColor(distance);
    }

    float DistancePlayerCam()
    {
        currentPosPlayer = transform.position;
        currentPosCamera = GameObject.Find("Main Camera").GetComponent<Camera>().transform.position;

        float distance = Vector3.Distance(currentPosPlayer, currentPosCamera);

        Debug.Log("Distance = " + distance);

        return distance;
    }

    Color TestDistanceForColor(float distance)
    {
        Color outputColor;

        if (distance >= 1.0f && distance < 2.0f)
        {
            Debug.Log("Green");
            outputColor = Color.green;
        }
        else if (distance >= 2.0f && distance < 3.0f)
        {
            Debug.Log("Orange");
            outputColor = new Color32(255, 165, 0, 255);
        }
        else if (distance >= 3.0f)
        {
            Debug.Log("Red");
            outputColor = Color.red;
        }
        else
        {
            Debug.Log("Init color");
            outputColor = initColorPlayer;
        }

        return outputColor;
    }

    void resetPlayerPosition()
    {

    }

} // class
