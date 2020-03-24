using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZombieGame.Infrastructure.Commands;
using ZombieGame.ViewModels.Base;

namespace ZombieGame.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public string Title { get; set; } = "Охота на зомби";
        private int _Width;
        public int Width { get => _Width; set => Set(ref _Width, value); }
        private int _Height;
        public int Height { get => _Height; set => Set(ref _Height, value); }

        private UserVM _UserVM;
        public UserVM UserVM
        {
            get => _UserVM;
            set => Set(ref _UserVM, value);
        }

        private ObservableCollection<ZombieViewModel> _ZombieListVM = new ObservableCollection<ZombieViewModel>();
        public ObservableCollection<ZombieViewModel> ZombieListVM
        {
            get => _ZombieListVM;
            set => Set(ref _ZombieListVM, value);
        }

        public MainWindowViewModel()
        {
            Width = 10;
            Height = 10;
            UserVM = new UserVM() { Name = "Hunter", HealsPoint = 100 };

            foreach (var zombie in Enumerable.Range(1, 10)
                .Select(i => new ZombieViewModel
                {
                    Name = $"Zombie {i}",
                    Position = BaseGameObjectViewModel.GetRandomPosition(Width, Height),
                    Direction = BaseGameObjectViewModel.GetRandomDirection()
                }))
            {
                _ZombieListVM.Add( zombie );
            }
            /////////
            /////////
            ///   1.СДЕЛАТЬ ВЫВОД СПИСКА ЗОМБИ НА ИГРОВОЕ ПОЛЕ
            ///   2.СДЕЛАТЬ ТАЙМЕР И СЛУЧАЙНОЕ ПЕРЕМЕЩЕНИЕ ЗОМБИ
            ///   3.СДЕЛАТЬ ПРОВЕРКУ НА СТОЛКНОВЕНИЕ С ИГРОКОМ ПО ПРАВИЛУ: 
            ///     Если игрок наступил на зомби со спины самого зомби, 
            ///     то убить зомбаря, иначе зомби съедает 10% здоровья игрока и делает очередной RandomStep
            /////////
            /////////

            MyKeyDown = new LambdaCommand(OnMyKeyDownCommandExecuted);
        }

        #region Команды
        public ICommand MyKeyDown { get; }
        private void OnMyKeyDownCommandExecuted(object parameter)
        {
            switch (parameter.ToString()){
                case "W":
                    UserVM.Direction = Direction.UP;
                    break;
                case "A":
                    UserVM.Direction = Direction.LEFT;
                    break;
                case "S":
                    UserVM.Direction = Direction.DOWN;
                    break;
                case "D":
                    UserVM.Direction = Direction.RIGHT;
                    break;
            }
            UserVM.Step();
        }
        #endregion
    }
}
