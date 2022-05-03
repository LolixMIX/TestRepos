using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{

    public InteractiveBox Next;
    private Transform _currentPosition;

    public Transform Pointer;

    private void AddNext(InteractiveBox box)
    {
        if (Next != null)
        {
            Next = box;
        }

    }

    public void RayCastDraw()
    {

        if (Next != null)
        {
            Ray ray = new Ray(transform.position, Next.transform.position - transform.position);
            RaycastHit hit;
            //Debug.DrawLine(transform.position, Next.transform.position - transform.position, Color.red);
            //Debug.DrawLine(transform.position, transform.forward, Color.yellow);

            if (Physics.Raycast(ray, out hit))
            {
                Pointer.position = hit.point;
                Debug.Log("Hit");
            }

            
        }
        

    }












    void Start()
    {

    }


    void Update()
    {
        RayCastDraw();
    }
}
