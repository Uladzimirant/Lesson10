namespace Lesson10
{
    //Variant 1:
    //Methods in operation manager, because _first and _second is private.
    //Execution manager stores link to operation manager
    public enum Operation
    {
        Sum,
        Subtract,
        Multiply
    }
    public class OperationManager
    {
        private int _first;
        private int _second;
        private ExecutionManager _executionManager;
        public OperationManager(int first, int second)
        {
            _first = first;
            _second = second;
            _executionManager = new ExecutionManager(this);

        }

        public int Sum()
        {
            return _first + _second;
        }
        public int Subtract()
        {
            return _first - _second;
        }
        public int Multiply()
        {
            return _first * _second;
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

        public void PopulateFunction(Operation o,Func<int> func)
        {
            FuncExecute.Add(o, func);
        }
        public void PrepareExecution()
        {
            PopulateFunction(Operation.Sum, _operationManager.Sum);
            PopulateFunction(Operation.Subtract, _operationManager.Subtract);
            PopulateFunction(Operation.Multiply, _operationManager.Multiply);
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