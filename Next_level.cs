using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class Next_level : MonoBehaviour
{


    void OnTriggerEnter(Collider n)
    {
        if(n.gameObject.name == "spaceship")
        {
            SceneManager.LoadScene("Congrats");
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene("level1");
    }
}
