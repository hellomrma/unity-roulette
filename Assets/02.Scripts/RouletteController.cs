using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotateSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotateSpeed = 10f;
        }
        transform.Rotate(0,0, rotateSpeed);

        rotateSpeed *= 0.996f;
        Debug.Log(rotateSpeed);

        if (rotateSpeed <= 0.1f)
        {
            rotateSpeed = 0f;
            Debug.Log("정지됨");
        }
        else { 
            Debug.Log("회전중");
        }
    }
}
