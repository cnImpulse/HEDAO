
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
public partial class TbBattleSkillCfg
{
    private readonly System.Collections.Generic.Dictionary<int, BattleSkillCfg> _dataMap;
    private readonly System.Collections.Generic.List<BattleSkillCfg> _dataList;
    
    public TbBattleSkillCfg(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, BattleSkillCfg>();
        _dataList = new System.Collections.Generic.List<BattleSkillCfg>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            BattleSkillCfg _v;
            _v = BattleSkillCfg.DeserializeBattleSkillCfg(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, BattleSkillCfg> DataMap => _dataMap;
    public System.Collections.Generic.List<BattleSkillCfg> DataList => _dataList;

    public BattleSkillCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public BattleSkillCfg Get(int key) => _dataMap[key];
    public BattleSkillCfg this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}
