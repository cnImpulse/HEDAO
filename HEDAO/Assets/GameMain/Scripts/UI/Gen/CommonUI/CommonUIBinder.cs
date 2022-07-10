/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;

namespace FGUI.CommonUI
{
    public class CommonUIBinder
    {
        public static void BindAll()
        {
            UIObjectFactory.SetPackageItemExtension(FGUIMenu.URL, typeof(FGUIMenu));
            UIObjectFactory.SetPackageItemExtension(FGUILoadGame.URL, typeof(FGUILoadGame));
            UIObjectFactory.SetPackageItemExtension(FGUILoadGameItem.URL, typeof(FGUILoadGameItem));
        }
    }
}