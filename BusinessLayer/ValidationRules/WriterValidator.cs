using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x=>x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı Kısmı Boş Geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Kısmı Boş Geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez");
            //RuleFor(x => x.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifrede En Az Bir Büyük Harf Bulunmalı");
            //RuleFor(x=>x.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifrede En Az Bir Küçük Harf Bulunmalı");
            //RuleFor(x => x.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifrede En Az Bir Rakam  Bulunmalı");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız");
            RuleFor(x => x.WriterName).MaximumLength(100).WithMessage("Lütfen En Fazla 50 Karakter Girişi Yapınız");


        }
    }
}
