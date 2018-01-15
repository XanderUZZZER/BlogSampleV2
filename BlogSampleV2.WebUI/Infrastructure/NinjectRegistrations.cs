using BlogSampleV2.Domain.Interfaces;
using BlogSampleV2.Domain.EF;
using Ninject.Modules;
using System.Web.ModelBinding;

namespace BlogSampleV2.WebUI.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IBlogRepository>().To<BlogRepository>();
        }
    }
}