using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BulaqCMS.IDAL;

namespace BulaqCMS.DAL.MySql
{
    public class PostsDAL : BaseDAL<PostsModel>, IPostsDAL
    {

        /// <summary>
        /// 根据作者获取文章个数
        /// </summary>
        /// <param name="catId">专辑</param>
        /// <param name="practice">批准</param>
        /// <param name="tagId">标签</param>
        /// <param name="authorid">作者id</param>
        /// <param name="isInRecycle">是否在回收站内</param>
        /// <param name="isDelflag">是否在垃圾</param>
        /// <param name="isApproved">是否批准</param>
        /// <param name="isPractice">草稿</param>
        /// <returns></returns>
        public int Count(int? catId = null, int? tagId = null, int? authorid = null, bool? isApproved = null, bool? isDelflag = null, bool? isPractice = null)
        {
            Dictionary<string, object> dics = new Dictionary<string, object>();
            if (catId != null) dics.Add("cat_id", catId);
            if (tagId != null) dics.Add("tag_id", tagId);
            if (authorid != null) dics.Add("author_id", authorid);
            if (isApproved != null) dics.Add("approved", isApproved);
            if (isDelflag != null) dics.Add("del_flag", isDelflag);
            if (isPractice != null) dics.Add("is_practice", isPractice);
            string sql = "SELECT COUNT(DISTINCT `{0}posts`.`post_id`) FROM `{0}posts`";
            if (catId != null || tagId != null)
            {
                if (tagId == null) sql = "SELECT COUNT(DISTINCT `{0}posts`.`post_id`) FROM `{0}post_in_cats` LEFT JOIN `{0}posts` ON `{0}posts`.`post_id`=`{0}post_in_cats`.`post_id`";
                else if (catId == null) sql = "SELECT `posts`.* FROM `post_in_tags` LEFT JOIN posts ON `posts`.`post_id` = `post_in_tags`.`post_id`";
                else sql = "SELECT COUNT(DISTINCT `new_posts`.`post_id`) FROM `{0}post_in_tags` LEFT JOIN (SELECT `{0}posts`.* FROM `{0}post_in_cats` LEFT JOIN `{0}posts` ON `{0}post_in_cats`.`post_id` = `{0}posts`.`post_id`) AS `new_posts` ON `new_posts`.`post_id` = `{0}post_in_tags`.`post_id`";
            }
            if (dics.Count > 0)
            {
                List<string> wheres = new List<string>();
                foreach (var dic in dics)
                {
                    wheres.Add(string.Format("`{1}`=@{1}", "{0}", dic.Key));
                }
                sql += " Where " + string.Join(" AND ", wheres);
            }
            sql = string.Format(sql, Helper.Prefix);
            return Convert.ToInt32(Helper.First(sql, dics.Select(p => new MySqlParameter("@" + p.Key, p.Value)).ToArray()));
        }

        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="allCount"></param>
        /// <param name="approvedCount"></param>
        /// <param name="delflagCount"></param>
        /// <param name="isInRecycleCount"></param>
        /// <returns></returns>
        public bool Count(ref int allCount, ref int approvedCount, ref int delflagCount)
        {
            string sql = string.Format("SELECT (SELECT COUNT(`{0}posts`.`post_id`) FROM `{0}posts`) AS `total_count`, (SELECT COUNT(`{0}posts`.`post_id`) FROM `{0}posts` WHERE `approved` = TRUE) AS `approved_count`, (SELECT COUNT(`{0}posts`.`post_id`) FROM `{0}posts` WHERE `{0}posts`.`del_flag` = TRUE) AS `del_flag_count` FROM `{0}posts` LIMIT 0,1;", Helper.Prefix);
            DataTable dt = Helper.Select(sql);
            if (dt.Rows.Count < 1) return false;
            DataRow row = dt.Rows[0];
            allCount = Convert.ToInt32(row["total_count"]);
            approvedCount = Convert.ToInt32(row["approved_count"]);
            delflagCount = Convert.ToInt32(row["del_flag_count"]);
            return true;

        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">页容量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByMode">排序模式</param>
        /// <param name="categoryId">专辑ID</param>
        /// <param name="tagId">标签 ID</param>
        /// <param name="authorid">作者 ID</param>
        /// <param name="isApproved">是否批准</param>
        /// <param name="isInRecycle">回收站</param>
        /// <param name="isDelflag">删除标识</param>
        /// <param name="isPractice">草稿</param>
        /// <returns></returns>
        public List<PostsModel> GetPage(int pageSize, int pageIndex, PostsOrderByMode orderByMode, int? categoryId = null, int? tagId = null, int? authorid = null, bool? isApproved = null, bool? isDelflag = null, bool? isPractice = null)
        {
            Dictionary<string, object> dics = new Dictionary<string, object>();
            List<string> wheres = new List<string>();
            if (authorid != null)
            {
                dics.Add("author_id", authorid);
                wheres.Add("`author_id`=@author_id");
            }
            if (isApproved != null)
            {
                dics.Add("approved", isApproved);
                wheres.Add("`approved`=@approved");
            }

            if (isDelflag != null)
            {
                dics.Add("del_flag", isDelflag);
                wheres.Add("`del_flag`=@del_flag");
            }
            if (categoryId != null && categoryId > 0)
            {
                dics.Add("cat_id", categoryId);
                wheres.Add("`{0}post_in_cats`.`cat_id`=@cat_id");
            }
            if (tagId != null)
            {
                dics.Add("tag_id", tagId);
                wheres.Add("`{0}post_in_tags`.`tag_id`=@tag_id");
            }
            if (isPractice != null)
            {
                dics.Add("is_practice", isPractice);
                wheres.Add("`is_practice`=@is_practice");
            }
            string sql = "SELECT DISTINCT `{0}posts`.* FROM `{0}posts`";
            if (categoryId != null || tagId != null)
            {
                if (tagId == null)
                {
                    if (categoryId > 0)
                        sql = "SELECT DISTINCT `{0}posts`.* FROM `{0}post_in_cats` LEFT JOIN `{0}posts` ON `{0}posts`.`post_id`=`{0}post_in_cats`.`post_id`";
                    else
                        sql = "select DISTINCT `{0}posts`.*  from `{0}posts`";
                }
                else if (categoryId == null)
                    sql = "SELECT DISTINCT `{0}posts`.* FROM `{0}post_in_tags` LEFT JOIN `{0}posts` ON `{0}posts`.`post_id` = `{0}post_in_tags`.`post_id`";
                else
                {
                    if (categoryId > 0)
                        sql = "SELECT DISTINCT `new_posts`.* FROM `{0}post_in_tags` LEFT JOIN (SELECT `{0}posts`.* FROM `{0}post_in_cats` LEFT JOIN `{0}posts` ON `{0}post_in_cats`.`post_id` = `{0}posts`.`post_id`) AS `new_posts` ON `new_posts`.`post_id` = `{0}post_in_tags`.`post_id`";
                    else
                        sql = "SELECT DISTINCT `{0}posts`.* FROM `{0}post_in_tags` LEFT JOIN `{0}posts` ON `{0}posts`.`post_id` = `{0}post_in_tags`.`post_id`";
                }

                if (categoryId != null && categoryId <= 0)
                    wheres.Add("`{0}posts`.`post_id` NOT IN(select DISTINCT `{0}posts`.`post_id` from `{0}post_in_cats` LEFT JOIN `{0}posts` on `{0}post_in_cats`.`post_id`=`{0}posts`.`post_id`)");
            }
            //if (dics.Count > 0)
            //{
            //    foreach (var dic in dics)
            //    {
            //        wheres.Add(dic.Key + "=@" + dic.Key);
            //    }
            //}

            if (wheres.Count > 0)
                sql += " WHERE " + string.Join(" AND ", wheres);

            ///Order By
            List<string> orderBy = new List<string>();
            if (orderByMode != PostsOrderByMode.None)
            {
                if (orderByMode == PostsOrderByMode.Approved || orderByMode == PostsOrderByMode.Approved_Desc)
                {
                    if (orderByMode != PostsOrderByMode.Approved_Desc)
                        orderBy.Add("`{0}posts`.`approved` ASC");
                    else if (orderByMode != PostsOrderByMode.Approved)
                        orderBy.Add("`{0}posts`.`approved` DESC");
                }
                if (orderByMode == PostsOrderByMode.Author || orderByMode == PostsOrderByMode.Author_Desc)
                {
                    if (orderByMode != PostsOrderByMode.Author_Desc)
                        orderBy.Add("`{0}posts`.`author_id` ASC");
                    else if (orderByMode != PostsOrderByMode.Author)
                        orderBy.Add("`{0}posts`.`author_id` DESC");
                }
                if (orderByMode == PostsOrderByMode.CanComment || orderByMode == PostsOrderByMode.CanComment_Desc)
                {
                    if (orderByMode != PostsOrderByMode.CanComment_Desc)
                        orderBy.Add("`{0}posts`.`can_comment` ASC");
                    else if (orderByMode != PostsOrderByMode.CanComment)
                        orderBy.Add("`{0}posts`.`can_comment` DESC");
                }
                if (orderByMode == PostsOrderByMode.CreateTime || orderByMode == PostsOrderByMode.CreateTime_Desc)
                {
                    if (orderByMode != PostsOrderByMode.CreateTime_Desc)
                        orderBy.Add("`{0}posts`.`create_time` ASC");
                    else if (orderByMode != PostsOrderByMode.CreateTime)
                        orderBy.Add("`{0}posts`.`create_time` DESC");
                }
                if (orderByMode == PostsOrderByMode.DelFlag || orderByMode == PostsOrderByMode.DelFlag_Desc)
                {
                    if (orderByMode != PostsOrderByMode.DelFlag_Desc)
                        orderBy.Add("`{0}posts`.`del_flag` ASC");
                    else if (orderByMode != PostsOrderByMode.DelFlag)
                        orderBy.Add("`{0}posts`.`del_flag` DESC");
                }
                if (orderByMode == PostsOrderByMode.ID || orderByMode == PostsOrderByMode.ID_Desc)
                {
                    if (orderByMode != PostsOrderByMode.ID_Desc)
                        orderBy.Add("`{0}posts`.`post_id` ASC");
                    else if (orderByMode != PostsOrderByMode.ID)
                        orderBy.Add("`{0}posts`.`post_id` DESC");
                }
                if (orderByMode == PostsOrderByMode.IP || orderByMode == PostsOrderByMode.IP_Desc)
                {
                    if (orderByMode != PostsOrderByMode.IP_Desc)
                        orderBy.Add("`{0}posts`.`author_ip` ASC");
                    else if (orderByMode != PostsOrderByMode.IP)
                        orderBy.Add("`{0}posts`.`author_ip` DESC");
                }
                if (orderByMode == PostsOrderByMode.PasswordState || orderByMode == PostsOrderByMode.PasswordState_Desc)
                {
                    if (orderByMode != PostsOrderByMode.PasswordState_Desc)
                        orderBy.Add("`{0}posts`.`password_state` ASC");
                    else if (orderByMode != PostsOrderByMode.PasswordState)
                        orderBy.Add("`{0}posts`.`password_state` DESC");
                }

                if (orderByMode == PostsOrderByMode.SendTime || orderByMode == PostsOrderByMode.SendTime_Desc)
                {
                    if (orderByMode != PostsOrderByMode.SendTime_Desc)
                        orderBy.Add("`{0}posts`.`send_time` ASC");
                    else if (orderByMode != PostsOrderByMode.SendTime)
                        orderBy.Add("`{0}posts`.`send_time` DESC");
                }
                if (orderByMode == PostsOrderByMode.ThemeGuid || orderByMode == PostsOrderByMode.ThemeGuid_Desc)
                {
                    if (orderByMode != PostsOrderByMode.ThemeGuid_Desc)
                        orderBy.Add("`{0}posts`.`theme_guid` ASC");
                    else if (orderByMode != PostsOrderByMode.ThemeGuid)
                        orderBy.Add("`{0}posts`.`theme_guid` DESC");
                }
                if (orderByMode == PostsOrderByMode.VisibleState || orderByMode == PostsOrderByMode.VisibleState_Desc)
                {
                    if (orderByMode != PostsOrderByMode.VisibleState_Desc)
                        orderBy.Add("`{0}posts`.`visible_state` ASC");
                    else if (orderByMode != PostsOrderByMode.VisibleState)
                        orderBy.Add("`{0}posts`.`visible_state` DESC");
                }
                //charu
                sql += " ORDER BY " + string.Join(", ", orderBy);
            }

            sql += string.Format(" LIMIT {0},{1}", (pageIndex - 1) * pageSize, pageSize);

            sql = string.Format(sql, Helper.Prefix);
            return ToModelList(Helper.Select(sql, dics.Select(p => new MySqlParameter("@" + p.Key, p.Value)).ToArray()));
        }

        /// <summary>
        /// 根据评论ID获取文章
        /// </summary>
        /// <param name="comIds"></param>
        /// <returns></returns>
        public List<PostsModel> GetPostsByCommentsIds(params int[] comIds)
        {
            if (comIds == null || comIds.Length <= 0) return new List<PostsModel>();
            string sql = string.Format("select DISTINCT `{0}posts`.* from `{0}comments` LEFT JOIN `{0}posts` on `{0}posts`.post_id=`{0}comments`.post_id where `{0}comments`.com_id IN ({1});", Helper.Prefix, string.Join(",", comIds));
            return ToModelList(Helper.Select(sql));
        }
        /// <summary>
        /// 根据 ID 获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PostsModel GetPost(int id)
        {
            string sql = string.Format("SELECT * FROM `{0}posts` WHERE `{0}posts`.`post_id`={1}", Helper.Prefix, id);
            return ToModelList(Helper.Select(sql)).FirstOrDefault();
        }

        /// <summary>
        /// 根据文章名获取文章
        /// </summary>
        /// <param name="name">文章名</param>
        /// <param name="isPage">是不是页扫描, 默认是文章</param>
        /// <returns></returns>
        public PostsModel GetPost(string name, bool isPage = false)
        {
            string sql = string.Format("SELECT * FROM `{0}posts` WHERE `{0}posts`.`post_name`=@name AND `{0}posts`.`post_type`=@tp;", Helper.Prefix);
            MySqlParameter[] param = {
                                     new MySqlParameter("@name",name),
                                     new MySqlParameter("@tp",isPage),
                                     };
            return ToModelList(Helper.Select(sql, param)).FirstOrDefault();
        }

        #region 一种插入方式
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="post">要新增的对象</param>
        /// <returns></returns>
        //public int Insert(Posts post)
        //{
        //    string sql = string.Format("INSERT `{0}posts`(`{0}posts`.`author_id`, `{0}posts`.`post_name`, `{0}posts`.`post_title`, `{0}posts`.`content`, `{0}posts`.`create_time`, `{0}posts`.`send_time`, `{0}posts`.`user_agent`, `{0}posts`.`author_ip`, `{0}posts`.`visible_state`, `{0}posts`.`can_comment`, `{0}posts`.`password_state`, `{0}posts`.`post_password`, `{0}posts`.`post_type`, `{0}posts`.`modified`, `{0}posts`.`modified_time`, `{0}posts`.`post_image`, `{0}posts`.`theme_guid`, `{0}posts`.`del_flag`, `{0}posts`.`in_recycle`, `{0}posts`.`approved`) VALUES(@author_id, @post_name, @post_title, @content, @create_time, @send_time, @user_agent, @author_ip, @visible_state, @can_comment, @password_state, @post_password, @post_type, @modified, @modified_time, @post_image, @theme_guid, @del_flag, @in_recycle, @approved);", Helper.Prefix);
        //    MySqlParameter[] param = { 
        //                                 new MySqlParameter("@author_id",post.AuthorID),
        //                                 new MySqlParameter("@post_name",post.Name),
        //                                 new MySqlParameter("@post_title",post.Title),
        //                                 new MySqlParameter("@content",post.Content),
        //                                 new MySqlParameter("@create_time",post.CreateTime),
        //                                 new MySqlParameter("@send_time",post.SendTime),
        //                                 new MySqlParameter("@user_agent",post.UserAgent),
        //                                 new MySqlParameter("@author_ip",post.IP),
        //                                 new MySqlParameter("@visible_state",post.VisibleState),
        //                                 new MySqlParameter("@can_comment",post.CanComment),
        //                                 new MySqlParameter("@password_state",post.PasswordState),
        //                                 new MySqlParameter("@post_password",post.Password),
        //                                 new MySqlParameter("@post_type",post.PostType),
        //                                 new MySqlParameter("@modified",post.Modified),
        //                                 new MySqlParameter("@modified_time",post.LastModifiedTime),
        //                                 new MySqlParameter("@post_image",post.PostImage),
        //                                 new MySqlParameter("@theme_guid",post.ThemeGuid),
        //                                 new MySqlParameter("@del_flag",post.DelFlag),
        //                                 new MySqlParameter("@in_recycle",post.IsInRecycle),
        //                                 new MySqlParameter("@approved",post.Approved)
        //                             };
        //    return Helper.Query(sql, param);
        //} 
        #endregion

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="post">要新增的对象</param>
        /// <param name="isPage">是不是页面</param>
        /// <returns></returns>
        public int Insert(PostsModel post, bool isPage)
        {
            string sql = string.Format("INSERT `{0}posts`(`{0}posts`.`author_id`, `{0}posts`.`post_name`, `{0}posts`.`post_title`, `{0}posts`.`content`, `{0}posts`.`create_time`,  `{0}posts`.`user_agent`, `{0}posts`.`author_ip`,`{0}posts`.`post_type`) VALUES(@author_id, @post_name, @post_title, @content, @create_time, @user_agent, @author_ip,@post_type);", Helper.Prefix);
            MySqlParameter[] param = {
                                         new MySqlParameter("@author_id",post.AuthorID),
                                         new MySqlParameter("@post_name",post.Name),
                                         new MySqlParameter("@post_title",post.Title),
                                         new MySqlParameter("@content",post.Content),
                                         new MySqlParameter("@create_time",post.CreateTime),
                                         new MySqlParameter("@user_agent",post.UserAgent),
                                         new MySqlParameter("@author_ip",post.IP),
                                         new MySqlParameter("@post_type",isPage),
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="post"></param>
        /// <param name="modi"></param>
        /// <returns></returns>
        public int Update(PostsModel post, PostModified modi)
        {
            List<MySqlParameter> param = new List<MySqlParameter>();
            List<string> sets = new List<string>();
            if (modi == PostModified.Approve)
            {
                sets.Add("`{0}posts`.`approved`= @approved");
                param.Add(new MySqlParameter("@approved", post.Approved));
            }
            if (modi == PostModified.DelFlag)
            {
                sets.Add("`{0}posts`.`del_flag`= @del");
                param.Add(new MySqlParameter("@del", post.DelFlag));
            }
            if (modi == PostModified.Image)
            {
                sets.Add("`{0}posts`.`post_image`= @image");
                param.Add(new MySqlParameter("@image", post.PostImage));
            }
            if (modi == PostModified.Practice)
            {
                sets.Add("`{0}posts`.`is_practice`= @practice");
                param.Add(new MySqlParameter("@practice", post.Practice));
            }

            if (modi == PostModified.Save)
            {
                sets.Add("`{0}posts`.`post_name`= @pname");
                sets.Add("`{0}posts`.`post_title`= @title");
                sets.Add("`{0}posts`.`content`= @content");
                sets.Add("`{0}posts`.`modified`= @modified");
                sets.Add("`{0}posts`.`modified_time`= @modifiedtime");
                param.Add(new MySqlParameter("@pname", post.Name));
                param.Add(new MySqlParameter("@title", post.Title));
                param.Add(new MySqlParameter("@content", post.Content));
                param.Add(new MySqlParameter("@modified", true));
                param.Add(new MySqlParameter("@modifiedtime", DateTime.Now));
            }
            if (modi == PostModified.Send)
            {
                sets.Add("`{0}posts`.`visible_state`= @visiblestate");
                param.Add(new MySqlParameter("@visiblestate", post.VisibleState));
            }
            string sql = "UPDATE `{0}posts` SET " + string.Join(",", sets.ToArray()) + " WHERE `{0}posts`.`post_id` = {1}";
            sql = string.Format(sql, Helper.Prefix, post.ID);
            return Helper.Query(sql, param.ToArray());
        }

        /// <summary>
        /// 全局修改
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public int Update(PostsModel post)
        {
            List<MySqlParameter> param = new List<MySqlParameter>();
            List<string> sets = new List<string>();
            sets.Add("`{0}posts`.`approved`= @approved");
            sets.Add("`{0}posts`.`del_flag`= @del");
            sets.Add("`{0}posts`.`post_image`= @image");
            sets.Add("`{0}posts`.`is_practice`= @practice");
            sets.Add("`{0}posts`.`in_recycle`= @in_recycle");
            sets.Add("`{0}posts`.`post_name`= @pname");
            sets.Add("`{0}posts`.`post_title`= @title");
            sets.Add("`{0}posts`.`content`= @content");
            sets.Add("`{0}posts`.`modified`= @modified");
            sets.Add("`{0}posts`.`modified_time`= @modifiedtime");
            param.Add(new MySqlParameter("@approved", post.Approved));
            param.Add(new MySqlParameter("@del", post.DelFlag));
            param.Add(new MySqlParameter("@image", post.PostImage));
            param.Add(new MySqlParameter("@practice", post.Practice));
            param.Add(new MySqlParameter("@pname", post.Name));
            param.Add(new MySqlParameter("@title", post.Title));
            param.Add(new MySqlParameter("@content", post.Content));
            param.Add(new MySqlParameter("@modified", post.Modified));
            param.Add(new MySqlParameter("@modifiedtime", post.LastModifiedTime));
            param.Add(new MySqlParameter("@visiblestate", post.VisibleState));
            sets.Add("`{0}posts`.`visible_state`= @visiblestate");
            string sql = "UPDATE `{0}posts` SET " + string.Join(",", sets.ToArray()) + " WHERE `{0}posts`.`post_id` = {1}";
            sql = string.Format(sql, Helper.Prefix, post.ID);
            return Helper.Query(sql, param.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public int Delete(int pid)
        {
            string sql = string.Format("DELETE FROM `{0}posts` WHERE `{0}posts`.`post_id`={1};", Helper.Prefix, pid);
            return Helper.Query(sql);
        }

        protected override PostsModel ToModel(DataRow row)
        {
            PostsModel post = new PostsModel();
            if (row["post_id"] != null) post.ID = Convert.ToInt32(row["post_id"]);
            if (row["author_id"] != null) post.AuthorID = Convert.ToInt32(row["author_id"]);
            if (row["visible_state"] != null) post.VisibleState = Convert.ToInt16(row["visible_state"]);

            if (row["create_time"] != null) post.CreateTime = Convert.ToDateTime(row["create_time"]);
            post.SendTime = row["send_time"] != null && !row.Table.Columns["send_time"].AllowDBNull ? (Nullable<DateTime>)Convert.ToDateTime(row["send_time"]) : null;
            post.LastModifiedTime = row["modified_time"] != null && !row.Table.Columns["modified_time"].AllowDBNull ? (Nullable<DateTime>)Convert.ToDateTime(row["modified_time"]) : null;

            if (row["can_comment"] != null) post.CanComment = Convert.ToBoolean(row["can_comment"]);
            if (row["password_state"] != null) post.PasswordState = Convert.ToBoolean(row["password_state"]);
            if (row["post_type"] != null) post.PostType = Convert.ToBoolean(row["post_type"]);
            if (row["modified"] != null) post.Modified = Convert.ToBoolean(row["modified"]);
            if (row["del_flag"] != null) post.DelFlag = Convert.ToBoolean(row["del_flag"]);
            if (row["approved"] != null) post.Approved = Convert.ToBoolean(row["approved"]);

            if (row["post_name"] != null) post.Name = row["post_name"].ToString();
            if (row["post_title"] != null) post.Title = row["post_title"].ToString();
            if (row["content"] != null) post.Content = row["content"].ToString();
            if (row["user_agent"] != null) post.UserAgent = row["user_agent"].ToString();
            if (row["author_ip"] != null) post.IP = row["author_ip"].ToString();
            if (row["post_password"] != null) post.Password = row["post_password"].ToString();
            if (row["post_image"] != null) post.PostImage = row["post_image"].ToString();
            if (row["theme_guid"] != null) post.ThemeGuid = row["theme_guid"].ToString();

            return post;

        }

    }
}
