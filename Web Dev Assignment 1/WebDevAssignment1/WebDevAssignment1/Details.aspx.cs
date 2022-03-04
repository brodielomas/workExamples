using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDevAssignment1
{
    public partial class Details : System.Web.UI.Page
    {
        //Models.ThingsDBEntities db = new Models.ThingsDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public WebDevAssignment1.Models.Thing FormView1_GetItem([QueryString]string id)
        /*{
            Models.Thing thing = null;

            if (id != null)
            {
                int? num = int.Parse(id);

                if (num.HasValue)
                {

                    Console.WriteLine(num);
                    thing = db.Things.Find(num.Value);

                    //thing = (from ti in db.Things
                    //where ti.item_ID == id.Value
                    //select ti).FirstOrDefault();


                }
            }
            return thing;
        }*/
    }
}