
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace Cfg.XiuLian
{
public partial class TbLevelCfg
{
    private readonly System.Collections.Generic.Dictionary<int, LevelCfg> _dataMap;
    private readonly System.Collections.Generic.List<LevelCfg> _dataList;
    
    public TbLevelCfg(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, LevelCfg>();
        _dataList = new System.Collections.Generic.List<LevelCfg>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            LevelCfg _v;
            _v = LevelCfg.DeserializeLevelCfg(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, LevelCfg> DataMap => _dataMap;
    public System.Collections.Generic.List<LevelCfg> DataList => _dataList;

    public LevelCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public LevelCfg Get(int key) => _dataMap[key];
    public LevelCfg this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

