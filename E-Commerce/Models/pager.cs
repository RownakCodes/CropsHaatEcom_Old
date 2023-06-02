using System;

namespace E_Commerce.Models
{
    public class pager
    {
       public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }



        public int TotalPages{ get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }


        public void Pager()
        {

        }

        public void Pager(int totalItems, int page,int pagesize=10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems/(decimal)pagesize);
            int currentpage = page;


            int startpage = currentpage - 5;
            int endpage=currentpage + 5;

            if (startpage <= 0)
            {
                endpage=endpage-(startpage-1);
                startpage=1;
            }

            if (endpage > totalPages)
            {
                endpage= totalPages;
                if (endpage > 10)
                {
                    startpage=endpage-(9);
                }
            }
            TotalItems=totalItems;
            CurrentPage=currentpage;
            PageSize=pagesize;
            TotalPages=totalPages;
            StartPage=startpage;
            EndPage=endpage;
        }
    }
}
