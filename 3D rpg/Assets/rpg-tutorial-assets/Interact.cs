using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float radius = 3f;
    private bool isFocus = false;
    private bool hasInteracted = false;
    Transform player;
    public Transform interactionTransform;

    // Update is called once per frame
    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                It();
                hasInteracted = true;
            }
        }
    }
    public virtual void It()
    {
        //player.gameObject.GetComponent<Controller>();
    }

    public void Onfocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    //gizmo그리는 함수
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
