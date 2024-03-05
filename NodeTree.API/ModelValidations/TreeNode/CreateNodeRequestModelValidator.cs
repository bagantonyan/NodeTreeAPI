using FluentValidation;
using NodeTree.API.Models.TreeNode;

namespace NodeTree.API.ModelValidations.TreeNode
{
    public class CreateNodeRequestModelValidator : AbstractValidator<CreateNodeRequestModel>
    {
        public CreateNodeRequestModelValidator()
        {
            RuleFor(p => p.TreeName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);

            RuleFor(p => p.ParentNodeId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.NodeName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);
        }
    }
}
