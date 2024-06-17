using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public GameObject footstep;
    public GameObject running_footsteps;
    bool inInventory;
    bool isRunning;

    void Start()
    {
        footstep.SetActive(false);
        running_footsteps.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inInventory = !inInventory;
        }

        if (!inInventory)
        {
            if (Input.GetKey("w") || Input.GetKeyDown("s") || Input.GetKeyDown("a") || Input.GetKeyDown("d"))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    isRunning = true;
                    RunningFootsteps();
                }
                else
                {
                    isRunning = false;
                    footsteps();
                }
            }

            if (Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            {
                if (isRunning)
                {
                    isRunning = false;
                    StopRunningFootsteps();
                }
                else
                {
                    StopFootsteps();
                }
            }
            CheckNoMovement();
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }

    void RunningFootsteps()
    {
        running_footsteps.SetActive(true);
    }

    void StopRunningFootsteps()
    {
        running_footsteps.SetActive(false);
    }

    void CheckNoMovement()
    {
        if (!Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            StopFootsteps();
            StopRunningFootsteps();
        }
    }
}
