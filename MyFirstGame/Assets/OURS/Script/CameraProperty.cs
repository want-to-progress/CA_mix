using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProperty : MonoBehaviour
{
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;

    int state = 1;
    int radius = 3;
    float rotationDegreeY = 0;
    float rotationDegreeX = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            state = (state + 1) % 3 + 1;
        }


        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            radius--;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            radius++;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationDegreeY -= 0.5f;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rotationDegreeY += 0.5f;
        }

        if (Input.GetKey(KeyCode.UpArrow) && rotationDegreeX < 45)
        {
            rotationDegreeX += 0.5f;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && rotationDegreeX > -30)
        {
            rotationDegreeX -= 0.5f;
        }

        rotationDegreeY = rotationDegreeY % 360;
        rotationDegreeX = rotationDegreeX % 360;
        Vector3 RotationRadius = -Vector3.forward * 2 * radius + Vector3.up * radius;

        RotationRadius = Quaternion.AngleAxis(rotationDegreeX, Vector3.right) * RotationRadius;
        RotationRadius = Quaternion.AngleAxis(rotationDegreeY, Vector3.up) * RotationRadius;
        
        if (state == 1)
        {
            transform.position = char1.transform.position + RotationRadius;
            transform.LookAt(char1.transform.position + Vector3.up * radius);
        }
        else if (state == 2)
        {
            transform.position = char2.transform.position + RotationRadius;
            transform.LookAt(char2.transform.position + Vector3.up * radius);
        }
        else
        {
            transform.position = char3.transform.position + RotationRadius;
            transform.LookAt(char3.transform.position + Vector3.up * radius);
        }

    }
}
