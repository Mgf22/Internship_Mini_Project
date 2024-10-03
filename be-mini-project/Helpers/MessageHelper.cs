using Mini_projeto_Book_Samsys.Models;

namespace Mini_projeto_Book_Samsys.Helpers
{
    public class MessageHelper<T>
    {
        public bool Success {  get; set; }

        public string Message { get; set; } = "";

        public T Obj { get; set; }
    }

    public class MessageHelper
    {
        public bool Success { get; set; }

        public string Message { get; set; } = "";
    }
}
