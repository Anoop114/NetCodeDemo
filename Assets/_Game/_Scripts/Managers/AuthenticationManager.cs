using Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class AuthenticationManager : MonoBehaviour {

        public async void LoginAnonymously() {
            using (new Load("Logging you in...")) {
                await Authentication.Login();
                SceneManager.LoadSceneAsync("Lobby");
            }
        }
    }
}