using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoyValidator : AbstractValidator<Category>
    {
        public CategoyValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı  boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori içeriği boş geçilemez");

            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz");


        }
    }
}
