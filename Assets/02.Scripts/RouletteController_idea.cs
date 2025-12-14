using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController_idea : MonoBehaviour
{
    public float rotateSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rotateSpeed == 0f)
        {
            rotateSpeed = Random.Range(50f, 100f);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Breakkkkkkkkkkkkkkk~~~~~~~~~");
            rotateSpeed *= 0.2f;
        }

        transform.Rotate(0, 0, rotateSpeed);

        rotateSpeed *= 0.986f;

        if (rotateSpeed <= 0.05f)
        {
            rotateSpeed = 0f;
        }
        else
        {

        }
    }
}
