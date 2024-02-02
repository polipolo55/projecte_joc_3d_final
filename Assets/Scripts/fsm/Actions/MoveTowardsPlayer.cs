
using UnityEngine;


namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/MoveTowardsPlayer")]
    public class MoveTowardsPlayer : Action
    {
        public override void Act(StateController controller)
        {
            var mb = controller.GetComponent<IMovementBehaviour>();
            var target = GameManager.instance.Player.transform.position;
            mb.MoveToPoint(target);
        }
    }
}
