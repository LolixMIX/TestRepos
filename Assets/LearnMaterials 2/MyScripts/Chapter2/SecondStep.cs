using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStep : SampleScript
{
    private Vector3 temp = new Vector3(90, 0, 0);
    private Vector3 local;
    [Range(0f,10)]
    public float xSpeed;
    [Range(0f, 10)]
    public float ySpeed;
    [Range(0f, 10)]
    public float zSpeed;
    public override void Use()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(xSpeed, ySpeed, zSpeed) * 10 * Time.deltaTime);
        
        if (local == temp)
        {
            Debug.Log("Вы прошли 90 градусов");
        }
    }

    private void Start()
    {
        
    }
    void Update()
    {
        Use();
    }
}
