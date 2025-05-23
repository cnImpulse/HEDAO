
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
public partial class TbItem
{
    private readonly System.Collections.Generic.Dictionary<int, ItemCfg> _dataMap;
    private readonly System.Collections.Generic.List<ItemCfg> _dataList;
    
    public TbItem(ByteBuf _buf)
    {
        _dataMap = new System.Collections.Generic.Dictionary<int, ItemCfg>();
        _dataList = new System.Collections.Generic.List<ItemCfg>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            ItemCfg _v;
            _v = ItemCfg.DeserializeItemCfg(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public System.Collections.Generic.Dictionary<int, ItemCfg> DataMap => _dataMap;
    public System.Collections.Generic.List<ItemCfg> DataList => _dataList;

    public T GetOrDefaultAs<T>(int key) where T : ItemCfg => _dataMap.TryGetValue(key, out var v) ? (T)v : null;
    public T GetAs<T>(int key) where T : ItemCfg => (T)_dataMap[key];
    public ItemCfg GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public ItemCfg Get(int key) => _dataMap[key];
    public ItemCfg this[int key] => _dataMap[key];

    public void ResolveRef(Tables tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
    }

}

}

