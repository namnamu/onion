using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escButton : MonoBehaviour
{
    public GameObject MenuSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Sub menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuSet.activeSelf)
            {
                MenuSet.SetActive(false);
            }
            else
            {
                MenuSet.SetActive(true);
            }
        }
    }

    public void GameExit()
    {
        // GameExit
        Application.Quit();
    }
}
