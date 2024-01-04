using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LobbyManage
{
    public class JoinRoomPanel : MonoBehaviour
    {
        public static event Action<string,string> JoinPrivateLobby;
        [SerializeField] private TMP_InputField nameInput, passInput;
        [SerializeField] private Button playBtn;

        private bool _nameFound;
        private void Start()
        {
            nameInput.onValueChanged.AddListener(nameLength => { _nameFound = nameLength.Length > 0; });
            passInput.onValueChanged.AddListener(passLength =>
            {
                if(!_nameFound) return;
                
                playBtn.interactable = passLength.Length >= 8;
            });
        }

        public void JoinPrivateRoom()
        {
            JoinPrivateLobby?.Invoke(nameInput.text,passInput.text);
        }
    }
}