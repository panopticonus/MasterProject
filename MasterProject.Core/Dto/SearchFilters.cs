namespace MasterProject.Core.Dto
{
    using System;
    using System.Collections.Specialized;

    public class SearchFilters
    {
        public SearchFilters()
        {
            DisplayLength = 25;
            DisplayStart = 0;
            OrderBy = string.Empty;
            SearchValue = string.Empty;
        }

        public SearchFilters(NameValueCollection form)
        {
            DisplayLength = Convert.ToInt32(form["length"]);
            DisplayStart = Convert.ToInt32(form["start"]);
            SearchValue = form["search[value]"];
            OrderByDir = Convert.ToString(form["order[0][dir]"])?.ToUpper();
        }

        public int DisplayLength { get; set; }
        public int DisplayStart { get; set; }
        public string OrderBy { get; set; }
        public string SearchValue { get; set; }
        public string OrderByDir { get; set; }
    }
}
