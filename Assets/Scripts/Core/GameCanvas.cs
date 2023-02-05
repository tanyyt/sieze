using Model;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

namespace Core
{
    public class GameCanvas : MonoBehaviour
    {
        public GameObject RestartUI;
        public Button BtnRestart;

        void Awake()
        {
            GameEvent.gameOverEvent += ShowEndingUI;
            BtnRestart.onClick.AddListener(() =>
            {
                BulletPool.ClearPool();
                GameEvent.gameOverEvent = null;
                GameEvent.cameraHugeShake = null;
                GameEvent.cameraShortShake = null;
                SceneManager.LoadScene("Main");
            });
        }

        void ShowEndingUI()
        {
            Debug.Log("Show UI");
            RestartUI.SetActive(true);
        }

        [Button]
        public static void GameOver()
        {
            GameEvent.gameOverEvent?.Invoke();
        }
    }
}