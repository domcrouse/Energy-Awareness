using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoom : MonoBehaviour, iInteract
{
    bool canLeave = false;
    public GameObject outLine;
    public void Interact()
    {
        if (canLeave)
        {
            GameEvents.current.LeaveRoom();
        }
    }

    void CanLeave(int id) { canLeave = true; outLine.SetActive(true); }

    private void Start()
    {
        GameEvents.current.onUnlockDoor += CanLeave;
    }
    private void OnDestroy()
    {
        GameEvents.current.onUnlockDoor -= CanLeave;
    }
}
