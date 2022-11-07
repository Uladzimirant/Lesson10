namespace Lesson10_Variant2
{
    //Variant 2:
    //Methods in execution manager, populated with lambdas.
    //But function signature is altered and operation manager calls Invoke with parameters
    //Execution manager stores nothing but functions
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
            _executionManager = new ExecutionManager();
        }

        public int Execute(Operation operation)
        {
            return _executionManager.FuncExecute[operation].Invoke(_first, _second);
        }
    }

    //Implement functionality
    public class ExecutionManager
    {
        public Dictionary<Operation, Func<int,int,int>> FuncExecute { get; set; }
        public ExecutionManager()
        {
            FuncExecute = new Dictionary<Operation, Func<int,int,int>>();
            PrepareExecution();
        }

        public void PopulateFunction(Operation o, Func<int, int, int> func)
        {
            FuncExecute.Add(o, func);
        }
        private void PrepareExecution()
        {
            PopulateFunction(Operation.Sum, (a,b) => a + b);
            PopulateFunction(Operation.Subtract, (a, b) => a - b);
            PopulateFunction(Operation.Multiply, (a, b) => a * b);
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