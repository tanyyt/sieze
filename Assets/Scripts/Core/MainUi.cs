using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    public class MainUi : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("GamePlay");
        }
    }
}
