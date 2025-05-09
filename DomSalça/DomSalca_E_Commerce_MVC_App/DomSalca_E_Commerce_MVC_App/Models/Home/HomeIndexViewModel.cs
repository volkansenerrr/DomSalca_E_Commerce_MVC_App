using DomSalca_E_Commerce_MVC_App.DAL;
using DomSalca_E_Commerce_MVC_App.Repository;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace DomSalca_E_Commerce_MVC_App.Models.Home
{
    public class HomeIndexViewModel
{
    public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
    DomSalca_DBEntities context = new DomSalca_DBEntities();

    public IEnumerable<Tbl_Product> ListofProducts { get; set; }

    public HomeIndexViewModel CreateModel(string search,int pageSize,int? page)
    {
        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@search", search ?? (object)DBNull.Value)
        };

        IEnumerable<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);

        var model = new HomeIndexViewModel();
        model.ListofProducts = data;
        return model;
    }
}

}