using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    public float currentValue;

    [SerializeField]
    private UnityEvent onDestroyObstacle;

    private Renderer rend;


    private void OnMouseDown()
    {
        transform.localScale /= 2;
        //rend.material.color = Color.red;
        GetDamage(0.1f);
    }
    private void OnMouseUp()
    {
        transform.localScale *= 2;
        //rend.material.color = Color.white;
    }

    IEnumerator Recolor()
    {


        rend.material.color = Color.Lerp(Color.red, Color.white, 0f);
        yield return null;
 

    }

    private float GetDamage(float value)
    {
        currentValue -= value;
        
        if (currentValue <= 0f)
        {
            Debug.Log($"Ты умер! {currentValue}");
            OnDestroy();
        }

        return currentValue;
    }


    private void OnDestroy()
    {
        StartCoroutine(Recolor());
        
    }

   


    void Start()
    {
        rend = GetComponent<Renderer>();
        onDestroyObstacle.AddListener(() => Destroy(gameObject, 3));
    }


    [ContextMenu("Получить урон")]
    void Activate()
    {
       
        

    }

    void Update()
    {
        
    }
}
