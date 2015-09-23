using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    /// <summary>
    /// 逻辑层操作集合
    /// </summary>
    public class ServiceSession
    {
        internal ServiceSession() { }

        UsersService _UsersService;
        public UsersService UsersService
        {
            get
            {
                if (_UsersService == null) _UsersService = new UsersService();
                return _UsersService;
            }
        }

        UserOptionsService _UserOptionsService;
        public UserOptionsService UserOptionsService
        {
            get
            {
                if (_UserOptionsService == null) _UserOptionsService = new UserOptionsService();
                return _UserOptionsService;
            }
        }

        ThemeOptionsService _ThemeOptionsService;
        public ThemeOptionsService ThemeOptionsService
        {
            get
            {
                if (_ThemeOptionsService == null) _ThemeOptionsService = new ThemeOptionsService();
                return _ThemeOptionsService;
            }
        }

        TagsService _TagsService;
        public TagsService TagsService
        {
            get
            {
                if (_TagsService == null) _TagsService = new TagsService();
                return _TagsService;
            }
        }

        PostsService _PostsService;
        public PostsService PostsService
        {
            get
            {
                if (_PostsService == null) _PostsService = new PostsService();
                return _PostsService;
            }
        }

        PostOptionsService _PostOptionsService;
        public PostOptionsService PostOptionsService
        {
            get
            {
                if (_PostOptionsService == null) _PostOptionsService = new PostOptionsService();
                return _PostOptionsService;
            }
        }

        PostInTagsService _PostInTagsService;
        public PostInTagsService PostInTagsService
        {
            get
            {
                if (_PostInTagsService == null) _PostInTagsService = new PostInTagsService();
                return _PostInTagsService;
            }
        }

        PostInCategoriesService _PostInCategoriesService;
        public PostInCategoriesService PostInCategoriesService
        {
            get
            {
                if (_PostInCategoriesService == null) _PostInCategoriesService = new PostInCategoriesService();
                return _PostInCategoriesService;
            }
        }

        OptionsService _OptionsService;
        public OptionsService OptionsService
        {
            get
            {
                if (_OptionsService == null) _OptionsService = new OptionsService();
                return _OptionsService;
            }
        }

        NavsService _NavsService;
        public NavsService NavsService
        {
            get
            {
                if (_NavsService == null) _NavsService = new NavsService();
                return _NavsService;
            }
        }

        NavGroupService _NavGroupService;
        public NavGroupService NavGroupService
        {
            get
            {
                if (_NavGroupService == null) _NavGroupService = new NavGroupService();
                return _NavGroupService;
            }
        }

        LinksService _LinksService;
        public LinksService LinksService
        {
            get
            {
                if (_LinksService == null) _LinksService = new LinksService();
                return _LinksService;
            }
        }

        CommentsService _CommentsService;
        public CommentsService CommentsService
        {
            get
            {
                if (_CommentsService == null) _CommentsService = new CommentsService();
                return _CommentsService;
            }
        }

        CommentOptionsService _CommentOptionsService;
        public CommentOptionsService CommentOptionsService
        {
            get
            {
                if (_CommentOptionsService == null) _CommentOptionsService = new CommentOptionsService();
                return _CommentOptionsService;
            }
        }

        CategoriesService _CategoriesService;
        public CategoriesService CategoriesService
        {
            get
            {
                if (_CategoriesService == null) _CategoriesService = new CategoriesService();
                return _CategoriesService;
            }
        }
    }
}
