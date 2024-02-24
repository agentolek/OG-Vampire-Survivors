using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpritePreview : MonoBehaviour
{
    private Collider2D _col;
    
    public bool IsTouching()
    {
        _col = GetComponent<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        Collider2D[] _ = { };
        if (Physics2D.OverlapCollider(_col, filter, _) > 0)
        {
            return true;
        }

        return false;
    }
}
