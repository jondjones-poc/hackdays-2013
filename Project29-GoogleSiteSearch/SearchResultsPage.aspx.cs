using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Linq;

namespace Jondjones.com.Example
{
    public partial class SearchResultsPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void PostbackResults(object sender, EventArgs e)
        {
                var url = HttpContext.Current.Request.Url.AbsoluteUri;
                var query = searchText.Text;

                Response.Redirect(string.format("{0}?q={1}", url, query);
        }
    }
}
