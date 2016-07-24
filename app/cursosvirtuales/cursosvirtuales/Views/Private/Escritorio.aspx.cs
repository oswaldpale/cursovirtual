using cursosvirtuales.Controllers;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cursosvirtuales.Views
{
    public partial class Escritorio : System.Web.UI.Page
    {
        Controller _controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.path = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/"));

            if (!X.IsAjaxRequest)
            {
                if (Session["Usuario"] != null)
                {
                    this.menu();
                }
                else
                    Response.Redirect("Error.aspx");

            }
        }

        private void menu()
        {

            int x = int.Parse(Session["Rol"].ToString());

            DataTable menus = _controller.MenuForm(x);

            Ext.Net.MenuItem menuItem = new Ext.Net.MenuItem();


            foreach (DataRow row in menus.Rows)
            {
                menuItem = new Ext.Net.MenuItem
                {
                    ID = row["IDMENU"].ToString().Replace(' ', '_'),
                    Text = row["NOMBRE"].ToString(),
                    Icon = Icon.Folder,
                    HideOnClick = false,

                };

                if (SubMenus(menuItem, row))
                {
                    Desktop.GetInstance().StartMenu.MenuItems.Add(menuItem);
                }
            }

        }

        protected void Logout_Click(object sender, DirectEventArgs e)
        {
            // Logout from Authenticated Session
            Session.RemoveAll();
            this.Response.Redirect("../Public/Login.aspx");
        }

        private bool SubMenus(Ext.Net.MenuItem menuItem, DataRow row)
        {
            try
            {
                int x = int.Parse(Session["Rol"].ToString());

                DataTable submenu = _controller.SubMenuForm(int.Parse(row["IDMENU"].ToString()), x);

                if (submenu.Rows.Count < 1)
                    return false;

                Ext.Net.MenuItem item = new Ext.Net.MenuItem();
                Ext.Net.Menu subMenu = new Ext.Net.Menu();

                foreach (DataRow _row in submenu.Rows)
                {
                    if (string.IsNullOrEmpty(_row["URL"].ToString()))
                    {
                        item = new Ext.Net.MenuItem
                        {
                            ID = "M" + _row["NOMBRE"].ToString().Replace(' ', '_'),
                            Text = _row["NOMBRE"].ToString(),
                            Icon = Ext.Net.Icon.Folder,
                            HideOnClick = false

                        };

                        if (SubMenus(item, _row))
                            subMenu.Items.Add(item);
                    }
                    else
                    {
                        string win = "DynamicWindow({0},'{1}','{2}','{3}',{4},{5}, false);";
                        string url = Global.path + "/" + _row["Url"];
                        win = string.Format(win, "#{Desktop1}", "win_" + _row["SUBMENUID"], _row["NOMBRE"], url, _row["ANCHO"], _row["ALTO"]);

                        item = new Ext.Net.MenuItem
                        {
                            ID = "P" + _row["NOMBRE"].ToString().Replace(' ', '_'),
                            Text = _row["NOMBRE"].ToString(),
                            Icon = Ext.Net.Icon.ApplicationForm,
                            Listeners =
                            {

                                Click =
                                {
                                    Handler = win,
                                },
                            },
                        };

                        subMenu.Items.Add(item);
                    }
                }

                if (subMenu.Items.Count > 0)
                {
                    menuItem.Menu.Add(subMenu);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}