using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
   [Header("General Settings")]
   [Tooltip("Player sensitivity")] [SerializeField] float control_speed;
    [Header("Player borders")]
    [Tooltip("Borders along x axis")][SerializeField] float x_Range;
    [Tooltip("Borders along y axis")] [SerializeField] float y_Range;

    float y_Move, z_Move;

    [Header("Player move sensitivity")]
    [Tooltip("Pitch")][SerializeField] float pitch_pos;
    [Tooltip("Pitch")] [SerializeField] float pitch_control;    //z
    [Tooltip("Yaw")][SerializeField] float yaw_pos;            //y
    [Tooltip("Roll")] [SerializeField] float roll_control;    //x

   [Header("")]
    [SerializeField] GameObject[] lasers;

        


    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Rotate();
        Firing();
    }









    void Move()
    {
        z_Move = Input.GetAxis("Horizontal");
        y_Move = Input.GetAxis("Vertical");


        float zOffset = -z_Move * Time.deltaTime * control_speed;
        float zNew_pos = transform.localPosition.z + zOffset;
        float Z_pos = Mathf.Clamp(zNew_pos, -x_Range, x_Range);

        float yOffset = y_Move * Time.deltaTime * control_speed;
        float yNew_pos = transform.localPosition.y + yOffset;
        float y_pos = Mathf.Clamp(yNew_pos, -y_Range, y_Range);


        transform.localPosition = new Vector3(transform.localPosition.x, y_pos, Z_pos);
    }









    void Rotate()
    {
        float pitch__Pos = transform.localPosition.y * pitch_pos;
        float pitch__Cont = y_Move * pitch_control;

        float pitch = pitch__Pos + pitch__Cont;


        float yaw= transform.localPosition.z * yaw_pos;

        float roll= z_Move * roll_control;

        transform.localRotation = Quaternion.Euler(roll,yaw, pitch);
                                                  

    }











    void Firing()
    {
        if (Input.GetButton("Fire1"))
        {
            Lasers(true);
        }
        else
        {
            Lasers(false);
        }

    }

    void Lasers(bool isActive)
    {
        foreach (GameObject laser_ in lasers)
        {
            var Emmission = laser_.GetComponent<ParticleSystem>().emission;
            Emmission.enabled = isActive;
        }
    }


}



