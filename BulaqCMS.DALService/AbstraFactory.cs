using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.DALService
{
    public abstract class AbstraFactory
    {
        static object CreateInstance(string className)
        {
            string asm = ConfigurationManager.AppSettings["DALAssembly"];
            var assembly = Assembly.Load(asm);
            string classFulleName = ConfigurationManager.AppSettings["DALNameSpace"] + "." + className;
            return assembly.CreateInstance(classFulleName);
        }

        public static IUsersDAL CreateUsersDAL()
        {
            return CreateInstance("UsersDAL") as IUsersDAL;
        }
        public static IUserOptionsDAL CreateUserOptionsDAL()
        {
            return CreateInstance("UserOptionsDAL") as IUserOptionsDAL;
        }
        public static IThemeOptionsDAL CreateThemeOptionsDAL()
        {
            return CreateInstance("ThemeOptionsDAL") as IThemeOptionsDAL;
        }
        public static ITagsDAL CreateTagsDAL()
        {
            return CreateInstance("TagsDAL") as ITagsDAL;
        }

        public static IPostsDAL CreatePostsDAL()
        {
            return CreateInstance("PostsDAL") as IPostsDAL;
        }
        public static IPostOptionsDAL CreatePostOptionsDAL()
        {
            return CreateInstance("PostOptionsDAL") as IPostOptionsDAL;
        }
        public static IPostInTagsDAL CreatePostInTagsDAL()
        {
            return CreateInstance("PostInTagsDAL") as IPostInTagsDAL;
        }

        public static IPostInCategoriesDAL CreatePostInCategoriesDAL()
        {
            return CreateInstance("PostInCategoriesDAL") as IPostInCategoriesDAL;
        }
        public static IOptionsDAL CreateOptionsDAL()
        {
            return CreateInstance("OptionsDAL") as IOptionsDAL;
        }
        public static INavsDAL CreateNavsDAL()
        {
            return CreateInstance("NavsDAL") as INavsDAL;
        }
        public static INavGroupDAL CreateNavGroupDAL()
        {
            return CreateInstance("NavGroupDAL") as INavGroupDAL;
        }

        public static ILinksDAL CreateLinksDAL()
        {
            return CreateInstance("LinksDAL") as ILinksDAL;
        }

        public static ICommentsDAL CreateCommentsDAL()
        {
            return CreateInstance("CommentsDAL") as ICommentsDAL;
        }
        public static ICommentOptionsDAL CreateCommentOptionsDAL()
        {
            return CreateInstance("CommentOptionsDAL") as ICommentOptionsDAL;
        }
        public static ICategoriesDAL CreateCategoriesDAL()
        {
            return CreateInstance("CategoriesDAL") as ICategoriesDAL;
        }

    }
}
