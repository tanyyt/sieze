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
        public Text GameOvaTitle;
        public Color WinColor;
        public Color FailedColor;

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

        void ShowEndingUI(bool isWin)
        {
            if(RestartUI != null)
                RestartUI.SetActive(true);
            GameOvaTitle.text = isWin ? "WIN" : "GAMEOVER";
            GameOvaTitle.color = isWin ? WinColor : FailedColor;
        }
    }
}