using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LobbyManage
{
    public class CreateLobbyScreen : MonoBehaviour {
        public static event Action<LobbyData> LobbyCreated;
        
        [SerializeField] private TMP_InputField _nameInput, _maxPlayersInput, passInput;
        //[SerializeField] private TMP_Dropdown _typeDropdown, _difficultyDropdown;
        [SerializeField] private Toggle visibility;
        [SerializeField] private Button createLobby;
        private void Start() {
            visibility.onValueChanged.AddListener(ChangeVisibility);
            passInput.onValueChanged.AddListener(CharacterLengthCheck);
        }

        private void CharacterLengthCheck(string passLenght)
        {
            if (!visibility.isOn)
            {
                createLobby.gameObject.SetActive(passLenght.Length >= 8);
            }
        }

        private void ChangeVisibility(bool action)
        {
            if (!action)
            {
                passInput.transform.parent.gameObject.SetActive(true);
                createLobby.gameObject.SetActive(false);
            }
            else
            {
                createLobby.gameObject.SetActive(true);
                passInput.transform.parent.gameObject.SetActive(false);
                passInput.text = "";
            }
        }


        public void OnCreateClicked() {
            var lobbyData = new LobbyData {
                Name = _nameInput.text,
                MaxPlayers = int.Parse(_maxPlayersInput.text),
                Visibility = visibility.isOn,
                roomPass = passInput.text
            };

            LobbyCreated?.Invoke(lobbyData);
        }
    }

    public struct LobbyData {
        public string Name;
        public int MaxPlayers;
        public bool Visibility;
        public string roomPass;
    }
}