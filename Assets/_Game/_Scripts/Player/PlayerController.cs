using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : NetworkBehaviour {
        [SerializeField] private float speed = 30;
        [SerializeField] private Color color1;
        [SerializeField] private Color color2;
        [SerializeField] private Color color3;
        [SerializeField] private Color color4;
        public override void OnNetworkSpawn()
        {
            OnSpawnToServerRpc();
        }
        

        private void Update() {
            if(!IsOwner) return;
            var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            dir.Normalize();
            
            transform.Translate(dir * (speed * Time.deltaTime),Space.World);

            if (dir == Vector3.zero) return;
            var rot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 720 * Time.deltaTime);
        }

        [ServerRpc (RequireOwnership = false)]
        private void OnSpawnToServerRpc()
        {
            ChangeColor();
            ChangePos();

            return;
            void ChangePos()
            {
                var x = Random.Range(-20, 20);
                var z = Random.Range(-20, 20);

                var mTransform = transform;
                mTransform.position = new Vector3(x, mTransform.position.y, z);
                mTransform.rotation = new Quaternion(0, 180, 0, 0);
            }
            void ChangeColor()
            {
                var userNumber = OwnerClientId + 1;
                var tempColor = userNumber switch
                {
                    1 => color1,
                    2 => color2,
                    3 => color3,
                    4 => color4,
                    _ => color1
                };
                var component = transform.GetComponentInChildren<Renderer>();
                component.material.color = tempColor;
            }
        }
        
    }
}