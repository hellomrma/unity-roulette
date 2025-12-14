using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotateSpeed = 0f;

    public bool isRotating = false;
    public bool isRotateEnded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isRotating == false && isRotateEnded == true)
        {
            // rotateSpeed = 10f;

            isRotating = true;
            isRotateEnded = false;

            rotateSpeed = Random.Range(15f, 30f);

            // Unity Random 함수
            // float Random.Range(float minInclusive, float maxInclusive);
            // int Random.Range(int minInclusive, int maxExclusive);



        }
        transform.Rotate(0,0, rotateSpeed);

        rotateSpeed *= 0.98f;
        Debug.Log(rotateSpeed);

        if (rotateSpeed <= 0.05f)
        {
            rotateSpeed = 0f;

            isRotateEnded = true;
            isRotating = false;
        }
        else { 

        }
    }
}
