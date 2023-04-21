using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, ISparkTarget
{

    [SerializeField] GameObject hitPrefab;

    public void Hit(Vector3 pos)
    {
        if (hitPrefab != null)
        {
            GameObject hit = Instantiate(hitPrefab, transform);
            hit.transform.position = pos;
            hit.transform.rotation = Quaternion.identity;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
