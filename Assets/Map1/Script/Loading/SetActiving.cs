using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiving : MonoBehaviour
{

    public void isSet()
    {
        this.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("isSet", 4);
    }

}
