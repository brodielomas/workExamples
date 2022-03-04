using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDevAssignment1.Models;

namespace WebDevAssignment1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<WebDevAssignment1.Models.Thing> RThings2_GetData()
        {
            var db = new ThingsDBEntities(); 
            var things = (from ti in db.Things
                            orderby ti.item_ID ascending
                            select ti).ToList();


            return things;
        }

    }
}