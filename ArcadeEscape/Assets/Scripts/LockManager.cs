using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public int locksLeft = 0;
    public int easyInitialLocks = 0;
    public int normalInitialLocks = 0;
    public int hardInitialLocks = 0;

    private void Awake()
    {
        if (DifficultySelect.isEasy)
        {
            locksLeft = easyInitialLocks;
        }
        if (DifficultySelect.isNormal)
        {
            locksLeft = normalInitialLocks;
        }
        if (DifficultySelect.isHard)
        {
            locksLeft = hardInitialLocks;
        }
    }

    private void Update()
    {
        if (locksLeft <= 0)
        {
            Door.openDoor = true;
        }
    }


    public void UnlockLock()
    {
        locksLeft--;
    }

    public int GetLocksLeft()
    {
        return locksLeft;
    }
}
