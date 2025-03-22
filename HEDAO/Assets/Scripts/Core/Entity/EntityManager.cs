using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : BaseManager
{
    private readonly Dictionary<long, EntityView> m_EntityViewDict;

    public void ShowEntity<T>(Entity entity)
        where T : EntityView
    {

    }

    public void HideEntity<T>(long id)
        where T : EntityView
    {
        
    }
}
