using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ----- ATTRIBUTES -----

    private Color initColorPlayer;
    private Vector3 initScalePlayer;
    private Vector3 currentPosPlayer;

    private Transform currentTransformCamera;



    // ----- UNITY METHODS -----

    // Start is called before the first frame update
    void Start()
    {
        initColorPlayer = gameObject.GetComponent<MeshRenderer>().material.color;
        initScalePlayer = transform.localScale;

        currentTransformCamera = GameObject.Find("Main Camera").GetComponent<Camera>().transform;

        // Force player position/orientation (0.5m in front of the camera) and scale. Color is reset by TestDistanceForColor()
        resetPlayer(currentTransformCamera, initScalePlayer);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosPlayer = transform.position;
        currentTransformCamera = GameObject.Find("Main Camera").GetComponent<Camera>().transform;

        if (Input.GetKeyDown("space"))
            resetPlayer(currentTransformCamera, initScalePlayer);
        
        // Change color of Player based on distance to camera
        float distance = Vector3.Distance(currentPosPlayer, currentTransformCamera.position);
        gameObject.GetComponent<MeshRenderer>().material.color = TestDistanceForColor(distance);
    }

    // ----- OTHER METHODS -----

    Color TestDistanceForColor(float distance)
    {
        Color outputColor;

        if (distance >= 1.0f && distance < 2.0f)
            outputColor = Color.green;

        // Orange
        else if (distance >= 2.0f && distance < 3.0f)
            outputColor = new Color32(255, 165, 0, 255);

        else if (distance >= 3.0f)
            outputColor = Color.red;

        else
            outputColor = initColorPlayer;

        return outputColor;
    }

    // Places the Player 0.5m in front of the camera, straight, regardless of the orientation of the camera, and resets its scale. Color is reset by TestDistanceForColor() in Update().
    void resetPlayer(Transform camTransform, Vector3 scale)
    {
        // Reset player scale
        transform.localScale = scale;

        // Set player position to camera position
        transform.position = camTransform.position;

        // Set player orientation to camera orientation
        transform.rotation = camTransform.rotation;

        // Move player forward by 0.5m 
        transform.Translate(0, 0, 0.5f);
    }

} // class
