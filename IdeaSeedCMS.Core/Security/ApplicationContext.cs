using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeedCMS.Core.Domain;
using IdeaSeed.Core;

namespace IdeaSeedCMS.Core.Security
{
    public class ApplicationContext
    {
        public static IList<BannerImage> BannerImageData
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_BannerImageData] != null)
                {
                    return (IList<BannerImage>)SessionManager.Current[ResourceStrings.Session_BannerImageData];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_BannerImageData] = value;
            }
        }

        public static IList<Blog> HomeBlogListData
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_HomeBlogListData] != null)
                {
                    return (IList<Blog>)SessionManager.Current[ResourceStrings.Session_HomeBlogListData];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_HomeBlogListData] = value;
            }
        }

        public static BlogPostType CurrentBlogPostType
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentBlogPostType] != null)
                {
                    return (BlogPostType)SessionManager.Current[ResourceStrings.Session_CurrentBlogPostType];
                }
                return 0;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentBlogPostType] = value;
            }
        }

        public static Blog CurrentBlog
        {
            get
            {
                if (SessionManager.Current[ResourceStrings.Session_CurrentBlog] != null)
                {
                    return (Blog)SessionManager.Current[ResourceStrings.Session_CurrentBlog];
                }
                return null;
            }
            set
            {
                SessionManager.Current[ResourceStrings.Session_CurrentBlog] = value;
            }
        }
    }
}
