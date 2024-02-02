
using UnityEngine;


namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/FleeFromPlayer")]
    public class FleeFromPlayer : Action
    {
        public float distanceTarget = 5f;
        public override void Act(StateController controller)
        {
            var mb = controller.GetComponent<IMovementBehaviour>();
            var player = GameManager.instance.Player.transform.position;
            var dir = controller.transform.position - player;
            mb.MoveToPoint(controller.transform.position + dir.normalized * distanceTarget);
        }
    }
}
