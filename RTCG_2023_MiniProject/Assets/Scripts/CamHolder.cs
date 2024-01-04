using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHolder : MonoBehaviour
{
    [SerializeField] Transform camPos;
    void Update()
    {
        transform.position = camPos.position;
    }
}
