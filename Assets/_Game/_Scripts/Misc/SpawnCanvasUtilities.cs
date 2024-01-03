using System;
using UnityEngine;

namespace Misc
{
    public class SpawnCanvasUtilities : MonoBehaviour
    {
        [SerializeField] private CanvasUtilities canvasUtilities;
        private void Start()
        {
            MatchmakingService.ResetStatics();
            Instantiate(canvasUtilities);
        }
    }
}