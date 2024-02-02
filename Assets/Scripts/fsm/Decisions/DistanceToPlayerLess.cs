

using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/DistanceToPLayerLess")]
    public class DistanceToPLayerLess : Decision
    {
        public float distance;
        public override bool Decide(StateController controller)
        {
            var dist = Vector3.Distance(controller.transform.position, GameManager.instance.Player.transform.position);
            return dist < distance;
        }
    }
}

