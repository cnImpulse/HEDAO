using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class DiscipleForm : FGUIForm<FGUIDiscipleForm>
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_list_disciple.itemRenderer = RenderListItem;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            View.m_list_disciple.numItems = GameEntry.Save.PlayerData.RoleList.Count;

            float[] arr = { 0.9f, 0.4f, 0.3f, 0.8f, 0.5f };
            View.m_rader.m_img_wuxing.shape.DrawRegularPolygon(5, 4, Color.white, Color.black, Color.white, 54, arr);

            int length = 50;
            var a = Mathf.Sin(54 * Mathf.Deg2Rad) * length;
            var b = Mathf.Cos(54 * Mathf.Deg2Rad) * length;
            var c = Mathf.Sin(72 * Mathf.Deg2Rad) * length;
            var d = Mathf.Cos(72 * Mathf.Deg2Rad) * length;
            //List<Vector2> points = new List<Vector2>() { new Vector2(0, length), new Vector2(c, d), new Vector2(b, -a), new Vector2(-b, -a), new Vector2(-c, d) };
            //View.m_rader.m_graph_wuxing.shape.DrawPolygon(new List<Vector2>() { Vector2.zero, points[0], points[1], Vector2.zero, points[1], points[2], Vector2.zero, points[2], points[3], Vector2.zero, points[3], points[4], Vector2.zero, points[4], points[0], }, Color.white, 2, Color.black);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void RenderListItem(int index, GObject obj)
        {
            var item = obj.asButton;

            //var data = GameEntry.Save.PlayerData.RoleList[index];
            //item.title = data.
        }
    }
}