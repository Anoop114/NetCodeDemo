using Managers;
using UnityEngine;

namespace Player
{
    public class LookAtCamera : MonoBehaviour
    {
        // private Transform _cam;
        // private void Start()
        // {
        //     _cam = Camera.main.transform;
        // }

        private void LateUpdate()
        {
            if(!Helper.IsGameSceneLoad)return;
            transform.LookAt(transform.position + Camera.main.transform.forward);
        }
    }
}