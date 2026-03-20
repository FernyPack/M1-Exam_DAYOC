using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    public GameObject instructionsPanel;

    void Start()
    {
        instructionsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            instructionsPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}