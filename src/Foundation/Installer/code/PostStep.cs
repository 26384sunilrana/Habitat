﻿namespace Sitecore.Foundation.Installer
{
  using System;
  using System.Collections.Specialized;
  using System.Diagnostics;
  using System.Linq;
  using Sitecore.Diagnostics;
  using Sitecore.Install.Framework;

  public class PostStep : IPostStep
  {
    public void Run(ITaskOutput output, NameValueCollection metaData)
    {
      Debugger.Break();
      var getPostStepActionList = metaData["Attributes"].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x=>x.Split('=')[1]);

      foreach (var postStepAction in getPostStepActionList)
      {
        try
        {
          var postStepActionType = Type.GetType(postStepAction);
          if (postStepActionType == null)
          {
            throw new Exception($"Can't find specified type with name {postStepAction}");
          }

          Log.Info(postStepAction + " post step action was started", this);

          var activator = (IPostStepAction)Activator.CreateInstance(postStepActionType);
          activator.Run();
        }
        catch (Exception ex)
        {
          Log.Error(postStepAction + " post step action has failed", ex, this);
        }
      }
    }
  }
}