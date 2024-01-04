using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class GameSceneLoad : MonoBehaviour
    {
        private void Start()
        {
            Helper.IsGameSceneLoad = true;
        }

        private void OnDestroy()
        {
            Helper.IsGameSceneLoad = false;
        }
    }
}