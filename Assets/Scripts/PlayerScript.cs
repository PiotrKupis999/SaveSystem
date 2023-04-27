using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction;

            
        if((direction = Input.GetAxis("Horizontal")) != 0)
        {
            rb.AddForce(new Vector3(direction,0,0));
        }
        if ((direction = Input.GetAxis("Vertical")) != 0)
        {
            rb.AddForce(new Vector3(0, 0, direction));
        }
    }


}
