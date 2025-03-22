using System.Collections;
using System.Collections.Generic;

public class Entity
{
    public int Id { get; private set; }

    public Entity()
    {
        
    }

    public void Init()
    {

    }

    public void Destroy()
    {
         
    }

    protected virtual void OnInit()
    {

    }

    protected virtual void OnDestroy()
    {

    }
}
