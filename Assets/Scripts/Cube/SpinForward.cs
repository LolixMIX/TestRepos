using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinForward : MonoBehaviour
{
    private void Start()
    {

        Application.targetFrameRate = 10;

    }
    [Range( 0, 100)]
    public float speed;

    private void Update()
    {
        
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(1, 3, 0.5f) * speed * Time.deltaTime);

        /*
        float x;
        float y;
        float z; 
         
        x += Time.deltaTime * 10;
        y += Time.deltaTime * 10;
        z += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(x, y, z);

         */


    }
}
