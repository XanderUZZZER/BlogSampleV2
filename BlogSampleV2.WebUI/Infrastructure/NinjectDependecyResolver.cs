using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogSampleV2.WebUI.Infrastructure
{
  public class NinjectDependecyResolver : IDependencyResolver
  {
    public object GetService(Type serviceType)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      throw new NotImplementedException();
    }
  }
}