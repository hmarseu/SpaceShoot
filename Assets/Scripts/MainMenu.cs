using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;

    public void StartGame()
    {
        _gameManager.NewGame();
        gameObject.SetActive(false);
    }
}