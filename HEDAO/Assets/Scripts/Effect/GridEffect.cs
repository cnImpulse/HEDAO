using UnityEngine;
using UnityEngine.Tilemaps;


public class GridEffectView : EffectView
{
    public new GridEffectData Data => Entity as GridEffectData;
    private Tilemap m_Tilemap;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        m_Tilemap = GetComponentInChildren<Tilemap>();
        m_Tilemap.ClearAllTiles();

        m_Tilemap.color = Data.Color;
        var tile = GameMgr.Res.LoadAsset<Tile>(10005);
        foreach (var pos in Data.GridList)
        {
            m_Tilemap.SetTile(new Vector3Int(pos.x, pos.y, 0), tile);
        }
    }

    private void Update()
    {
 
    }
}
