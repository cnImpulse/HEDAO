
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace Cfg.Battle
{
public partial class TbMoveSkillCfg
{
    private readonly System.Collections.Generic.Dictionary<int, BattleMoveCfg> _dataMap;
    private readonly System.Collections.Generic.List<BattleMoveCfg> _dataList;
    
    public TbMoveSkillCfg(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, BattleMoveCfg>();
        _dataList = new System.Collections.Generic.List<BattleMoveCfg>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            BattleMoveCfg _v;
            _v = BattleMoveCfg.DeserializeBattleMoveCfg(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, BattleMoveCfg> DataMap => _dataMap;
    public System.Collections.Generic.List<BattleMoveCfg> DataList => _dataList;

    public BattleMoveCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public BattleMoveCfg Get(int key) => _dataMap[key];
    public BattleMoveCfg this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

