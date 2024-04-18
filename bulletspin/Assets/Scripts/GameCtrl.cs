using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EEL.RelativisticSpaceInvaders
{
 public class GameCtrl : MonoBehaviour
  {
        [SerializeField]
        private GameObject GameOverScreen;

        [SerializeField]
        private GameObject StartScreen;

        [SerializeField]
        private Button Restart;

        //GameOvr

        internal void triggerGameOver(bool lost = true)
        {
            GameOverScreen.SetActive(lost);
            StartScreen.SetActive(!lost);
            Restart.gameObject.SetActive(true);

            Time.timeScale = 0f;

        }

        // Healthbar

        [SerializeField]
        private int noOfLives = 3;

        [SerializeField]
        private Text livesTag;
        private int lives;

        internal void LiveUpdate() //yes, this pun is on purpose
        {
            lives = Mathf.Clamp(lives - 1, 0, noOfLives);
            livesTag.text = $"Lives:{lives}";

            if (lives > 0)
            {
                return;
            }
            else
            {
                triggerGameOver();
            }
        }


        // Points

        [SerializeField]
        private Text ScoreBoard;
        private int pts;
       
        internal void UpdatePts()
        {
            pts = pts + 5;
            ScoreBoard.text = $"Score:{pts}";
            //print(pts);

        }

        private void Awake()
        {
            lives = noOfLives;
            livesTag.text = $"Lives: {lives}";

            pts = 0;
            ScoreBoard.text = $"Score:{pts}";

            GameOverScreen.gameObject.SetActive(false);
            StartScreen.gameObject.SetActive(false);

            Restart.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f;
            });
            Restart.gameObject.SetActive(false);

        }

    }
}
