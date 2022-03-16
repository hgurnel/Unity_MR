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
        // Get player initial color and scale for later, when we press the button to reset its configuration
        initColorPlayer = gameObject.GetComponent<MeshRenderer>().material.color;
        initScalePlayer = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosPlayer = transform.position;
        currentTransformCamera = GameObject.Find("Main Camera").GetComponent<Camera>().transform;

        if (Input.GetKeyDown("space"))
            resetPlayer(currentTransformCamera);
        
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

        else if (distance >= 2.0f && distance < 3.0f)
            outputColor = new Color32(255, 165, 0, 255);

        else if (distance >= 3.0f)
            outputColor = Color.red;

        else
            outputColor = initColorPlayer;

        return outputColor;
    }

    // Places the Player 0.5m in front of the camera, regardless of the orientation of the camera
    void resetPlayer(Transform camTransform)
    {
        // Reset player scale
        transform.localScale = initScalePlayer;

        // Set player position to camera position
        transform.position = camTransform.position;

        // Set player orientation to camera orientation
        transform.rotation = camTransform.rotation;

        // Move player by 0.5m along its forward vector
        transform.Translate(0, 0, 0.5f);
    }

} // class
