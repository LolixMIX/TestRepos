using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    public float currentValue;

    [SerializeField]
    private UnityEvent _onDestroyObstacle;

    private Vector3 startScale = new Vector3(1, 1, 1);
    private Vector3 target = new Vector3(0.5f, 0.5f, 0.5f);

    [SerializeField]
    [Range(0f,10f)]
    private float _speed;
    private Renderer _rend;
    

    private void OnMouseDown()
    {
        GetDamage(1f);
    }
    private void OnMouseUp()
    {
        
   
    }
    private IEnumerator ScaleToDefault()
    {
        float t = 0;
        while (t < 1)
        {
            t += _speed * Time.deltaTime;
            transform.localScale = Vector3.Lerp(target, startScale, t);

            yield return null;
        }
    }
    public float GetDamage(float damage)
    {
        transform.localScale = target;
        if ((currentValue - damage) <= 0)
        {
            
            Debug.Log("Уничтожение");
            currentValue -= damage;

            StartCoroutine(BlinkColor());
            KillObj();
        }
        else
        {
            currentValue -= damage;
        }
        Debug.Log($"Здоровье: {currentValue}");
        StartCoroutine(ScaleToDefault());

        return currentValue;

    }

    public float GetDamage()
    {

        Debug.Log(currentValue);
        StartCoroutine(ScaleToDefault());
        return currentValue;
    }



    [ContextMenu("Kill obj")]
    private void KillObj()
    {
        _onDestroyObstacle.Invoke();
    }
    private IEnumerator BlinkColor()
    {
        float t = 0;
        Debug.Log($"Стартовый цвет: {_rend.material.color}");
        while (t < 1)
        {
            _rend.material.color = new Color(t, 0, 0);
            t += Time.deltaTime;
            
            yield return null;
        }
        Debug.Log($"Конечный цвет: {_rend.material.color}");

    }

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.material.color = Color.white;

        _onDestroyObstacle.AddListener(() => Destroy(gameObject, 2));

        Application.targetFrameRate = 60;
    }
    void Update()
    {
        
        
    }
}
