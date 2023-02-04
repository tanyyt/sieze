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
            EventScheduler<GameEvent>.Global.RegisterOrSubscribe(GameEvent.GameOver, ShowEndingUI);
            BtnRestart.onClick.AddListener(() =>
            {
                BulletPool.ClearPool();
                EventScheduler<GameEvent>.Global[GameEvent.GameOver].Clear();
                SceneManager.LoadScene("GamePlay");
            });
        }

        void ShowEndingUI()
        {
            RestartUI.SetActive(true);
        }

        [Button]
        public static void GameOver()
        {
             EventScheduler<GameEvent>.Global[GameEvent.GameOver].Broadcast();
        }
    }
}