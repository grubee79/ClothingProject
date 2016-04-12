using HotColdProject.commands;

namespace HotColdProject.factory
{
    public interface ValidatorFactory<T>
    {
        Validator<T> createValidators();
    }
}
