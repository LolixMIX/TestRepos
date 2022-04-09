using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStep : SampleScript
{
    private Vector3 startPos;
    public Vector3 endPos = new Vector3(3,0,0);

    public float speed;

    [SerializeField]
    private bool _key = false;

    private void Start()
    {
        Application.targetFrameRate = 30;
        startPos = transform.position;
    }


    [ContextMenu("Активировать скрипт")]
    public override void Use()
    {
        _key = true;
        transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

        if (endPos == transform.position)
        {
            Debug.Log("Успех");
            _key = false;
        }
    }



    void Update()
    {
        if (_key)
        {
            Use();
        }  
    }
}
