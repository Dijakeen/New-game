using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCanvas : MonoBehaviour
{
    public GameObject prefabCanvas;
    static GameObject canvasGame;
    
    void Start()
    {
        canvasGame = Instantiate(prefabCanvas);
        canvasGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !canvasGame.activeSelf)
        {
            canvasGame.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvasGame.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    static public void CanvasOff()
    {
        canvasGame.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
