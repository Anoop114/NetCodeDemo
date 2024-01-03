using UnityEngine;
using UnityEngine.EventSystems;

namespace Misc
{
    /// <summary>
    ///     Play some satisfying click sounds
    /// </summary>
    public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        [SerializeField] private AudioClip clipUp;
        [SerializeField] private AudioClip clipDown;
        public void OnPointerDown(PointerEventData eventData) {
            PlayClip(true);
        }

        public void OnPointerUp(PointerEventData eventData) {
            PlayClip();
        }

        private void PlayClip(bool action = false) {
            AudioSource.PlayClipAtPoint(action ? clipUp : clipDown, Vector3.zero);
        }
    }
}