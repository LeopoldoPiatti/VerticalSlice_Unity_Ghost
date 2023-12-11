using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLinealEXTRA : MonoBehaviour
{
    public List<Transform> points;
    public float speed;
    int objective;

    void Start()
    {
        transform.position = points[0].position;
    }
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, points[objective].position);
        if (distance < 0.1f)
        {
            objective = objective + 1;
            if (objective >= points.Count)
            {
                objective = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[objective].position, speed * Time.deltaTime);
    }
}
