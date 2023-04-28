using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism_Learn.Common.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace Prism_Learn.ViewModels {
    public class SettingViewModel : BindableBase {

        int addCount = 0;

        public SettingViewModel() {
            dyeBinDtos = new ObservableCollection<DyeBinDto>();

            for (int i = 0; i < 5; ++i) {
                for (int j = 0; j < 6; ++j) {
                    DyeBinDto dyeBinDto = new();
                    dyeBinDto.Number = j * 5 + i;
                    dyeBinDto.SetState(DyeBinDto.State.kNone);
                    dyeBinDtos.Add(dyeBinDto);
                }
            }

            DyeBinDto.State state = DyeBinDto.State.kNone;
            TestClick = new DelegateCommand(() => {
                SetDyeBinDtosState(addCount, state);
                ++addCount;
                if (addCount == 2) {
                    ++state;
                    if (state > DyeBinDto.State.kAbsoluteAlcohol) state = DyeBinDto.State.kNone;
                    addCount = 0;
                }
            });
        }

        void SetDyeBinDtosState(int index, DyeBinDto.State state) {
            if (0 > index || index > 29) {
                throw new ArgumentOutOfRangeException("DyeBinDtos:" + nameof(index));
            }
            int realIndex = 6 * (index % 5) + index / 5;
            DyeBinDtos[realIndex].SetState(state);
        }
        public DelegateCommand TestClick { get; private set; }
        private ObservableCollection<DyeBinDto> dyeBinDtos;

        public ObservableCollection<DyeBinDto> DyeBinDtos {
            get { return dyeBinDtos; }
            set { dyeBinDtos = value; RaisePropertyChanged(); }
        }
    }

    public class AddOneConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            // 将绑定的数据转换为int类型并加1
            int intValue = (int)value;
            return intValue + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

}
