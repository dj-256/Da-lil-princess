using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    private bool isCursorLocked;
    
    void Start()
    {
        LockCursor(true);
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LockCursor(!isCursorLocked);//deactivate cursor
            menuPanel.SetActive(!menuPanel.activeSelf);//toggle the menu
        }
    }
    
    //Display cursor in pause menu
    private void LockCursor(bool shouldLock)
    {
        isCursorLocked = shouldLock;

        if (isCursorLocked)
        {
            // Cachez le curseur et le verrouillez au centre de l'écran
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            // Affichez le curseur et déverrouillez-le
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
