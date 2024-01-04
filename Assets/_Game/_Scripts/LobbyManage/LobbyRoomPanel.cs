using System;
using TMPro;
using UnityEngine;
using InGameLobby = Unity.Services.Lobbies.Models.Lobby;
namespace LobbyManage
{
    public class LobbyRoomPanel : MonoBehaviour {

        [SerializeField] private TMP_Text _nameText,  _playerCountText;

        public InGameLobby Lobby { get; private set; }

        public static event Action<InGameLobby> LobbySelected;

        public void Init(InGameLobby lobby) {
            if(!lobby.IsPrivate)
                UpdateDetails(lobby);
        }

        public void UpdateDetails(InGameLobby lobby) {
            Lobby = lobby;
            _nameText.text = lobby.Name;
            _playerCountText.text = $"{lobby.Players.Count}/{lobby.MaxPlayers}";
        }

        public void Clicked() {
            LobbySelected?.Invoke(Lobby);
        }
        
    }
}