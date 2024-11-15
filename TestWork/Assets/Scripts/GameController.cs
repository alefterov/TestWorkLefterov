using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverpanel;
    public void GameOver() 
    {
        _gameOverpanel.SetActive(true);
        
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
