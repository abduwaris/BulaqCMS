using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.IDAL;

namespace BulaqCMS.DALService
{
    public class DALSession : IDALSession
    {
        internal DALSession() { }

        IUsersDAL _UserDAL;
        public IUsersDAL UserDAL
        {
            get
            {
                if (_UserDAL == null) _UserDAL = AbstraFactory.CreateUsersDAL();
                return _UserDAL;
            }
        }

        IUserOptionsDAL _UserOptionsDAL;
        public IUserOptionsDAL UserOptionsDAL
        {
            get
            {
                if (_UserOptionsDAL == null) _UserOptionsDAL = AbstraFactory.CreateUserOptionsDAL();
                return _UserOptionsDAL;
            }
        }

        IThemeOptionsDAL _ThemeOptionsDAL;
        public IThemeOptionsDAL ThemeOptionsDAL
        {
            get
            {
                if (_ThemeOptionsDAL == null) _ThemeOptionsDAL = AbstraFactory.CreateThemeOptionsDAL();
                return _ThemeOptionsDAL;
            }
        }

        ITagsDAL _TagsDAL;
        public ITagsDAL TagsDAL
        {
            get
            {
                if (_TagsDAL == null) _TagsDAL = AbstraFactory.CreateTagsDAL();
                return _TagsDAL;
            }
        }

        IPostsDAL _PostsDAL;
        public IPostsDAL PostsDAL
        {
            get
            {
                if (_PostsDAL == null) _PostsDAL = AbstraFactory.CreatePostsDAL();
                return _PostsDAL;
            }
        }

        IPostOptionsDAL _PostOptionsDAL;
        public IPostOptionsDAL PostOptionsDAL
        {
            get
            {
                if (_PostOptionsDAL == null) _PostOptionsDAL = AbstraFactory.CreatePostOptionsDAL();
                return _PostOptionsDAL;
            }
        }

        IPostInTagsDAL _PostInTagsDAL;
        public IPostInTagsDAL PostInTagsDAL
        {
            get
            {
                if (_PostInTagsDAL == null) _PostInTagsDAL = AbstraFactory.CreatePostInTagsDAL();
                return _PostInTagsDAL;
            }
        }

        IPostInCategoriesDAL _PostInCategoriesDAL;
        public IPostInCategoriesDAL PostInCategoriesDAL
        {
            get
            {
                if (_PostInCategoriesDAL == null) _PostInCategoriesDAL = AbstraFactory.CreatePostInCategoriesDAL();
                return _PostInCategoriesDAL;
            }
        }

        IOptionsDAL _OptionsDAL;
        public IOptionsDAL OptionsDAL
        {
            get
            {
                if (_OptionsDAL == null) _OptionsDAL = AbstraFactory.CreateOptionsDAL();
                return _OptionsDAL;
            }
        }

        INavsDAL _NavsDAL;
        public INavsDAL NavsDAL
        {
            get
            {
                if (_NavsDAL == null) _NavsDAL = AbstraFactory.CreateNavsDAL();
                return _NavsDAL;
            }
        }

        INavGroupDAL _NavGroupDAL;
        public INavGroupDAL NavGroupDAL
        {
            get
            {
                if (_NavGroupDAL == null) _NavGroupDAL = AbstraFactory.CreateNavGroupDAL();
                return _NavGroupDAL;
            }
        }

        ILinksDAL _LinksDAL;
        public ILinksDAL LinksDAL
        {
            get
            {
                if (_LinksDAL == null) _LinksDAL = AbstraFactory.CreateLinksDAL();
                return _LinksDAL;
            }
        }

        ICommentsDAL _CommentsDAL;
        public ICommentsDAL CommentsDAL
        {
            get
            {
                if (_CommentsDAL == null) _CommentsDAL = AbstraFactory.CreateCommentsDAL();
                return _CommentsDAL;
            }
        }

        ICommentOptionsDAL _CommentOptionsDAL;
        public ICommentOptionsDAL CommentOptionsDAL
        {
            get
            {
                if (_CommentOptionsDAL == null) _CommentOptionsDAL = AbstraFactory.CreateCommentOptionsDAL();
                return _CommentOptionsDAL;
            }
        }

        ICategoriesDAL _CategoriesDAL;
        public ICategoriesDAL CategoriesDAL
        {
            get
            {
                if (_CategoriesDAL == null) _CategoriesDAL = AbstraFactory.CreateCategoriesDAL();
                return _CategoriesDAL;
            }
        }
    }
}
