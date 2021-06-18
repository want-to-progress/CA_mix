using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationDisplay : MonoBehaviour
{
    private Animator a;
    public stateMech s;
    int jump_cnt = 0;
    int dodge_cnt = 0;
    int look_cnt = 0;


    bool run = false;
    bool push = false;
    // Start is called before the first frame update
    void Start()
    {
        a = this.GetComponent<Animator>();
    }


    private void Update()
    {
        string str = "char" + s.state;
        if (s.together||this.name == str)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) run = true;
            else run = false;

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                if (dodge_cnt == 0)
                {
                    a.SetTrigger("dodge");
                    dodge_cnt = 80;
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (look_cnt == 0)
                {
                    a.SetTrigger("LookAround");
                    look_cnt = 200;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jump_cnt == 0)
                {
                    a.SetTrigger("jump");
                    jump_cnt = 100;
                }
            }

            if (Input.GetKey(KeyCode.P))
            {
                push = true;
            }
            else
            {
                push = false;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        a.SetBool("run", run);
        if (dodge_cnt != 0) dodge_cnt--;
        if (jump_cnt != 0) jump_cnt--;
        if (look_cnt != 0) look_cnt--;
        a.SetBool("push", push);
    }
}
