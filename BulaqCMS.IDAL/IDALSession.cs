using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface IDALSession
    {
        IUsersDAL UserDAL { get; }

        IUserOptionsDAL UserOptionsDAL { get; }

        IThemeOptionsDAL ThemeOptionsDAL { get; }

        ITagsDAL TagsDAL { get; }

        IPostsDAL PostsDAL { get; }

        IPostOptionsDAL PostOptionsDAL { get; }

        IPostInTagsDAL PostInTagsDAL { get; }

        IPostInCategoriesDAL PostInCategoriesDAL { get; }

        IOptionsDAL OptionsDAL { get; }

        INavsDAL NavsDAL { get; }

        INavGroupDAL NavGroupDAL { get; }

        ILinksDAL LinksDAL { get; }

        ICommentsDAL CommentsDAL { get; }

        ICommentOptionsDAL CommentOptionsDAL { get; }

        ICategoriesDAL CategoriesDAL { get; }
    }
}
