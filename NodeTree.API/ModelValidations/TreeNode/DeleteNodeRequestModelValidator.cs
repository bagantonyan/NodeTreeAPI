using FluentValidation;
using NodeTree.API.Models.TreeNode;

namespace NodeTree.API.ModelValidations.TreeNode
{
    public class DeleteNodeRequestModelValidator : AbstractValidator<DeleteNodeRequestModel>
    {
        public DeleteNodeRequestModelValidator()
        {
            RuleFor(p => p.TreeName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);

            RuleFor(p => p.NodeId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}