using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    Rigidbody rigidbody;

    float speed = 50f;
    Animator ani;
    Vector3 movement;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        ani = GetComponent<Animator>();


    }

     void Update()
    {

    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        Run(h, v);
        Turn(h, v);
        anis(h, v);


    }
    void Run(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
    }
    void Turn(float h, float v)
    {
        if (h == 0 && v == 0)
            return;
        Quaternion newrotation = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newrotation, 10f);
        }

    void anis(float h, float v)
    {
        if (h == 0 && v == 0)
        {

            ani.SetBool("isRun", false);
        }
        else
        {
            ani.SetBool("isRun", true);
            ani.Play("run");
        }
    }

}




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public Transform Player;
    
    float speed = 40f;
    Rigidbody rigidbody;
    float amtMove;
    float h ; //좌우 입력. -1이 왼쪽. 1이 오른쪽
    float v ; //상하 입력. -1이 아래, 1이 위
    Vector3 movement;



    void Start()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        amtMove = speed * Time.smoothDeltaTime;
        ani = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;

    }

     void Update()
    {
       
    }


    void FixedUpdate()
    {
  

       


    }

    void Turn()
    {
        if (h == 0 && v == 0)
            return;
        Quaternion newrotation = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newrotation, 1f);
        }
}]
*/
