using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator: AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Kısmı Boş Geçilemez!");
            RuleFor(x => x.BlogTitle).MinimumLength(20).WithMessage("Lütfen en az 20 karakter girişi yapın!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az başlık girişi yapın!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik Kısmı Boş Geçilemez!");
            RuleFor(x => x.BlogContent).MinimumLength(107).WithMessage("Lütfen en az 107 karakter girişi yapın!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Resmi Boş Geçilemez!");
        }
    }
}
