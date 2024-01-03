using System;
using TMPro;
using UnityEngine;
using InGameLobby = Unity.Services.Lobbies.Models.Lobby;
namespace LobbyManage
{
    public class LobbyRoomPanel : MonoBehaviour {
        [SerializeField] private float _difficultyDialMaxAngle = 100f;

        [SerializeField] private TMP_Text _nameText, _typeText, _playerCountText;
        [SerializeField] private Transform _difficultyMeter;

        public InGameLobby Lobby { get; private set; }

        public static event Action<InGameLobby> LobbySelected;

        public void Init(InGameLobby lobby) {
            if(!lobby.IsPrivate)
                UpdateDetails(lobby);
        }

        public void UpdateDetails(InGameLobby lobby) {
            Lobby = lobby;
            _nameText.text = lobby.Name;
            //_typeText.text = Constants.GameTypes[GetValue(Constants.GameRoomKey)];

            //var point = Mathf.InverseLerp(0, Constants.Difficulties.Count - 1, GetValue(Constants.VisibilityKey));
            //_difficultyMeter.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(_difficultyDialMaxAngle, -_difficultyDialMaxAngle, point));

            _playerCountText.text = $"{lobby.Players.Count}/{lobby.MaxPlayers}";

            // int GetValue(string key) {
            //     return int.Parse(lobby.Data[key].Value);
            // }
        }

        public void Clicked() {
            LobbySelected?.Invoke(Lobby);
        }
    }
}