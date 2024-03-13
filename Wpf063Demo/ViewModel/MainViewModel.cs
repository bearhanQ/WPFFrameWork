using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Wpf063Demo.Model;

namespace Wpf063Demo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<MainFunction> Functions { get; set; }

        public MainViewModel()
        {
            Functions = new ObservableCollection<MainFunction>
            {
                new MainFunction{Name="ľ���ɱ",Image=@"/Resources/smallpng/mmcs.png"},
                new MainFunction{Name="�������",Image=@"/Resources/smallpng/qljs.png"},
                new MainFunction{Name="ϵͳ������",Image=@"/Resources/smallpng/xtqd.png"},
                new MainFunction{Name="���簲ȫ",Image=@"/Resources/smallpng/wlaq.png"},
                new MainFunction{Name="���ݰ�ȫ",Image=@"/Resources/smallpng/sjan.png"},
                new MainFunction{Name="����ܼ�",Image=@"/Resources/smallpng/rjgj.png"}
            };
        }
    }
}