
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
public partial class TbBuffCfg
{
    private readonly System.Collections.Generic.Dictionary<int, BuffCfg> _dataMap;
    private readonly System.Collections.Generic.List<BuffCfg> _dataList;
    
    public TbBuffCfg(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, BuffCfg>();
        _dataList = new System.Collections.Generic.List<BuffCfg>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            BuffCfg _v;
            _v = BuffCfg.DeserializeBuffCfg(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, BuffCfg> DataMap => _dataMap;
    public System.Collections.Generic.List<BuffCfg> DataList => _dataList;

    public BuffCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public BuffCfg Get(int key) => _dataMap[key];
    public BuffCfg this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

