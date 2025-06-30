using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class COLLISIONhandler : MonoBehaviour
{
    [SerializeField] float timetowait = 2f;
    [SerializeField] AudioClip crashSfx;
    [SerializeField] AudioClip sucessSfx;
    [SerializeField] ParticleSystem Partsucess;
    [SerializeField] ParticleSystem Partcrash;
    AudioSource audioo;
    bool iscontroable = true;
    bool iscollidable = true;
    void Start()
    {
        audioo = GetComponent<AudioSource>();
    }

    void Update()
    {
        RespondToDebugKey();
    }
    void RespondToDebugKey()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            Nextlevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            iscollidable  = !iscollidable;
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (!iscontroable || !iscollidable)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("hey you just start don't be a noob and go on");
                break;
            
            case "End":
                summonnextlevel();
                break ;
            
            case "Fuel":
                Debug.Log("ammm i dont know why i am here but i thinks my name is Fuel");
                break;
            
            default:
                waiting();
                break;
        }
    }

    private void summonnextlevel()
    {
        iscontroable = false;
        audioo.Stop();
        audioo.PlayOneShot(sucessSfx);
        Partsucess.Play();
        GetComponent<Movement>().enabled= false;
        Invoke("Nextlevel", timetowait);
    }

    void waiting()
    {
        iscontroable = false;
        audioo.Stop();
        audioo.PlayOneShot(crashSfx);
        Partcrash.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("Reloadlevel", timetowait);

    }

    void Nextlevel()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        int nextlevelscene = currentscene + 1;
        if (nextlevelscene == SceneManager.sceneCountInBuildSettings)
        {
            nextlevelscene = 0;
        }

        SceneManager.LoadScene(nextlevelscene);
    }

    void Reloadlevel()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }

}
