using System;
using Unity.Netcode;
using UnityEngine;

namespace LobbyManage
{
    public class JoinOrCreateRoom : MonoBehaviour
    {
        public void StartHost() => NetworkManager.Singleton.StartHost();

        public void StartClient() => NetworkManager.Singleton.StartClient();

        private bool isHost;
        private bool isClient;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && !isHost)
            {
                isHost = true;
                StartHost();
            }

            if (Input.GetKeyDown(KeyCode.Space) && !isClient)
            {
                isClient = true;
                StartClient();
            }
            
        }
    }
}