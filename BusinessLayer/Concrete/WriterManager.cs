﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class WriterManager:IWriterService
	{
		IWriterDal _writerdal;

		public WriterManager(IWriterDal writerdal)
		{
			_writerdal = writerdal;
		}

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterByID(int id)
        {
            return _writerdal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Writer t)
        {
            _writerdal.Add(t);
        }

        public Writer TGetById(int id)
        {
            return _writerdal.GetById(id);
        }

        public void TRemove(Writer t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Writer t)
        {
            _writerdal.Update(t);
        }

	}
}
