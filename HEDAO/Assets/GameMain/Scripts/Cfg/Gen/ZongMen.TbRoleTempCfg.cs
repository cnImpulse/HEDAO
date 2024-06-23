
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace Cfg.ZongMen
{
public partial class TbRoleTempCfg
{
    private readonly System.Collections.Generic.Dictionary<int, RoleTempCfg> _dataMap;
    private readonly System.Collections.Generic.List<RoleTempCfg> _dataList;
    
    public TbRoleTempCfg(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, RoleTempCfg>();
        _dataList = new System.Collections.Generic.List<RoleTempCfg>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            RoleTempCfg _v;
            _v = RoleTempCfg.DeserializeRoleTempCfg(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, RoleTempCfg> DataMap => _dataMap;
    public System.Collections.Generic.List<RoleTempCfg> DataList => _dataList;

    public RoleTempCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public RoleTempCfg Get(int key) => _dataMap[key];
    public RoleTempCfg this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}
