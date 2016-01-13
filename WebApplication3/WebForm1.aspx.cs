using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Class1 loadData = new Class1();
            loadData.ReadData("select LargePhoto from Production.ProductPhoto where ProductPhotoID='69'");


            ListBox1.DataSource = loadData.sqlDataTable;
            
            ListBox1.DataTextField = "ProductPhotoID";
            ListBox1.DataBind();
            //DropDownList1.DataSource = loadData.sqlDataTable;
            //DropDownList1.DataTextField = "Name";
            ////DropDownList1.DataValueField = "";
            //DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Class1 saveData = new Class1();
            saveData.InsertUpdateDelete("insert into Production.ProductCategory(Name) values ('" + TextBox1.Text.ToString() + "')");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Class1 delete = new Class1();
            delete.InsertUpdateDelete("delete from Production.ProductCategory Where Name='"+DropDownList1.SelectedValue +"'");
        }
    }
}