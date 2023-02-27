using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator: AbstractValidator<Writer>
	{
		//ctor tab tab
		public WriterValidator()
		{
			RuleFor(x=>x.WriterName).NotEmpty().WithMessage("Yazar Adı Kısmı Boş Geçilemez!");
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez!");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
		RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın!");
			RuleFor(x => x.WriterName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapın!");
		}
	}
}
