using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * speed * 10);
        //transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime);

        if (transform.eulerAngles.y == 180)
        {
            if (transform.position.z > 14 && speed < 0)
            {
                speed *= -1;
            }
            else if (transform.position.z < -14 && speed > 0)
            {
                speed *= -1;
            }
        }
        else
        {
            if (transform.position.z > 14 && speed > 0)
            {
                speed *= -1;
            }
            else if (transform.position.z < -14 && speed < 0)
            {
                speed *= -1;
            }
        }
        
    }
}
