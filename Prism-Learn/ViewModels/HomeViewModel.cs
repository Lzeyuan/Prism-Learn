using Prism.Mvvm;
using Prism_Learn.Common.Models;
using System.Collections.ObjectModel;

namespace Prism_Learn.ViewModels {
    public class HomeViewModel : BindableBase {
        public HomeViewModel() {
            CreateTaskBars();
            CraeteTestData();
        }

        private ObservableCollection<TaskBar> taskBars;

        public ObservableCollection<TaskBar> TaskBars {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<TodoDto> todoDtos;

        public ObservableCollection<TodoDto> Todos {
            get { return todoDtos; }
            set { todoDtos = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<MemorandumDto> memorandumDtos;

        public ObservableCollection<MemorandumDto> MemorandumDtos {
            get { return memorandumDtos; }
            set { memorandumDtos = value; RaisePropertyChanged(); }
        }

        void CreateTaskBars() {
            taskBars = new ObservableCollection<TaskBar>();

            TaskBars.Add(new TaskBar { Icon = "ClockFAST", Title = "汇总", Content = "9", Color = "#FF0CA0FF", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "ClockCheckOutline", Title = "已完成", Content = "9", Color = "#FF1ECA3A", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "ChartLineVariant", Title = "完成比例", Content = "100%", Color = "#FF02C6DC", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "PlaylistStar", Title = "备忘录", Content = "19", Color = "#FFFFA000", Target = "" });
        }

        void CraeteTestData() {
            Todos = new ObservableCollection<TodoDto>();
            MemorandumDtos = new ObservableCollection<MemorandumDto>();
            for (int i = 0; i < 10; ++i) {
                Todos.Add(new TodoDto { Title = "代办" + i, Content = "正在处理..." });
                MemorandumDtos.Add(new MemorandumDto { Title = "备忘" + i, Content = "我的密码" });
            }
        }
    }
}
