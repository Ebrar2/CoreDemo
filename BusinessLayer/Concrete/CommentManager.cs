using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CommentManager : ICommentService
	{
		ICommentsDal comments;

		public CommentManager(ICommentsDal comments)
		{
			this.comments = comments;
		}

		public void CommentAdd(Comment comment)
		{
			comments.Insert(comment);
		}

		public List<Comment> GetList(int id)
		{
			return comments.GetListAll(x => x.BlogID == id);
		}
	}
}
