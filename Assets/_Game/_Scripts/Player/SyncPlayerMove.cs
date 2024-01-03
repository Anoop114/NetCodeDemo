using Unity.Netcode.Components;

namespace Player
{
    public class SyncPlayerMove : NetworkTransform
    {
        protected override bool OnIsServerAuthoritative() => false;
    }
}