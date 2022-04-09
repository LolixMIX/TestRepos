using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStep : SampleScript
{
    [Range(0, 10)]
    public int step;

    [Range(0, 1)]
    public int xMove;
    [Range( 0, 1)]
    public int yMove;
    [Range(0, 1)] 
    public int zMove;

    

    [SerializeField]
    private bool _key = false;

    [ContextMenu("Активировать скрипт")]
    public override void Use()
    {
        _key = true;
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(xMove, yMove, zMove) * step * Time.deltaTime);
        
        if (transform.rotation == Quaternion.Euler(new Vector3(90, 0, 0)))
        {
            Debug.Log("Вы прошли 90 градусов");
            _key = false;
        }
    }

    private void Start()
    {
        
    }
    void Update()
    {
        if (_key)
        {
            Use();
        }
    }
}
