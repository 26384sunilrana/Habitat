﻿namespace Sitecore.Foundation.SitecoreExtensions.Rendering
{
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.ContentSearch;
  using Sitecore.ContentSearch.SearchTypes;
  using Sitecore.ContentSearch.Utilities;
  using Sitecore.Data.Items;
  using Sitecore.Mvc.Presentation;
  using Sitecore.Pipelines;
  using Sitecore.Pipelines.GetRenderingDatasource;

  public class QueryableDatasourceRenderingModel : RenderingModel
  {
    public Item DatasourceTemplate { get; set; }

    public override void Initialize(Rendering rendering)
    {
      base.Initialize(rendering);
      ResolveDatasourceTemplate(rendering);
    }

    public virtual IEnumerable<Item> Items
    {
      get
      {
        var dataSource = Rendering.DataSource;
        if (string.IsNullOrEmpty(dataSource))
        {
          return Enumerable.Empty<Item>();
        }

        using (var providerSearchContext = ContentSearchManager.GetIndex((SitecoreIndexableItem)Context.Item).CreateSearchContext())
        {
          var query = LinqHelper.CreateQuery<SearchResultItem>(providerSearchContext, SearchStringModel.ParseDatasourceString(dataSource));
          query = AddTemplatesPredicate(query);
          return query.Select(current => current != null ? current.GetItem() : null).ToArray().Where(item => item != null);
        }
      }
    }

    private IQueryable<SearchResultItem> AddTemplatesPredicate(IQueryable<SearchResultItem> query)
    {
      if (DatasourceTemplate == null)
      {
        return query;
      }
      var templateId = IdHelper.NormalizeGuid(DatasourceTemplate.ID);
      return query.Cast<SearchResult>().Where(x => x.Templates.Contains(templateId));
    }


    private void ResolveDatasourceTemplate(Rendering rendering)
    {
      var getRenderingDatasourceArgs = new GetRenderingDatasourceArgs(rendering.RenderingItem.InnerItem)
                                       {
                                         FallbackDatasourceRoots = new List<Item>
                                                                   {
                                                                     Context.Database.GetRootItem()
                                                                   },
                                         ContentLanguage = rendering.Item?.Language,
                                         ContextItemPath = rendering.Item?.Paths.FullPath ?? PageItem.Paths.FullPath
                                       };
      CorePipeline.Run("getRenderingDatasource", getRenderingDatasourceArgs);

      DatasourceTemplate = getRenderingDatasourceArgs.Prototype;
    }
  }
}