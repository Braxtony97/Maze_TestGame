using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameMagaer
{
    public class GameLoader : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            LoadGame();
        }

        private void LoadGame()
        {
            SceneManager.LoadScene("gameplay_scene");
        }
    }
}
