using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExample.Application.Users.Queries
{
    public class GetPaginatedUsersQueryValidator : AbstractValidator<GetPaginatedUsersQuery>
    {
        public GetPaginatedUsersQueryValidator() 
        {
            RuleFor(x => x).Must(x => { return (x.PageNumber > 0 && x.PageSize > 0); }).WithMessage("ivalid number of pages or page size");
        }
    }
}
