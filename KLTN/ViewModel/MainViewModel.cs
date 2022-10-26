using Collections = System.Collections.Generic;

namespace KLTN.ViewModel
{
    public class MainViewModel
    {
        public LoaiSan_ViewModel LoaiSan_ViewModel { get;}
        public Collections.IReadOnlyList<string> Arg { get; }

        public MainViewModel(Collections.IReadOnlyList<string> arg)
        {
            Arg = arg;
            LoaiSan_ViewModel = new LoaiSan_ViewModel();
        }

        public MainViewModel()
        {

        }
    }
}
