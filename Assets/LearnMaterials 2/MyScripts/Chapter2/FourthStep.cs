using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthStep : SampleScript
{

    [SerializeField]
    [Range(0f, 5f)]
    private float destroyDelay;
    [SerializeField]
    private int minimalDestroyingObjectsCount;
    private Transform myTransform;


    private Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField]
    [Range(0f, 5f)]
    private float changeSpeed;
    private Vector3 defaultScale;


    [SerializeField]
    private bool toDefault;

    private void Start()
    {
        myTransform = transform;
        defaultScale = myTransform.localScale;
        toDefault = false;
    }
    private void Awake()
    {
        myTransform = transform;
    }

    [ContextMenu("Активация скрипта")]
    public void ActivateModule()
    {
        Vector3 target = toDefault ? defaultScale : targetScale;
        StopAllCoroutines();

        toDefault = !toDefault;

        StartCoroutine(DestroyRandomChildObjectCoroutine(target));
    }

    private IEnumerator DestroyRandomChildObjectCoroutine(Vector3 target)
    {
        Vector3 start = myTransform.lossyScale;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * changeSpeed;
            myTransform.localScale = Vector3.Lerp(start, target, t);
            yield return null;
        }
        myTransform.localScale = target;
        while (myTransform.childCount > minimalDestroyingObjectsCount)
        {
           


            int index = Random.Range(0, myTransform.childCount - 1);
            Destroy(myTransform.GetChild(index).gameObject);
            yield return new WaitForSeconds(destroyDelay);
        }
        Destroy(gameObject, Time.deltaTime);
    }
    private void Update()
    {

    }

    public override void Use()
    {
        ActivateModule();
    }
}
