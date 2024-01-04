using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Player
{
    public class HeadPlayerCountValue : NetworkBehaviour
    {
        [SerializeField] private TMP_Text headText;
        private NetworkVariable<FixedString128Bytes> _networkPlayerNumber = new("Player: 0");

        public override void OnNetworkSpawn()
        {
            var headData = $"Player : {OwnerClientId + 1}";
            _networkPlayerNumber.Value = headData;
            headText.text = headData;
        }
        
    }
}