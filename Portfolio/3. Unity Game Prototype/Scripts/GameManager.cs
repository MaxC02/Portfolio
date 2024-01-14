using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject youDiedUI;
    public GameObject youWonUI;
    public GameObject player;
    public GameObject healthUI;
    public GameObject timeUI;

    PlayerMovement pm;
    public GameObject playerCamera;
    MouseLook ml;

    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
        ml = playerCamera.GetComponent<MouseLook>();
    }

    public void EndGame()
    {
        youDiedUI.SetActive(true);
        healthUI.SetActive(false);
        timeUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        pm.enabled = false;
        ml.enabled = false;
    }

    public void GameWon()
    {
        youWonUI.SetActive(true);
        healthUI.SetActive(false);
        timeUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        pm.enabled = false;
        ml.enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
