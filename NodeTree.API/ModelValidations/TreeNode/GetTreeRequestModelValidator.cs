using FluentValidation;
using NodeTree.API.Models.TreeNode;

namespace NodeTree.API.ModelValidations.TreeNode
{
    public class GetTreeRequestModelValidator : AbstractValidator<GetTreeRequestModel>
    {
        public GetTreeRequestModelValidator()
        {
            RuleFor(p => p.TreeName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);
        }
    }
}