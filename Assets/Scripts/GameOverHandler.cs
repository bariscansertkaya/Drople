using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject player;
    [SerializeField] Button continueButton;
    [SerializeField] Button resumeButton;

    Player _playerScript;

    private void Awake() 
    {
        _playerScript=player.GetComponent<Player>();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContinueGame()
    {
        gameOverMenu.SetActive(false);
    }

    public void EnableGameOverScreen()
    {
        Invoke(nameof(SetGameOverMenuActive),1);
    }

    private void SetGameOverMenuActive()
    {
        gameOverMenu.SetActive(true);
    }
    
}
