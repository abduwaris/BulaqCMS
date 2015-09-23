using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.Models;
using BulaqCMS.IDAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace BulaqCMS.DAL.MySql
{
    public class CommentsDAL : BaseDAL<CommentsModel>, ICommentsDAL
    {
        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="postID">文章</param>
        /// <param name="authorId">作者</param>
        /// <param name="isDel">删除标识</param>
        /// <param name="isApproved">批准</param>
        /// <param name="isInRecycle">回收站</param>
        /// <param name="ip">IP</param>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public int Count(int? postID = null, int? authorId = null, bool? isDel = null, bool? isApproved = null, string ip = null, string email = null)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (postID != null) dic.Add("post_id", postID);
            if (authorId != null) dic.Add("author_id", authorId);
            if (isDel != null) dic.Add("del_flag", isDel);
            if (isApproved != null) dic.Add("approved", isApproved);
            if (ip != null) dic.Add("author_ip", ip);
            if (email != null) dic.Add("author_email", email);
            List<string> wheres = new List<string>();
            foreach (var d in dic)
                wheres.Add(string.Format("`{0}comments`.`{1}`=@{1}", "{0}", d.Key));
            string sql = string.Format("SELECT COUNT(DISTINCT `{0}comments`.`com_id`) FROM `{0}comments`" + (wheres.Count > 0 ? "WHERE " + string.Join(" AND ", wheres.ToArray()) : ""), Helper.Prefix);
            return Convert.ToInt32(Helper.First(sql, dic.Select(p => new MySqlParameter("@" + p.Key, p.Value)).ToArray()));
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
            string sql = string.Format("SELECT (SELECT COUNT(`{0}comments`.`com_id`) FROM `{0}comments`) AS `total_count`, (SELECT COUNT(`{0}comments`.`com_id`) FROM `{0}comments` WHERE `approved` = TRUE) AS `approved_count`, (SELECT COUNT(`{0}comments`.`com_id`) FROM `{0}comments` WHERE `{0}comments`.`del_flag` = TRUE) AS `del_flag_count` FROM `{0}comments` LIMIT 0,1;", Helper.Prefix);
            DataTable dt = Helper.Select(sql);
            if (dt.Rows.Count < 1) return false;
            DataRow row = dt.Rows[0];
            allCount = Convert.ToInt32(row["total_count"]);
            approvedCount = Convert.ToInt32(row["approved_count"]);
            delflagCount = Convert.ToInt32(row["del_flag_count"]);
            return true;

        }

        /// <summary>
        /// 获取文章评论关系,只读取 评论ID 和 文章ID
        /// </summary>
        /// <param name="postIds"></param>
        /// <returns></returns>
        public List<CommentsModel> CommentsInPost(params int[] postIds)
        {
            string sql = string.Format("Select `{0}comments`.`com_id`,`{0}comments`.`post_id` from `{0}comments` where `{0}comments`.`post_id` IN ({1});", Helper.Prefix, string.Join(",", postIds));
            DataTable dt = Helper.Select(sql);
            if (dt.Rows.Count <= 0) return null;
            return dt.Rows.Cast<DataRow>().Select(r => new CommentsModel() { ID = Convert.ToInt32(r["com_id"]), PostID = Convert.ToInt32(r["post_id"]) }).ToList();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="orderByMode">排序方式</param>
        /// <param name="postID">文章 ID</param>
        /// <param name="authorId">作者ID</param>
        /// <param name="isDel">删除标识</param>
        /// <param name="isApproved">批准</param>
        /// <param name="isInRecycle">回收站</param>
        /// <returns></returns>
        public List<CommentsModel> GetPage(int pageIndex, int pageSize, CommentOrderByMode orderByMode, int? postID = null, int? authorId = null, bool? isDel = null, bool? isApproved = null, string ip = null, string email = null)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (postID != null) dic.Add("post_id", postID);
            if (authorId != null) dic.Add("author_id", authorId);
            if (isDel != null) dic.Add("del_flag", isDel);
            if (isApproved != null) dic.Add("approved", isApproved);
            if (email != null) dic.Add("author_email", email);
            if (ip != null) dic.Add("author_ip", ip);
            List<string> wheres = new List<string>();
            foreach (var d in dic)
                wheres.Add(string.Format("`{0}comments`.`{1}`=@{1}", "{0}", d.Key));
            string sql = "SELECT * FROM `{0}comments`" + (wheres.Count > 0 ? " WHERE " + string.Join(" AND ", wheres.ToArray()) : "");
            //OrderBy
            List<string> orderBy = new List<string>();
            if (orderByMode != CommentOrderByMode.None)
            {
                if (orderByMode == CommentOrderByMode.ID || orderByMode == CommentOrderByMode.ID_Desc)
                {
                    if (orderByMode == CommentOrderByMode.ID && orderByMode != CommentOrderByMode.ID_Desc)
                        orderBy.Add("`{0}comments`.`com_id` ASC");
                    else if (orderByMode != CommentOrderByMode.ID && orderByMode == CommentOrderByMode.ID_Desc)
                        orderBy.Add("`{0}comments`.`com_id` DESC");
                }
                if (orderByMode == CommentOrderByMode.Approved || orderByMode == CommentOrderByMode.Approved_Desc)
                {
                    if (orderByMode == CommentOrderByMode.Approved && orderByMode != CommentOrderByMode.Approved_Desc)
                        orderBy.Add("`{0}comments`.`approved` ASC");
                    else if (orderByMode != CommentOrderByMode.Approved && orderByMode == CommentOrderByMode.Approved_Desc)
                        orderBy.Add("`{0}comments`.`approved` DESC");
                }
                if (orderByMode == CommentOrderByMode.Del || orderByMode == CommentOrderByMode.Del_Desc)
                {
                    if (orderByMode == CommentOrderByMode.Del && orderByMode != CommentOrderByMode.Del_Desc)
                        orderBy.Add("`{0}comments`.`del_flag` ASC");
                    else if (orderByMode != CommentOrderByMode.Del && orderByMode == CommentOrderByMode.Del_Desc)
                        orderBy.Add("`{0}comments`.`del_flag` DESC");
                }
                if (orderByMode == CommentOrderByMode.Post || orderByMode == CommentOrderByMode.Post_Desc)
                {
                    if (orderByMode == CommentOrderByMode.Post && orderByMode != CommentOrderByMode.Post_Desc)
                        orderBy.Add("`{0}comments`.`post_id` ASC");
                    else if (orderByMode != CommentOrderByMode.Post && orderByMode == CommentOrderByMode.Post_Desc)
                        orderBy.Add("`{0}comments`.`post_id` DESC");
                }

                if (orderByMode == CommentOrderByMode.WriteTime || orderByMode == CommentOrderByMode.WriteTime_Desc)
                {
                    if (orderByMode == CommentOrderByMode.WriteTime && orderByMode != CommentOrderByMode.WriteTime_Desc)
                        orderBy.Add("`{0}comments`.`write_time` ASC");
                    else if (orderByMode != CommentOrderByMode.WriteTime && orderByMode == CommentOrderByMode.WriteTime_Desc)
                        orderBy.Add("`{0}comments`.`write_time` DESC");
                }
            }
            if (orderBy.Count > 0)
            {
                sql += " ORDER BY " + string.Join(", ", orderBy.ToArray());
            }
            //Limit
            sql += string.Format(" LIMIT {0},{1}", (pageIndex - 1) * pageSize, pageSize);
            sql = string.Format(sql, Helper.Prefix);
            return ToModelList(Helper.Select(sql, dic.Select(p => new MySqlParameter("@" + p.Key, p.Value)).ToArray()));
        }




        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public int Insert(CommentsModel com)
        {
            string sql = string.Format("INSERT `{0}comments`(`{0}comments`.`post_id`, `{0}comments`.`author_id`, `{0}comments`.`parent_id`, `{0}comments`.`content`, `{0}comments`.`write_time`, `{0}comments`.`author_ip`, `{0}comments`.`user_agent`, `{0}comments`.`author_name`, `{0}comments`.`author_email`, `{0}comments`.`author_url`, `{0}comments`.`approved`, `{0}comments`.`del_flag`) VALUES(@post_id, @author_id, @parent_id, @content, @write_time, @author_ip, @user_agent, @author_name, @author_email, @author_url, @approved, @del_flag);");
            MySqlParameter[] param = { 
                                     new MySqlParameter("@post_id",com.PostID),
                                     new MySqlParameter("@author_id",com.AuthorID),
                                     new MySqlParameter("@parent_id",com.ParentID),
                                     new MySqlParameter("@content",com.Content),
                                     new MySqlParameter("@write_time",com.WriteTime),
                                     new MySqlParameter("@author_ip",com.IP),
                                     new MySqlParameter("@user_agent",com.UserAgent),
                                     new MySqlParameter("@author_name",com.AuthorName),
                                     new MySqlParameter("@author_email",com.Email),
                                     new MySqlParameter("@author_url",com.Url),
                                     new MySqlParameter("@approved",com.Approved),
                                     new MySqlParameter("@del_flag",com.DelFlag),
                                     
                                     };
            return Convert.ToInt32(Helper.First(sql, param));
        }

        /// <summary>
        /// 修改评论
        /// </summary>
        /// <param name="com">要修改评论</param>
        /// <param name="mode">修改模式</param>
        /// <returns></returns>
        public int Update(CommentsModel com, CommentModified mode)
        {
            //if (mode == null) return 0;
            List<MySqlParameter> param = new List<MySqlParameter>();
            List<string> sets = new List<string>();
            if (mode == CommentModified.Approved || mode == CommentModified.All)
            {
                sets.Add("`{0}comments`.`approved`=@approved");
                param.Add(new MySqlParameter("@approved", com.Approved));
            }
            if (mode == CommentModified.Author || mode == CommentModified.All)
            {
                sets.Add("`{0}comments`.`author_email`=@email");
                sets.Add("`{0}comments`.`author_name`=@author_name");
                sets.Add("`{0}comments`.`author_url`=@author_url");
                param.Add(new MySqlParameter("@email", com.Email));
                param.Add(new MySqlParameter("@author_name", com.AuthorName));
                param.Add(new MySqlParameter("@author_url", com.Url));
            }
            if (mode == CommentModified.AuthorID || mode == CommentModified.All)
            {
                sets.Add("`{0}comments`.`author_id`=@author_id");
                param.Add(new MySqlParameter("@author_id", com.AuthorID));
            }
            if (mode == CommentModified.Content || mode == CommentModified.All)
            {
                sets.Add("`{0}comments`.`content`=@content");
                param.Add(new MySqlParameter("@content", com.Content));
            }
            if (mode == CommentModified.Del || mode == CommentModified.All)
            {
                sets.Add("`{0}comments`.`del_flag`=@del_flag");
                param.Add(new MySqlParameter("@del_flag", com.DelFlag));
            }
            if (mode == CommentModified.Parent || mode == CommentModified.All)
            {
                sets.Add("`{0}comments`.`parent_id`=@parent_id");
                param.Add(new MySqlParameter("@parent_id", com.ParentID));
            }

            string sql = string.Format("UPDATE `{0}comments` SET " + string.Join(", ", sets.ToArray()) + " WHERE `{0}comments`.`com_id`;", Helper.Prefix);
            return Helper.Query(sql, param.ToArray());
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id">删除id</param>
        /// <param name="isPostId">根据什么删除,是不是post</param>
        /// <returns></returns>
        public int Delete(int id, bool isPostId = false)
        {
            string sql = string.Format("DELETE FROM `{0}comments` WHERE `{0}comments`.`{1}_id`={2};", Helper.Prefix, isPostId ? "post" : "com", id);
            return Helper.Query(sql);
        }

        protected override CommentsModel ToModel(DataRow row)
        {
            CommentsModel com = new CommentsModel();
            if (row["com_id"] != null) com.ID = Convert.ToInt32(row["com_id"]);
            if (row["post_id"] != null) com.PostID = Convert.ToInt32(row["post_id"]);
            if (row["author_id"] != null) com.AuthorID = Convert.ToInt32(row["author_id"]);
            if (row["parent_id"] != null) com.ParentID = Convert.ToInt32(row["parent_id"]);
            if (row["write_time"] != null) com.WriteTime = Convert.ToDateTime(row["write_time"]);
            if (row["approved"] != null) com.Approved = Convert.ToBoolean(row["approved"]);
            if (row["del_flag"] != null) com.DelFlag = Convert.ToBoolean(row["del_flag"]);
            if (row["content"] != null) com.Content = row["content"].ToString();
            if (row["author_ip"] != null) com.IP = row["author_ip"].ToString();
            if (row["user_agent"] != null) com.UserAgent = row["user_agent"].ToString();
            if (row["author_name"] != null) com.AuthorName = row["author_name"].ToString();
            if (row["author_email"] != null) com.Email = row["author_email"].ToString();
            if (row["author_url"] != null) com.Url = row["author_url"].ToString();
            return com;
        }
    }
}
