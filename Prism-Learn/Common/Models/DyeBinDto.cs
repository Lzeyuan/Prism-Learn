using Prism.Mvvm;
using System.Windows;

namespace Prism_Learn.Common.Models {
    public class DyeBinDto : BindableBase {

        public enum State {
            kNone,
            kCoverGlass,
            kPressed,
            kSubside,
            kLoadSample,
            kHematoxylin,
            kEAOG,
            kBuffer,
            kAbsoluteAlcohol
        }

        private string image = "";
        public string Image {
            get { return image; }
            set {
                image = value;
                RaisePropertyChanged();
            }
        }

        private int number;
        public int Number {
            get { return number; }
            set {
                number = value;
                RaisePropertyChanged();
            }
        }

        private string backgroundColor = "#FFFFFF";
        public string BackgroundColor {
            get { return backgroundColor; }
            set {
                backgroundColor = value;
                RaisePropertyChanged();
            }
        }

        private Visibility show = Visibility.Collapsed;
        public Visibility Show {
            get { return show; }
            set {
                show = value;
                RaisePropertyChanged();
            }
        }

        public void SetState(State state) {


            if (state == State.kNone) {
                BackgroundColor = "#F6F6F6";
                Show = Visibility.Collapsed;
            } else if (state == State.kCoverGlass) {
                BackgroundColor = "#FFFFFF";
                Show = Visibility.Collapsed;
            } else {
                BackgroundColor = "#FFFFFF";
                Show = Visibility.Visible;
            }


            switch (state) {
                case State.kPressed:
                    Image = "/Image/ic_dyebin_pressed.png";
                    break;
                case State.kSubside:
                    Image = "/Image/ic_dyebin_subside.png";
                    break;
                case State.kLoadSample:
                    Image = "/Image/ic_dyebin_load_sample.png";
                    break;
                case State.kHematoxylin:
                    Image = "/Image/ic_dyebin_hematoxylin.png";
                    break;
                case State.kEAOG:
                    Image = "/Image/ic_dyebin_eaog.png";
                    break;
                case State.kBuffer:
                    Image = "/Image/ic_dyebin_buffer.png";
                    break;
                case State.kAbsoluteAlcohol:
                    Image = "/Image/ic_dyebin_absolute_alcohol.png";
                    break;
            }
        }
    }
}
