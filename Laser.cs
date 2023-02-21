using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{

    [SerializeField] ParticleSystem crash_VFX;

    void OnTriggerEnter(Collider other)
    {
        Crash();
    }

    void Crash()
    {

        crash_VFX.Play();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Controller>().enabled = false;
        Invoke("Reload", 1f);

    }

    void Reload()
    {
        int level_number = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level_number);
    }


}
