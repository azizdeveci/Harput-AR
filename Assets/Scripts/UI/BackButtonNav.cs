using UnityEngine;
using UnityEngine.SceneManagement;

namespace HarputAR.UI
{
    public class BackButtonNav : MonoBehaviour
    {
        public void AnaMenuyeDon()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}