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
        private List<PlayerRole> m_RoleList = new List<PlayerRole>();
        private List<BookCfg> m_BookList = new List<BookCfg>();

        public Dictionary<long, PlayerRole> DiscipleDict => GameMgr.Save.Data.RoleDict;
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
            m_RoleList = DiscipleDict.Values.Where((role) => { return !role.BookDict.ContainsKey(GetSelectedBookType()); }).ToList();
            m_list_role.m_list.RefreshList(m_RoleList);
            m_list_role.m_list.RefreshSelectionCtrl();

            RefreshBookList();
        }

        public void RefreshBookList()
        {
            m_BookList = GameMgr.Cfg.TbBook.DataList.Where((cfg) => { return cfg.BookType == GetSelectedBookType(); }).ToList();
            m_list_book.RefreshList(m_BookList);

            m_list_book.RefreshSelectionCtrl();
        }

        private void OnRenderRole(int index, GObject obj, object data)
        {
            var role = data as Role;
            var item = obj as FGUIBtnRole;
            item.Refresh(role);
        }

        private void OnRenderBook(int index, GObject item, object data)
        {
            var cfg = data as BookCfg;
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
                txt += SkillUtil.GetBuffDesc(buffId);
            }
            foreach (var skillId in cfg.SkillList)
            {
                txt += SkillUtil.GetSkillDesc(skillId);
            }

            m_txt_book.text = txt;

            var canLearn = GetSelectedRole()?.CanLearnBook(cfg.Id) ?? false;
            m_btn_learn.text = canLearn ? "学习" : "不可学习";
        }

        private void OnClickBtnLearn()
        {
            var role = GetSelectedRole();
            var bookCfg = m_BookList[m_list_book.selectedIndex];
            role?.LearnBook(bookCfg.Id);

            RefreshList();
        }

        private BookCfg GetSelectedBook()
        {
            var index = m_list_book.selectedIndex;
            if (index < 0) return null;

            return m_BookList[index] as BookCfg;
        }
        
        private PlayerRole GetSelectedRole()
        {
            var index = m_list_role.m_list.selectedIndex;
            if (index < 0 || m_RoleList.Count < index)
            {
                return null;
            }

            return m_RoleList[index];
        }

        public EBookType GetSelectedBookType()
        {
            var index = m_list_book_type.selectedIndex;
            return BookTypeList[index];
        }
    }
}