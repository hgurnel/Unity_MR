using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // ----- ATTRIBUTES -----

    // To get a reference to PlayerController.cs
    PlayerController m_player;
    [SerializeField] GameObject playerSenderScript;

    private Transform m_camTransform;
    private Vector3 m_scale;


    // ----- UNITY METHODS -----
    
    private void Awake()
    {
        // Get a reference to PlayerController.cs
        m_player = playerSenderScript.GetComponent<PlayerController>();
    }

    // ----- OTHER METHODS -----

    public void ResetPlayer()
    {
        m_scale = m_player.InitScalePlayer;
        m_camTransform = m_player.CurrentTransformCamera;

        m_player.ResetPlayer(m_camTransform, m_scale);
    }

} // class
