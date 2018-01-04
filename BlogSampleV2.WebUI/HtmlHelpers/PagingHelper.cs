using BlogSampleV2.Domain.Enteties;
using BlogSampleV2.Domain.Interfaces;
using BlogSampleV2.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace BlogSampleV2.WebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            if (pagingInfo.TotalItems <= pagingInfo.ItemsPerPage)
            {
                return MvcHtmlString.Create(string.Empty);
            }
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PostArticle(this HtmlHelper html, ArticlesViewModel model)
        {
            StringBuilder result = new StringBuilder();
            foreach (var article in model.Articles)
            {
                TagBuilder tag = new TagBuilder("div");
                tag.AddCssClass("post");
                TagBuilder itemTag = new TagBuilder("h3");
                itemTag.SetInnerText(article.Title);
                tag.InnerHtml += itemTag.ToString();
                itemTag = new TagBuilder("article");
                itemTag.SetInnerText(article.Text);
                tag.InnerHtml += itemTag.ToString();
                itemTag = new TagBuilder("p");
                itemTag.SetInnerText($@"Posted by <strong>{article.Author.Nick}</strong> {article.PostedDate.ToShortDateString()}");
                tag.InnerHtml += itemTag.ToString();
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PostArticlePreview(this HtmlHelper html, string article, int maxSymbols = 200)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder tag = new TagBuilder("article");
            tag.SetInnerText(article.Length < maxSymbols ? article : article.Substring(0, maxSymbols - 1) + "...");
            result.Append(tag.ToString());
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString CreateCheckedSkillList(this HtmlHelper html, IEnumerable<Skill> skills)
        {
            StringBuilder returnString = new StringBuilder();

            foreach (var s in skills)
            {
                TagBuilder p = new TagBuilder("p");
                TagBuilder input = new TagBuilder("input");
                input.MergeAttribute("name", "skills");
                input.MergeAttribute("value", s.Name);
                input.MergeAttribute("type", "checkbox");
                input.SetInnerText(s.Name);
                p.InnerHtml = input.ToString();
                returnString.Append(p.ToString());
            }
            return new MvcHtmlString(returnString.ToString());
        }
    }
}