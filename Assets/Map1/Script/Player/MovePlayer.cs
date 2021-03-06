using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    void Update()
    {

        Debug.Log("무브 플레이어");
         
        float h = Input.GetAxisRaw("Horizontal"); //좌우 입력. -1이 왼쪽. 1이 오른쪽
        float v = Input.GetAxisRaw("Vertical"); //상하 입력. -1이 아래, 1이 위
        if (!(h == 0 && v == 0)) //방향키를 입력한경우
        {
            Vector3 move = new Vector3(h, 0, v); //볼 방향을 가리킨다.
            Quaternion dir = Quaternion.LookRotation(move.normalized);//해당 방향을 보도록 회전하는 Quaternion 변수 생성
            dir.x = 0; //몸체 방향은 y축만 회전하면 되므로 x,z축은 0으로 강제고정.
            dir.z = 0;
            transform.rotation = dir;//현재 객체의 방향을 생성한 Quaternion 변수로 맞춤. 
        }
    }

}

