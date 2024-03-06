using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // Start is called before the first frame update
    bool flag = false;
    [SerializeField] GameObject flash;
    void Start()
    {
        flash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            if(flag == false)
            {
                flash.SetActive(true);
                flag = false;
            }
            else
            {
                flash.SetActive(false);
                flag = true;
            }

        }
        
    }
}
