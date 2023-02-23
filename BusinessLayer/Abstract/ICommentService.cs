﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService
	{
		void CommentAdd(Comment comment);
		 

		void CategoryAdd(Category category);
		void CategoryRemove(Category category);
		void CategoryUpdate(Category category);
		Category GetById(int id);
		List<Category> GetAllCategories();
	}
}
