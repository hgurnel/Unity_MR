using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ----- ATTRIBUTES + acessibility modifiers -----

    private Color m_initColorPlayer;

    private Vector3 m_initScalePlayer;
    public Vector3 InitScalePlayer
    {
        get
        {
            return m_initScalePlayer;
        }
        set
        {
            m_initScalePlayer = value;
        }
    }

    private Vector3 m_currentPosPlayer;

    private Transform m_currentTransformCamera;
    public Transform CurrentTransformCamera
    {
        get
        {
            return m_currentTransformCamera;
        }
        set
        {
            m_currentTransformCamera = value;
        }
    }



    // ----- UNITY METHODS -----

    // Start is called before the first frame update
    void Start()
    {
        m_initColorPlayer = gameObject.GetComponent<MeshRenderer>().material.color;
        m_initScalePlayer = transform.localScale;

        m_currentTransformCamera = GameObject.Find("Main Camera").GetComponent<Camera>().transform;

        // Force player position/orientation (0.5m in front of the camera) and scale. Color is reset by TestDistanceForColor().
        ResetPlayer(m_currentTransformCamera, m_initScalePlayer);
    }

    // Update is called once per frame
    void Update()
    {
        m_currentPosPlayer = transform.position;
        m_currentTransformCamera = GameObject.Find("Main Camera").GetComponent<Camera>().transform;
        
        // Change color of PlayerController based on distance to camera
        float distance = Vector3.Distance(m_currentPosPlayer, m_currentTransformCamera.position);
        gameObject.GetComponent<MeshRenderer>().material.color = TestDistanceForColor(distance);
    }

    // ----- OTHER METHODS -----

    public Color TestDistanceForColor(float distance)
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
            outputColor = m_initColorPlayer;

        return outputColor;
    }

    // Places the PlayerController 0.5m in front of the camera, straight, regardless of the orientation of the camera, and resets its scale. Color is reset by TestDistanceForColor() in Update().
    public void ResetPlayer(Transform camTransform, Vector3 scale)
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
