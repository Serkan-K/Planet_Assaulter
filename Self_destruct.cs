using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_destruct : MonoBehaviour
{
    [SerializeField] float destroy_time;
    void Start()
    {
        Destroy(gameObject, destroy_time);
    }

}
