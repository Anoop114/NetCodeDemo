using System;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

namespace LobbyManage
{
    public class JoinRoomPanel : MonoBehaviour
    {
        public static event Action<Lobby> JoinPrivateLobby;
        [SerializeField] private TMP_InputField nameInput, passInput;
        [SerializeField] private GameObject playBtn;

        private bool _nameFound;
        private void Start()
        {
            nameInput.onValueChanged.AddListener(nameLength => { _nameFound = nameLength.Length > 0; });
            passInput.onValueChanged.AddListener(passLenght =>
            {
                if(!_nameFound) return;
                
                playBtn.SetActive(passLenght.Length >= 8);
            });
        }

        public void JoinPrivateRoom()
        {
            //JoinPrivateLobby?.Invoke(nameInput.text,passInput.text);
        }
    }
}