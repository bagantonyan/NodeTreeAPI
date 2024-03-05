using FluentValidation;
using NodeTree.API.Models.TreeNode;

namespace NodeTree.API.ModelValidations.TreeNode
{
    public class RenameNodeRequestModelValidator : AbstractValidator<RenameNodeRequestModel>
    {
        public RenameNodeRequestModelValidator()
        {
            RuleFor(p => p.TreeName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);

            RuleFor(p => p.NodeId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.NewNodeName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);
        }
    }
}