using Managers;
using Unity.Netcode;
using UnityEngine;

namespace Player
{
    public class PlayerController : NetworkBehaviour 
    {
        
        [SerializeField] private float speed = 30;

        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color color1;
        [SerializeField] private Color color2;
        [SerializeField] private Color color3;
        [SerializeField] private Color color4;
        public override void OnNetworkSpawn()
        {
            OnSpawnToServerRpc();
            meshRenderer.material.color = OnChangeColor((int)OwnerClientId);
        }
        

        private void Update() {
            if(!Helper.IsGameSceneLoad) return;
            if(!IsOwner) return;
            var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            dir.Normalize();
            
            transform.Translate(dir * (speed * Time.deltaTime),Space.World);

            if (dir == Vector3.zero) return;
            var rot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 720 * Time.deltaTime);
        }

        private Color OnChangeColor(int userNumber)
        {
            var tempColor = userNumber switch
            {
                1 => color1,
                2 => color2,
                3 => color3,
                4 => color4,
                _ => color1
            };
            return tempColor;
        }
        
        [ServerRpc (RequireOwnership = false)]
        private void OnSpawnToServerRpc()
        {
            var x = Random.Range(-20, 20);
            var z = Random.Range(-20, 20);

            var mTransform = transform;
            mTransform.position = new Vector3(x, mTransform.position.y, z);
            mTransform.rotation = new Quaternion(0, 180, 0, 0);
            
        }
        
    }
}