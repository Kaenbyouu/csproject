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

        [SerializeField]
        private Button Start;

        private bool lost = false;


        internal void triggerGameOver(bool lost = true)
        {
            GameOverScreen.SetActive(lost);
            StartScreen.SetActive(!lost);
            Restart.gameObject.SetActive(true);

            Time.timeScale = 0f;

        }
        void FixedUpdate()
        {
            if(GameObject.FindGameObjectsWithTag("Player")== null)
            {
                lost = true;
                triggerGameOver(lost);
            }
            else
            {
                return;
            }
        }

        /*private void Awake()
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

        }*/

    }
}
