using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardControl : MonoBehaviour
{
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;

    public stateMech s;
    int jump_cnt = 0;
    int dodge_cnt = 0;
    int look_cnt = 0;
    float rotationDegree;
    int frame;
    bool push = false;
    Vector3 movement = Vector3.zero;
    Vector3 lookAT = Vector3.zero;

    //bool together = true;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            s.state = (s.state + 1) % 3 + 1;
        }

        movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) movement += Vector3.forward;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left;
        if (Input.GetKey(KeyCode.S)) movement -= Vector3.forward;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right;
        lookAT = movement;

        if (Input.GetKeyDown(KeyCode.Space) && jump_cnt == 0) jump_cnt = 100;

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (dodge_cnt <= 0) dodge_cnt = 80;
        }
        if (Input.GetKeyDown(KeyCode.Q) && look_cnt == 0) look_cnt = 200;
        if (Input.GetKey(KeyCode.P)) push = true;
        else push = false;

        if (Input.GetKey(KeyCode.LeftArrow)) rotationDegree -= 0.5f;
        else if (Input.GetKey(KeyCode.RightArrow)) rotationDegree += 0.5f;

        if (Input.GetKeyDown(KeyCode.T)) s.together = !s.together;
    }

    void FixedUpdate()
    {
        movement = movement * 0.3f;
        if(jump_cnt > 20 && jump_cnt < 30)
        {
            movement += movement * 0.08f;
        }
        else if (jump_cnt > 30 && jump_cnt < 70) {
            
            movement += Vector3.up * 0.08f;
        }
        else if(jump_cnt > 0 && jump_cnt < 20 || jump_cnt > 70)
        {
            movement = Vector3.zero;

        }

        if (jump_cnt > 0)
        {
            jump_cnt--;
        }

        if (push)  movement = movement * 0.3f;

        if(look_cnt > 0)
        {
            movement = Vector3.zero;
            look_cnt--;
        }

        if(dodge_cnt > 0)
        {
            movement = Vector3.zero;
            dodge_cnt--;
        }

        movement = Quaternion.AngleAxis(rotationDegree, Vector3.up) * movement;
        lookAT = Quaternion.AngleAxis(rotationDegree, Vector3.up) * lookAT;

        if (s.state == 1)
        {
            char1.transform.LookAt(char1.transform.position + lookAT);
            char1.transform.position = char1.transform.position + movement;
            if (s.together)
            {
                if (Vector3.Distance(char1.transform.position, char2.transform.position) > 5.0f &&
                   Vector3.Distance(char1.transform.position, char3.transform.position) > 5.0f)
                {
                    char2.transform.position += (char1.transform.position - char2.transform.position) * 0.05f;
                    char3.transform.position += (char1.transform.position - char3.transform.position) * 0.05f;
                }
            }
            char2.transform.LookAt(char1.transform.position);
            char3.transform.LookAt(char1.transform.position);
        }
        else if (s.state == 2)
        {
            char2.transform.LookAt(char2.transform.position + lookAT);
            char2.transform.position = char2.transform.position + movement;
            if (s.together)
            {
                if (Vector3.Distance(char2.transform.position, char1.transform.position) > 5.0f &&
               Vector3.Distance(char2.transform.position, char3.transform.position) > 5.0f)
                {
                    char1.transform.position += (char2.transform.position - char1.transform.position) * 0.05f;
                    char3.transform.position += (char2.transform.position - char3.transform.position) * 0.05f;
                }
            }
            char1.transform.LookAt(char2.transform.position);
            char3.transform.LookAt(char2.transform.position);
        }
        else
        {
            char3.transform.LookAt(char3.transform.position + lookAT);
            char3.transform.position = char3.transform.position + movement;
            if (s.together)
            {
                if (Vector3.Distance(char3.transform.position, char1.transform.position) > 5.0f &&
               Vector3.Distance(char3.transform.position, char2.transform.position) > 5.0f)
                {
                    char1.transform.position += (char3.transform.position - char1.transform.position) * 0.05f;
                    char2.transform.position += (char3.transform.position - char2.transform.position) * 0.05f;
                }
                
            }
            char1.transform.LookAt(char3.transform.position);
            char2.transform.LookAt(char3.transform.position);
        }
    }
}
