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
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");

            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog resmi boş geçilemez");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen En Fazla 150 Karakter Giriniz");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Giriniz");






        }
    }
}
