using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;


namespace Controller
{
    public class BranschController
    {
        public static DataTable ReadAll()
        {
            return BranschAccess.ReadAll();
        }
        public static Bransch FindById(int branschId)
        {
            return BranschAccess.FindById(branschId);
        }
        public static bool CreateBransch(Bransch bransch)
        {
            return BranschAccess.CreateBransch(bransch);
        }
        public static bool UpdateBransch(Bransch bransch)
        {
            return BranschAccess.UpdateBransch(bransch);
        }
    }
}
