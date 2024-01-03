using Unity.Netcode;
using UnityEngine;

namespace Player
{
    public class PlayerController : NetworkBehaviour {
        [SerializeField] private float _speed = 30;

        private void Start()
        {
            var x = Random.Range(-20, 20);
            var z = Random.Range(-20, 20);
        
            transform.position = new Vector3(x, transform.position.y, z);
        }

        private void Update() {
            if(!IsOwner) return;
            var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            dir.Normalize();
            
            transform.Translate(dir * (_speed * Time.deltaTime),Space.World);

            if (dir == Vector3.zero) return;
            var rot = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 720 * Time.deltaTime);
        }

    }
}