
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace Cfg.Common
{
public partial class TbRole
{
    private readonly System.Collections.Generic.Dictionary<int, RoleCfg> _dataMap;
    private readonly System.Collections.Generic.List<RoleCfg> _dataList;
    
    public TbRole(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, RoleCfg>();
        _dataList = new System.Collections.Generic.List<RoleCfg>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            RoleCfg _v;
            _v = RoleCfg.DeserializeRoleCfg(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, RoleCfg> DataMap => _dataMap;
    public System.Collections.Generic.List<RoleCfg> DataList => _dataList;

    public RoleCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public RoleCfg Get(int key) => _dataMap[key];
    public RoleCfg this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

