using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{

    public GameObject Prefab;

    private TestInterBox _currentBox;

    void Start()
    {

    }



    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.tag == ("InteractivePlane"))
                {
                    Instantiate(Prefab, hit.point + new Vector3(0, 0.5f), Quaternion.identity);
                }

                if (hit.collider.gameObject.GetComponent<TestInterBox>())
                {

                    if (_currentBox != hit.collider.gameObject.GetComponent<TestInterBox>() && _currentBox)
                    {
                        hit.collider.gameObject.GetComponent<TestInterBox>().AddNext(_currentBox);
                        Debug.Log($"Добавил: {_currentBox}");
                    }   
                    _currentBox = hit.collider.gameObject.GetComponent<TestInterBox>();
                    Debug.Log($"Запомнил: {_currentBox}");

                    //hit.collider.gameObject.GetComponent<TestInterBox>().AddNext(_currentBox);
                    //Debug.Log($"Добавил: {_currentBox}");

                }


            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.GetComponent<TestInterBox>())
                {
                    Destroy(hit.collider.gameObject);
                }

            }



        }


    }


}
