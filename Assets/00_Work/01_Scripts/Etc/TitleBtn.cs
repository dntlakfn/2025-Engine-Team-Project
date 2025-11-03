using UnityEngine;
using UnityEngine.SceneManagement;

namespace Work.Scripts.Etc
{
    public class TitleBtn : MonoBehaviour
    {
        public void GoToGame()
        {
            SceneManager.LoadScene("TestScene");
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
