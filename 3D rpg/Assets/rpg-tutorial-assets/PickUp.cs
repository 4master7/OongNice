using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interact
{
    public RPGitem item;
    public override void It()
    {
        base.It();
        Pick();
    }
    void Pick()
    {
        Debug.Log("use Item : "+ item.name);
        Destroy(gameObject);
    }
}
