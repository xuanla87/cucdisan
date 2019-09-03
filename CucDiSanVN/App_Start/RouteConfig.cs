using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CucDiSanVN
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "CHITIETVIDEO",
            url: "chi-tiet-video-{id}/",
            defaults: new { controller = "Home", action = "VideoDetail", id = UrlParameter.Optional }
           );
            routes.MapRoute(
           name: "TIMKIEM",
           url: "tim-kiem",
           defaults: new { controller = "Home", action = "Search", id = UrlParameter.Optional }
          );
            routes.MapRoute(
           name: "SUKIENQUAANH",
           url: "su-kien-hinh-anh",
           defaults: new { controller = "Home", action = "GetAllAnh", id = UrlParameter.Optional }
          );
            routes.MapRoute(
          name: "LIENHE",
          url: "lien-he",
          defaults: new { controller = "Home", action = "LienHe", id = UrlParameter.Optional }
         );
            routes.MapRoute(
        name: "SODOWEBSITE",
        url: "so-do-website",
        defaults: new { controller = "Home", action = "SoDoWebsite", id = UrlParameter.Optional }
       );
            routes.MapRoute(
          name: "TRACUUVANBAN",
          url: "tra-cuu-van-ban",
          defaults: new { controller = "Home", action = "TraCuuVanBan", id = UrlParameter.Optional }
         );

            routes.MapRoute(
          name: "VIDEOALL",
          url: "video-clip/{id}",
          defaults: new { controller = "Home", action = "VideoAll", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "DUTHAOYKIEN",
             url: "van-ban-du-thao-xin-y-kien-dong-gop",
             defaults: new { controller = "Home", action = "YKienDongGop", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "DUTHAOYKIENCHITIET",
             url: "van-ban-du-thao-xin-y-kien-dong-gop-{id}",
             defaults: new { controller = "Home", action = "YKienDongGopDetail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "detail",
              url: "{pageUrl}",
              defaults: new { controller = "Home", action = "Display", pageUrl = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }

    }
}
