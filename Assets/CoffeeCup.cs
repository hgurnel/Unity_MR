using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCup : MonoBehaviour
{
    private float movementX, movementZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementKeyboard();
    }

    public void movementKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementZ = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementX, 0f, movementZ) * Time.deltaTime;
    }

    public void changeColor()
    {

    }
}
