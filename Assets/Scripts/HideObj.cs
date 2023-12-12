using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObj : MonoBehaviour
{
    public float startAngle;
    public float endAngle;
    public float angleStep = 5f; // Incremento en grados para cada rayo
    public float verticalAngle = 45f; // Ángulo para lanzar rayos hacia arriba y abajo
    public string objetoVisibleTag = "ObjetoVisible";

    void Update()
    {
        CheckObjectVisibility();
        ShowAllObjectsNotHit();
    }

    void CheckObjectVisibility()
    {
        // Lanzar rayos en el rango horizontal
        for (float currentAngle = startAngle; currentAngle <= endAngle; currentAngle += angleStep)
        {
            CastRay(currentAngle);
        }

        // Lanzar rayos hacia arriba
        CastRay(verticalAngle);

        // Lanzar rayos hacia abajo
        CastRay(-verticalAngle);
    }

    void CastRay(float angle)
    {
        // Calcular la dirección del rayo basándote en el ángulo actual
        Vector3 rayDirection = Quaternion.AngleAxis(angle, transform.up) * transform.forward;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, rayDirection, Mathf.Infinity);

        foreach (RaycastHit hit in hits)
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();

            if (renderer != null && hit.collider.CompareTag(objetoVisibleTag))
            {
                // Ocultar el objeto basándote en la colisión
                renderer.enabled = false;

                // Debug: Dibujar rayo
                Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.green);
            }
        }
    }

    void ShowAllObjectsNotHit()
    {
        GameObject[] objetosVisibles = GameObject.FindGameObjectsWithTag(objetoVisibleTag);

        foreach (GameObject obj in objetosVisibles)
        {
            bool hitByRay = false;
            RaycastHit[] hits = null; // Declarar la variable hits fuera del bucle for

            // Verificar rayos horizontales
            for (float currentAngle = startAngle; currentAngle <= endAngle; currentAngle += angleStep)
            {
                CastRay(currentAngle);

                // Verificar rayo hacia arriba
                CastRay(verticalAngle);

                // Verificar rayo hacia abajo
                CastRay(-verticalAngle);

                hits = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity);

                foreach (RaycastHit hit in hits)
                {
                    if (hit.collider.CompareTag(objetoVisibleTag) && hit.collider.gameObject == obj)
                    {
                        hitByRay = true;
                        break;
                    }
                }
            }

            // Mostrar el objeto si no está siendo impactado por ningún rayo
            obj.GetComponent<Renderer>().enabled = !hitByRay;
        }
    }
}



