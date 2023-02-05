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
        public Text HpText;

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

        void Update()
        {
            if(null != Roots.Instance.playerRoot)
            {
                HpText.text = string.Format("HP:{0}", Roots.Instance.playerRoot.Hp);
            }
            else
            {
                HpText.text = string.Format("HP:{0}", 0);
            }
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