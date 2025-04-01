using System;
using System.Collections.Generic;
using System.Linq;
using Cfg.Battle;
using FairyGUI;
using Cfg;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIBookPage : GComponent
    {
        private List<object> m_RoleList = new List<object>();
        private List<object> m_BookList = new List<object>();

        public Dictionary<long, Role> DiscipleDict => GameMgr.Save.Data.RoleDict;
        public List<EBookType> BookTypeList => GameMgr.Cfg.TbMisc.BookTypeList;

        public void OnInit()
        {
            m_btn_learn.onClick.Set(OnClickBtnLearn);
            m_list_role.m_list.itemRenderer = OnRenderRole;
            m_list_book.itemRenderer = OnRenderBook;
            m_list_book_type.itemRenderer = OnRenderBookType;
            m_list_book.selectionController.onChanged.Set(RefreshBookText);
            m_list_role.m_list.selectionController.onChanged.Set(RefreshRoleInfo);

            m_list_book_type.numItems = BookTypeList.Count;
            m_list_book_type.selectionController.onChanged.Set(RefreshList);
        }

        public void Refresh()
        {
            OnInit();

            RefreshList();
        }

        public void RefreshList()
        {
            m_RoleList = DiscipleDict.Values.Where((role) => { return !role.BookDict.ContainsKey(GetSelectedBookType()); }).AsEnumerable<object>().ToList();
            m_list_role.m_list.RefreshList(m_RoleList);
            m_list_role.m_list.RefreshSelectionController();

            RefreshBookList();
        }

        public void RefreshBookList()
        {
            m_BookList = GameMgr.Cfg.TbGongFaCfg.DataList.Where((cfg) => { return cfg.BookType == GetSelectedBookType(); }).AsEnumerable<object>().ToList();
            m_list_book.RefreshList(m_BookList);

            m_list_book.RefreshSelectionController();
        }

        private void OnRenderRole(int index, GObject obj, object data)
        {
            var role = data as Role;
            var item = obj as FGUIBtnRole;
            item.Refresh(role);
        }

        private void OnRenderBook(int index, GObject item, object data)
        {
            var cfg = data as GongFaCfg;
            item.asButton.title = cfg.Name;
        }

        private void OnRenderBookType(int index, GObject item, object data)
        {
            item.text = BookTypeList[index].GetName();
        }

        private void RefreshRoleInfo()
        {
            m_rader.Refresh(GetSelectedRole());
        }

        private void RefreshBookText()
        {
            var cfg = GetSelectedBook();
            if (cfg == null)
            {
                m_txt_book.text = "";
                return;
            }
            
            var txt = string.Format("{0}\n简介：{1}\n", cfg.Name, cfg.Desc);
            foreach(var buffId in cfg.BuffList)
            {
                txt += GetBuffDesc(buffId);
            }

            m_txt_book.text = txt;
        }

        private string GetBuffDesc(int id)
        {
            var cfg = GameMgr.Cfg.TbBuffCfg.Get(id);
            var str = cfg.Desc + ": ";
            foreach (var effectId in cfg.EffectList)
            {
                str += GetEffectDesc(effectId) + '\n';
            }

            return str;
        }

        private string GetEffectDesc(int id)
        {
            var str = "";
            var cfg = GameMgr.Cfg.TbEffectCfg.Get(id);
            if (cfg is AttrModifyEffect)
            {
                foreach(var pair in ((AttrModifyEffect)cfg).AttrDict)
                {
                    str += string.Format("{0}:{1} ", pair.Key.GetName(), pair.Value);
                }
            }

            return str;
        }

        private void OnClickBtnLearn()
        {
            var role = GetSelectedRole();
            var bookCfg = m_BookList[m_list_book.selectedIndex] as GongFaCfg;
            role?.LearnGongFa(bookCfg.Id);

            RefreshList();
        }

        private GongFaCfg GetSelectedBook()
        {
            var index = m_list_book.selectedIndex;
            if (index < 0) return null;

            return m_BookList[index] as GongFaCfg;
        }
        
        private Role GetSelectedRole()
        {
            var index = m_list_role.m_list.selectedIndex;
            if (index < 0 || m_RoleList.Count < index)
            {
                return null;
            }

            return m_RoleList[index] as Role;
        }

        public EBookType GetSelectedBookType()
        {
            var index = m_list_book_type.selectedIndex;
            return BookTypeList[index];
        }
    }
}