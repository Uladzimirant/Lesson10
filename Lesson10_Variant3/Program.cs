namespace Lesson10_Variant3
{
    //Variant 3:
    //Methods in execution manager, but _first and _second is now internal.
    //With that execution manager can create lamdas with direct links to fields in
    //operation manager.
    //Execution manager stores link to operation manager
    public enum Operation
    {
        Sum,
        Subtract,
        Multiply
    }
    public class OperationManager
    {
        internal int _first;
        internal int _second;
        private ExecutionManager _executionManager;
        public OperationManager(int first, int second)
        {
            _first = first;
            _second = second;
            _executionManager = new ExecutionManager(this);
        }

        public int Execute(Operation operation)
        {
            return _executionManager.FuncExecute[operation].Invoke();
        }
    }

    //Implement functionality
    public class ExecutionManager
    {
        public Dictionary<Operation, Func<int>> FuncExecute { get; set; }
        private OperationManager _operationManager;
        public ExecutionManager(OperationManager operationManager)
        {
            FuncExecute = new Dictionary<Operation, Func<int>>();
            _operationManager = operationManager;
            PrepareExecution();
        }

        public void PopulateFunction(Operation o, Func<int> func)
        {
            FuncExecute.Add(o, func);
        }
        private void PrepareExecution()
        {
            PopulateFunction(Operation.Sum, () => _operationManager._first + _operationManager._second);
            PopulateFunction(Operation.Subtract, () => _operationManager._first - _operationManager._second);
            PopulateFunction(Operation.Multiply, () => _operationManager._first * _operationManager._second);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var opManager = new OperationManager(20, 10);
            Console.WriteLine($"The result of the operation sum is {opManager.Execute(Operation.Sum)}");
            Console.WriteLine($"The result of the operation sub is {opManager.Execute(Operation.Subtract)}");
            Console.WriteLine($"The result of the operation mult is {opManager.Execute(Operation.Multiply)}");
            Console.ReadKey();
        }
    }
}