using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInterBox : MonoBehaviour
{

    public TestInterBox Next;


    public void AddNext(TestInterBox box)
    {
        if (Next is null)
        {
            Next = box;
        }
        else
        {
            Debug.Log("Переменная занята");
        }
    }


    public void DrawRayCast()
    {
        if (Next != null)
        {

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
            
            Debug.DrawLine(transform.position, Next.transform.position, Color.green);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<ObstacleItem>())
                {
                    hit.collider.gameObject.GetComponent<ObstacleItem>().GetDamage(Time.deltaTime);
                }
            }
            

        }



    }



    void Start()
    {

    }


    void Update()
    {
        DrawRayCast();
    }
}
