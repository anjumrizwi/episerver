using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Framework.Web;
using EPiServer.Search;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using EPiServerDemoSite.Models;
using EPiServerDemoSite.Models.Pages;
using EPiServerDemoSite.Models.ViewModels;
using EPiServer;
using EPiServer.Search.Queries;
using EPiServer.Search.Queries.Lucene;
using EPiServer.Security;


namespace EPiServerDemoSite.Controllers
{
    public class SearchPageController : PageControllerBase<SearchPage>
    {
        private const int MaxResults = 40;

        [ValidateInput(false)]
        public ViewResult Index(SearchPage currentPage, string q)
        {
            var model = new SearchContentModel(currentPage)
            {
                SearchServiceDisabled = !IsActive,
                SearchedQuery = q
            };

            if (!string.IsNullOrWhiteSpace(q) && IsActive)
            {
                var hits = Search(q.Trim(),
                    new[] { SiteDefinition.Current.StartPage, SiteDefinition.Current.GlobalAssetsRoot, SiteDefinition.Current.SiteAssetsRoot },
                    ControllerContext.HttpContext,
                    currentPage.LanguageID).ToList();
                model.Hits = hits;
                model.NumberOfHits = hits.Count();
            }
            
            return View(model);
        }

        public virtual bool IsActive
        {
            get { return SearchSettings.Config.Active; }
        }

        /// <summary>
        /// Performs a search for pages and media and maps each result to the view model class SearchHit.
        /// </summary>
        /// <remarks>
        /// The search functionality is handled by the injected SearchService in order to keep the controller simple.
        /// Uses EPiServer Search. For more advanced search functionality such as keyword highlighting,
        /// facets and search statistics consider using EPiServer Find.
        /// </remarks>
        private IEnumerable<SearchContentModel.SearchHit> Search(string searchText, IEnumerable<ContentReference> searchRoots, HttpContextBase context, string languageBranch)
        {
            var searchResults = Search(searchText, searchRoots, context, languageBranch, MaxResults);

            return searchResults.IndexResponseItems.SelectMany(CreateHitModel);
        }

        private IEnumerable<SearchContentModel.SearchHit> CreateHitModel(IndexResponseItem responseItem)
        {
            var serviceLocator = ServiceLocator.Current.GetInstance<IContentLoader>();
            var content = serviceLocator.Get<IContent>(Guid.Parse(responseItem.Id.Split('|')[0]));
            //var content = ServiceLocator.Current.GetInstance<IContent>(responseItem.Id);
            if (content != null && IsPublished(content as IVersionable))
            {
                yield return CreatePageHit(content);
            }
        }

        private bool HasTemplate(IContent content)
        {
            var templateResolver = ServiceLocator.Current.GetInstance<TemplateResolver>();
            return templateResolver.HasTemplate(content, TemplateTypeCategories.Page);
        }

        private bool IsPublished(IVersionable content)
        {
            if (content == null)
                return true;
            return content.Status.HasFlag(VersionStatus.Published);
        }

        private SearchContentModel.SearchHit CreatePageHit(IContent content)
        {
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();

            return new SearchContentModel.SearchHit
            {
                Title = content.Name,
                Url = urlResolver.GetUrl(content.ContentLink),
                Excerpt = content is EPiPageData ? ((EPiPageData)content).TeaserText : string.Empty
            };
        }

        public virtual SearchResults Search(string searchText, IEnumerable<ContentReference> searchRoots, HttpContextBase context, string languageBranch, int maxResults)
        {
            var searchHandler = ServiceLocator.Current.GetInstance<SearchHandler>();
            var query = CreateQuery(searchText, searchRoots, context, languageBranch);
            return searchHandler.GetSearchResults(query, 1, maxResults);
        }

        private IQueryExpression CreateQuery(string searchText, IEnumerable<ContentReference> searchRoots, HttpContextBase context, string languageBranch)
        {
            //Main query which groups other queries. Each query added
            //must match in order for a page or file to be returned.
            var query = new GroupQuery(LuceneOperator.AND);

            //Add free text query to the main query
            query.QueryExpressions.Add(new FieldQuery(searchText));

            //Search for pages using the provided language
            var pageTypeQuery = new GroupQuery(LuceneOperator.AND);
            pageTypeQuery.QueryExpressions.Add(new ContentQuery<PageData>());
            pageTypeQuery.QueryExpressions.Add(new FieldQuery(languageBranch, Field.Culture));

            //Search for media without languages
            var contentTypeQuery = new GroupQuery(LuceneOperator.OR);
            contentTypeQuery.QueryExpressions.Add(new ContentQuery<MediaData>());
            contentTypeQuery.QueryExpressions.Add(pageTypeQuery);

            query.QueryExpressions.Add(contentTypeQuery);

            //Create and add query which groups type conditions using OR
            var typeQueries = new GroupQuery(LuceneOperator.OR);
            query.QueryExpressions.Add(typeQueries);

            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            foreach (var root in searchRoots)
            {
                var contentRootQuery = new VirtualPathQuery();
                contentRootQuery.AddContentNodes(root, contentLoader);
                typeQueries.QueryExpressions.Add(contentRootQuery);
            }

            var accessRightsQuery = new AccessControlListQuery();
            accessRightsQuery.AddAclForUser(PrincipalInfo.Current, context);
            query.QueryExpressions.Add(accessRightsQuery);

            return query;
        }
    }
}