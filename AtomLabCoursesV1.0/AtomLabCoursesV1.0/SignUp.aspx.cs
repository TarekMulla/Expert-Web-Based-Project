using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AtomLabCoursesV1._0.DataBaseLayer;

namespace AtomLabCoursesV1._0
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SentBtn_Click(object sender, EventArgs e)
        {
            string username = UserNameTB.Text;
            string firstname = FirstNameTB.Text;
            string lastname = LastNameTB.Text;
            string password = PasswordTB.Text;
            string email = EmailTB.Text;
            string job = JobTB.Text;
            int id = UsersTable.Insert(firstname, lastname, username, password, email, job);

            List<Category> categories = CategoriesTable.SelectAll();
            int i=0;
            foreach(ListViewItem item in ((ListView)CategoriesMenu.Controls[2]).Items)
            {
                int expert = int.Parse(((DropDownList)item.Controls[1]).SelectedValue);
                if (expert != 0)
                    UsersExpertTable.Insert(categories[i].ID, id, expert);
                i++;
            }

        }
    }
}