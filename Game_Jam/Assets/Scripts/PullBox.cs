
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D) ,typeof(FixedJoint2D))]
public class PullBox : MonoBehaviour, IInteractable
{
    FixedJoint2D fixedJoint2D;
    private void Start() {
        fixedJoint2D = GetComponent<FixedJoint2D>();
        fixedJoint2D.enabled = false;
    }
    public void Interact(Player player)
    {

        if(fixedJoint2D.enabled)
        {
            fixedJoint2D.enabled = false;
            fixedJoint2D.connectedBody = null;
            
        }
        else
        {
            fixedJoint2D.enabled = true;
            fixedJoint2D.connectedBody = player.GetRigidbody2D();

        }
        
    }
}
