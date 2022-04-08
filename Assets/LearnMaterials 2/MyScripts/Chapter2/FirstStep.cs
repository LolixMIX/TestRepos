using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStep : SampleScript
{
    public Vector3 originPos;
    public Vector3 localPos;
    public Vector3 endPos;
    public float progress;

    public float speed;


    private void Start()
    {
        Application.targetFrameRate = 30;
        originPos = transform.position;
        Use();
    }

    [ContextMenu("Активировать скрипт")]
    public override void Use()
    {
        originPos = transform.position;


        if (originPos != endPos)
        {
            transform.position = Vector3.Lerp(originPos, endPos, progress);
            progress += speed;
        }
        else
        {

            progress = 0;

        }
    }


    void Update()
    {
        Use();

    }
}
