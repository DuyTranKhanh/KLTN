using Collections = System.Collections.Generic;

namespace KLTN.ViewModel
{
    public class MainViewModel
    {
        public Collections.IReadOnlyList<string> Arg { get; }

        public MainViewModel(Collections.IReadOnlyList<string> arg)
        {
            Arg = arg;
        }

        public MainViewModel()
        {

        }
    }
}
